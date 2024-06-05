using UnityEngine.InputSystem;
using System.Collections.Generic;

/**
 * MadderControllerManager
 * This class is used to manage the Madder controllers.
 * This class is static so it can be used across scenes.
 * This class should not be altered.
 */
public static class MadderControllerManager
{

    private static Dictionary<string, MadderController> controllers = new Dictionary<string, MadderController>();
    /**
     * CreateController
     * This function is used to create a new Madder controller.
     * If using the InputSystem, this function will register a new MadderController input device with the InputSystem.
     * @param string gamername
     * @return MadderController
     */
    public static MadderController CreateController(string gamername)
    {
        var device = InputSystem.AddDevice<MadderController>();

        controllers[gamername] = device;
        return device;
    }

    /**
     * GetController
     * This function is used to get a Madder controller.
     * @param string gamername
     * @return MadderController
     */
    public static MadderController GetController(string gamername)
    {
        controllers.TryGetValue(gamername, out var device);
        return device;
    }

    /**
     * RemoveController
     * This function is used to remove a Madder controller.
     * If using the InputSystem, this function will remove the MadderController input device from the InputSystem.
     * @param string gamername
     */
    public static void RemoveController(string gamername)
    {
        if (controllers.TryGetValue(gamername, out var device))
        {
            InputSystem.RemoveDevice(device);
            controllers.Remove(gamername);
        }
    }

}

