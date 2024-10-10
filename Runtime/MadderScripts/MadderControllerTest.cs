using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    * MadderControllerTest
    * This class is used to test the MadderController class.
    * This class can be altered.
    */
public class MadderControllerTest : MonoBehaviour
{
    public void TestMadderInput()
    {
        //Register a new madder controller with a random name
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        string randomName = "";
        for (int i = 0; i < 4; i++)
        {
            randomName += chars[Random.Range(0, chars.Length)];
        }
        MadderPlayer madderPlayer = new MadderPlayer();
        madderPlayer.name = randomName;
        string madderPlayerJson = JsonUtility.ToJson(madderPlayer);
        MadderManager.Instance.RegisterMadderController(madderPlayerJson);
        //Create a new controller state that follows MadderControllerState class
        //Wait for 5 seconds
        //Send a new controller state with different values
        StartCoroutine(waiter(randomName));

    }

    IEnumerator waiter(string randomName)
    {
        //Give the controller a random direction to move in
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        string jsonControllerState = "{\"name\":\"" + randomName + "\",\"joystick\":{\"x\":" + x + ",\"y\":" + y + "},\"circle\":false,\"triangle\":false,\"square\":false,\"m\":false,\"plus\":false}";
        MadderManager.Instance.UpdateMadderControllerState(jsonControllerState);
        //wait for 5 seconds
        yield return new WaitForSeconds(5);

        //send a new controller state with different values
        jsonControllerState = "{\"name\":\"" + randomName + "\",\"joystick\":{\"x\":0,\"y\":0},\"circle\":false,\"triangle\":false,\"square\":false,\"m\":false,\"plus\":false}";
        MadderManager.Instance.UpdateMadderControllerState(jsonControllerState);

    }
}
