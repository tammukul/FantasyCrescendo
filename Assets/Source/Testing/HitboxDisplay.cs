﻿using HouraiTeahouse.SmashBrew;
using UnityEngine;

namespace HouraiTeahouse {

public class HitboxDisplay : MonoBehaviour {

    [SerializeField]
    KeyCode _key = KeyCode.F11;

    /// <summary> Unity callback. Called once per frame. </summary>
    void Update() {
        if (!Debug.isDebugBuild)
            enabled = false;
        if (Input.GetKeyDown(_key))
            Hitbox.DrawHitboxes = !Hitbox.DrawHitboxes;
    }
    
    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        if (Hitbox.DrawHitboxes) {
            foreach (var hitbox in Hitbox.ActiveHitboxes)
                hitbox.DrawHitbox();
        }
        Graphics.Blit(src, dst);
    }

}

}

