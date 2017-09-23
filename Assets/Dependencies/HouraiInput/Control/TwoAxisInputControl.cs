using UnityEngine;

namespace HouraiTeahouse.HouraiInput {

    public class TwoAxisInputControl {

        public static float StateThreshold = 0.0f;
        bool lastState;

        bool thisState;

        internal TwoAxisInputControl() {
            Left = new OneAxisInputControl();
            Right = new OneAxisInputControl();
            Up = new OneAxisInputControl();
            Down = new OneAxisInputControl();
        }

        public float X { get; protected set; }
        public float Y { get; protected set; }

        public OneAxisInputControl Left { get; protected set; }
        public OneAxisInputControl Right { get; protected set; }
        public OneAxisInputControl Up { get; protected set; }
        public OneAxisInputControl Down { get; protected set; }

        public ulong UpdateTick { get; protected set; }

        public bool State => thisState;
        public bool HasChanged => thisState != lastState;
        public Vector2 Vector => new Vector2(X, Y);

        internal void Update(float x, float y, ulong updateTick) {
            lastState = thisState;

            X = x;
            Y = y;

            Left.UpdateWithValue(Mathf.Clamp01(-X), updateTick, StateThreshold);
            Right.UpdateWithValue(Mathf.Clamp01(X), updateTick, StateThreshold);

            if (HInput.InvertYAxis) {
                Up.UpdateWithValue(Mathf.Clamp01(-Y), updateTick, StateThreshold);
                Down.UpdateWithValue(Mathf.Clamp01(Y), updateTick, StateThreshold);
            }
            else {
                Up.UpdateWithValue(Mathf.Clamp01(Y), updateTick, StateThreshold);
                Down.UpdateWithValue(Mathf.Clamp01(-Y), updateTick, StateThreshold);
            }

            thisState = Up.State || Down.State || Left.State || Right.State;

            if (thisState != lastState) {
                UpdateTick = updateTick;
            }
        }

        public static implicit operator bool(TwoAxisInputControl control) => control.thisState;
        public static implicit operator Vector2(TwoAxisInputControl control) => control.Vector;
        public static implicit operator Vector3(TwoAxisInputControl control) => new Vector3(control.X, control.Y);

    }

}