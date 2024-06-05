using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

/**
 * MadderControllerManager
 * This class is used to manage the Madder controllers.
 * This class is a singleton so it can be used across scenes.
 * This class should not be altered.
 */
public class MadderControllerManager : MonoBehaviour
{

    private Dictionary<string, MadderController> controllers = new Dictionary<string, MadderController>();
    private static MadderControllerManager instance;

    /**
     * Awake
     * This function is called when the object becomes enabled and active.
     * This function is used to initialize the singleton instance and register the MadderController layout with the InputSystem.
     */
    private void Awake()
    {
        //Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InputSystem.RegisterLayout<MadderController>();

        }
        else
        {
            Destroy(gameObject);
        }

    }

    /**
     * CreateController
     * This function is used to create a new Madder controller.
     * If using the InputSystem, this function will register a new MadderController input device with the InputSystem.
     * @param string gamername
     * @return MadderController
     */
    public MadderController CreateController(string gamername)
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
    public MadderController GetController(string gamername)
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
    public void RemoveController(string gamername)
    {
        if (controllers.TryGetValue(gamername, out var device))
        {
            InputSystem.RemoveDevice(device);
            controllers.Remove(gamername);
        }
    }

    /**
     * OnDestroy
     * This function is called when the object is destroyed.
     * This function is used to remove all Madder controllers from the InputSystem.
     */
    private void OnDestroy()
    {
        foreach (var controller in controllers.Values)
        {
            InputSystem.RemoveDevice(controller);
        }
        controllers.Clear();
    }
}

