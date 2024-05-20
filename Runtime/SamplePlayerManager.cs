using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SamplePlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private InputActionAsset inputActions;
    private Dictionary<string, PlayerInput> playerInputs = new Dictionary<string, PlayerInput>();
    private MadderManager madderManager;


    private void Awake()
    {
        madderManager = FindObjectOfType<MadderManager>();


        //subscribe to RegisterMadderController event
        MadderManager.onRegisterMadderController += OnRegisterMadderController;

    }


    private void OnRegisterMadderController(string gamername)
    {
        RegisterPlayer(gamername);
    }
    public void RegisterPlayer(string gamername)
    {
        // Create a new player at a random location between (0,0,0) and (4,4,0)

        GameObject player = Instantiate(playerPrefab, new Vector3(Random.Range(0, 4), Random.Range(0, 4), 0), Quaternion.identity);

        player.name = gamername;
        Debug.Log("Player created: " + player.name);


        PlayerInput playerInput = player.AddComponent<PlayerInput>();


        if (playerInput == null)
        {
            Debug.Log("PlayerInput is null");
        }

        //we must clone the inputActions to avoid sharing the same instance between players
        InputActionAsset clonedinputActions = Instantiate(inputActions);
        playerInput.actions = clonedinputActions;



        // Get the MadderController for the player
        MadderController madderController = madderManager.GetMadderController(gamername);
        //Associate the custom controller with the playerObject
        playerInput.SwitchCurrentControlScheme(madderController);
        //Print the control scheme
        Debug.Log("Control Scheme: " + playerInput.currentControlScheme);

        //Store the PlayerInput instance
        playerInputs[gamername] = playerInput;

        //Initialize the player controller
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.Initialize(playerInput);



    }

    public void UnregisterPlayer(string gamername)
    {
        if (playerInputs.TryGetValue(gamername, out var playerInput))
        {
            playerInputs.Remove(gamername);
            Destroy(playerInput.gameObject);
            madderManager.UnregisterMadderController(gamername);
        }
    }

    public bool TryGetPlayerInput(string gamername, out PlayerInput playerInput)
    {
        return playerInputs.TryGetValue(gamername, out playerInput);
    }

}
