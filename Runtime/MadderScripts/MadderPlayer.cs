
/*
 * MadderPlayer
 * This class is sent to the Unity game from the Madder server to register a Madder controller with the game.
 * This class is used to serialize the data sent to the RegisterMadderController function in the MadderManager.
 * This class contains a dictionary of MadderStat objects.
 * This class should not be altered.
 */
using System.Collections.Generic;
public class MadderPlayer
{
    public string name;

    public Dictionary<string, IMadderStat> stats;

}