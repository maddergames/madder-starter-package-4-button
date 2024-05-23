/*
 * MadderStat
 * This class is the base class for Madder player stats.
 * This class is a generic class that can be used to store different types of stats.
 * The allowed types are string, float, bool, and int.
 * The title is the name of the stat and is REQUIRED.
 * The value is the value of the stat and is REQUIRED.
 * This class may be added to or extended, but name and value must not be removed or altered.
 */
using System;

/*
 * IMadderStat
 * This interface is used to allow the MadderStat class to be used in the MadderPlayer class generically.
 */
public interface IMadderStat { }

[AllowedType]
[System.Serializable]
public class MadderStat<T> : IMadderStat
{
    static MadderStat()
    {
        ValidateType();
    }

    private static void ValidateType()
    {
        Type type = typeof(T);
        if (type != typeof(string) && type != typeof(float) && type != typeof(bool) && type != typeof(int))
        {
            throw new InvalidOperationException("Type not allowed. Only string, float, bool, or int are allowed.");
        }
    }

    public string Name { get; set; }
    public T Value { get; set; }

}

public class AllowedTypeAttribute : Attribute { }
