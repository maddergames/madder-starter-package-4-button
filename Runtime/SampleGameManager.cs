using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGameManager : MonoBehaviour
{
    private static SampleGameManager Instance { get; set; }
    private MadderManager madderManager;
    private MadderControllerTest madderControllerTest;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
        madderManager = FindObjectOfType<MadderManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Testing Madder Controller");
            madderControllerTest = FindObjectOfType<MadderControllerTest>();
            madderControllerTest.TestMadderInput();
        }
    }
}
