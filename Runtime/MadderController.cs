
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

[InputControlLayout(displayName = "MadderController", stateType = typeof(MadderControllerState))]
public class MadderController : InputDevice
{
    // Define controls

    public Vector2Control joystick { get; private set; }
    // [InputControl(layout = "Button")]
    public ButtonControl triangleButton { get; private set; }
    // [InputControl(layout = "Button")]
    public ButtonControl circleButton { get; private set; }
    // [InputControl(layout = "Button")]
    public ButtonControl plusButton { get; private set; }

    protected override void FinishSetup()
    {
        joystick = GetChildControl<Vector2Control>("joystick");
        triangleButton = GetChildControl<ButtonControl>("triangle");
        circleButton = GetChildControl<ButtonControl>("circle");
        plusButton = GetChildControl<ButtonControl>("plus");

        base.FinishSetup();
    }

    public static MadderController current { get; private set; }

    protected override void OnAdded()
    {
        if (current == null)
            current = this;
    }

    protected override void OnRemoved()
    {
        if (current == this)
            current = null;
    }
}
