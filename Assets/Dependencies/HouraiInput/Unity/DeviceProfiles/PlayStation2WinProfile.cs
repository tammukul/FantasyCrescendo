namespace HouraiTeahouse.HouraiInput {

    public class PlayStation2WinProfile : UnityInputDeviceProfile {

        public PlayStation2WinProfile() {
            Name = "PlayStation DualShock 2 Controller";
            Meta = "Compatible with PlayStation 2 Controller to USB adapter.";

            SupportedPlatforms = new[] {"Windows"};

            JoystickNames = new[] {"Twin USB Joystick"};

            ButtonMappings = new[] {
                new InputMapping {Handle = "Cross", Target = InputTarget.Action1, Source = Button(2)},
                new InputMapping {Handle = "Circle", Target = InputTarget.Action2, Source = Button(1)},
                new InputMapping {Handle = "Square", Target = InputTarget.Action3, Source = Button(3)},
                new InputMapping {Handle = "Triangle", Target = InputTarget.Action4, Source = Button(0)},
                new InputMapping {Handle = "Left Bumper", Target = InputTarget.LeftBumper, Source = Button(6)},
                new InputMapping {Handle = "Right Bumper", Target = InputTarget.RightBumper, Source = Button(7)},
                new InputMapping {Handle = "Left Trigger", Target = InputTarget.LeftTrigger, Source = Button(4)},
                new InputMapping {Handle = "Right Trigger", Target = InputTarget.RightTrigger, Source = Button(5)},
                new InputMapping {Handle = "Select", Target = InputTarget.Select, Source = Button(8)},
                new InputMapping {Handle = "Start", Target = InputTarget.Start, Source = Button(9)},
                new InputMapping {Handle = "Left Stick Button", Target = InputTarget.LeftStickButton, Source = Button(10)},
                new InputMapping {
                    Handle = "Right Stick Button",
                    Target = InputTarget.RightStickButton,
                    Source = Button(11)
                }
            };

            AnalogMappings = new[] {
                new InputMapping {Handle = "Left Stick X", Target = InputTarget.LeftStickX, Source = Analog(0)},
                new InputMapping {
                    Handle = "Left Stick Y",
                    Target = InputTarget.LeftStickY,
                    Source = Analog(1),
                    Invert = true
                },
                new InputMapping {Handle = "Right Stick X", Target = InputTarget.RightStickX, Source = Analog(3)},
                new InputMapping {
                    Handle = "Right Stick Y",
                    Target = InputTarget.RightStickY,
                    Source = Analog(2),
                    Invert = true
                },
                new InputMapping {
                    Handle = "DPad Left",
                    Target = InputTarget.DPadLeft,
                    Source = Analog(4),
                    SourceRange = InputMapping.Negative,
                    TargetRange = InputMapping.Negative,
                    Invert = true
                },
                new InputMapping {
                    Handle = "DPad Right",
                    Target = InputTarget.DPadRight,
                    Source = Analog(4),
                    SourceRange = InputMapping.Positive,
                    TargetRange = InputMapping.Positive
                },
                new InputMapping {
                    Handle = "DPad Up",
                    Target = InputTarget.DPadUp,
                    Source = Analog(5),
                    SourceRange = InputMapping.Positive,
                    TargetRange = InputMapping.Positive
                },
                new InputMapping {
                    Handle = "DPad Down",
                    Target = InputTarget.DPadDown,
                    Source = Analog(5),
                    SourceRange = InputMapping.Negative,
                    TargetRange = InputMapping.Negative,
                    Invert = true
                }
            };
        }

    }

}