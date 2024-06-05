
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

/**
 * Madder class: MadderController
 * This class is used to define the Madder Controller for the Unity Input System.
 * This class should not be altered.
 */


[InputControlLayout(displayName = "MadderController", stateType = typeof(MadderControllerState))]
public class MadderController : InputDevice
{
    // Define controls

    public Vector2Control joystick { get; private set; }

    public ButtonControl triangleButton { get; private set; }

    public ButtonControl circleButton { get; private set; }

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
