using System.Collections.Generic;
using UnityEngine;
/**
 * Static class that saves all stats of the user
 */
public static class UserStats
{
    public static State State { get; set; }
    public static string Cif { get; set; }
    public static int Bonds { get; set; }
    public static int Size { get; set; }
    public static Transform FirstLocation { get; set; }
    public static Transform SecondLocation { get; set; }
    public static bool[] ShowConnections { get; set;}
    public static List<GameObject> DisabledObjects { get; set; }

    static UserStats()
    {
        State = State.Default;
        Cif = ""; //default cif file goes here
        Bonds = 2;
        Size = 3;
    }
}
