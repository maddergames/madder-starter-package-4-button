using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


/**
 * Madder class: MadderMessager
 * This class is used to interface between the WebGL build and the Unity game.
 * This class is a static class so it can be used across scenes.
 * This class should not be altered.
 */
public static class MadderMessager
{
    /* Madder functions that you may call
    * VibratePlayerController(string gamername) vibrates a specific controller
    * VibrateAllPlayerControllers() vibrates all controllers
    * UpdateStats(string userName, string stats)
    * ShowCode() shows the room code (must be called on Start(), not Awake())
    * HideCode() hides the room code
    * These functions should be conditionally called based on if this is inside a WebGL build, not the editor
    */
    [DllImport("__Internal")]
    public static extern void VibratePlayerController(string gamername);
    [DllImport("__Internal")]
    public static extern void VibrateAllPlayerControllers();
    [DllImport("__Internal")]
    public static extern void UpdateStats(string userName, string stats);
    [DllImport("__Internal")]
    public static extern void ShowCode();
    [DllImport("__Internal")]
    public static extern void HideCode();
}
