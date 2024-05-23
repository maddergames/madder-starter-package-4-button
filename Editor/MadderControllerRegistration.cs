using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
[UnityEditor.InitializeOnLoad]
#endif

public static class MadderControllerRegistration
{
    static MadderControllerRegistration()
    {
        // Register the MadderController layout with the InputSystem
        InputSystem.RegisterLayout<MadderController>();
    }
}
