using System.Collections.Generic;
using UnityEngine.InputSystem;


/**
 * Madder class: MadderManager
 * This class is used to interface between the WebGL build and the Unity game.
 * This class is a static class so it can be used across scenes.
 * This class interacts with the MadderControllerManager to create and manage Madder controllers.
 * This class should not be altered.
 */

public static class MadderManager
{
    /**
     * RegisterMadderController
     * This function is used to register a new Madder controller.
     * This function has an attached event (OnRegisterMadderController) that can be listened to by other scripts.
     * @param string jsonRegisterMadderController
     */
    public delegate void OnRegisterMadderController(MadderPlayer madderPlayer);
    public static event OnRegisterMadderController onRegisterMadderController;
    public static void RegisterMadderController(string jsonRegisterMadderController)
    {
        //Deserialize the MadderPlayer object
        MadderPlayer madderPlayer = JsonUtility.FromJson<MadderPlayer>(jsonRegisterMadderController);

        // Create a new input device for the player
        MadderControllerManager.CreateController(madderPlayer.name);

        //Trigger events listening for OnRegisterMadderController, for example to spawn a playerObject
        onRegisterMadderController?.Invoke(madderPlayer);

    }

    /**
     * GetMadderController
     * This function is used to retrieve a Madder controller from the MadderControllerManager.
     * @param string gamername
     * @return MadderController
     */
    public static MadderController GetMadderController(string gamername)
    {
        return MadderControllerManager.GetController(gamername);
    }

    /**
     * UnregisterMadderController
     * This function is used to unregister a Madder controller from the MadderControllerManager.
     * This function has an attached event (OnUnregisterMadderController) that can be listened to by other scripts.
     * @param string gamername
     */
    public delegate void OnUnregisterMadderController(string gamername);
    public static event OnUnregisterMadderController onUnregisterMadderController;
    public static void UnregisterMadderController(string gamername)
    {
        MadderControllerManager.RemoveController(gamername);
    }

    /**
     * UpdateMadderControllerState
     * This function is used to update the state of a Madder controller.
     * This is the main way in which a Madder Controller communicates with the Unity game.
     * Upon deserializing the controller state, queue a state event to the input system.
     * If not using the unity input system, you can use the subscribe to this event to listen for the controller state being updated
     * @param string jsonControllerState 
     */
    public delegate void OnUpdateMadderControllerState(string gamername, MadderControllerState controllerState);
    public static event OnUpdateMadderControllerState onUpdateMadderControllerState;
    public static void UpdateMadderControllerState(string jsonControllerState)
    {
        //turn the booleans in the json string to floats
        jsonControllerState = jsonControllerState.Replace("true", "1");
        jsonControllerState = jsonControllerState.Replace("false", "0");
        //Deserialize the controller state and store it in a MadderControllerState object
        MadderControllerState controllerState = JsonUtility.FromJson<MadderControllerState>(jsonControllerState);
        // Retrieve the corresponding input device. The controller name is used as the device name, and is always unique
        MadderController controller = MadderControllerManager.GetController(controllerState.name);
        if (controller == null)
        {
            Debug.Log("Controller not found.");
        }
        //Update the input device with the received data
        InputSystem.QueueStateEvent(controller, controllerState);
        InputSystem.Update();

        //Trigger events listening for OnUpdateMadderControllerState, for example to move a playerObject
        onUpdateMadderControllerState?.Invoke(controllerState.name, controllerState);
    }

    /**
     * MadderHealthCheck
     * This function is used by WebGL to check for communication with the Madder package.
     * This function should not be altered.
     * @return bool
    */
    public static bool MadderHealthCheck()
    {
        //invoke javascript function to set flag
        MadderMessager.SetHealthCheckFlag();
        return true;
    }
}
