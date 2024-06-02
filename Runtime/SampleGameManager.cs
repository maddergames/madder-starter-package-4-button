using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGameManager : MonoBehaviour
{
    private static SampleGameManager Instance { get; set; }
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
        //only call the following if not in the editor
#if UNITY_WEBGL && !UNITY_EDITOR
        MadderMessager.ShowCode();
#endif

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
