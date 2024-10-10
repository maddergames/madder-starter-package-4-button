
/*
    * Madder class: MadderControllerState
    * This class is used to serialize the data sent to the UpdateMadderControllerState function
    * This class defines the layout of the Madder Controller for the Unity Input System
    * This class should not be altered for the Madder controller
    */
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.Layouts;
using UnityEngine;


[System.Serializable]
public struct MadderControllerState : IInputStateTypeInfo
{
    public static FourCC Format => new FourCC('M', 'A', 'D', 'R');
    public string name;
    [InputControl(name = "joystick", layout = "Vector2")]
    public Vector2 joystick;

    [InputControl(name = "circle", layout = "Button")]
    public float circle;

    [InputControl(name = "triangle", layout = "Button")]
    public float triangle;

    [InputControl(name = "square", layout = "Button")]
    public float square;

    [InputControl(name = "m", layout = "Button")]
    public float m;

    [InputControl(name = "plus", layout = "Button")]
    public float plus;
    public FourCC format => Format;
}

