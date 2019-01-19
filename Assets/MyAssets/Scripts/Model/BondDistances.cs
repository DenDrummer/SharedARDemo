using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Model class used to calculate the bonds so the can be displayed
 */
public class BondDistances
{
    public float distance { get; private set; }
    public Transform atomFirst { get; private set; }
    public Transform atomSecond { get; private set; }

    public BondDistances(float distance, Transform atomFirst, Transform atomSecond)
    {
        
        this.atomFirst = atomFirst;
        this.atomSecond = atomSecond;
        this.distance = distance;
    }

    
    public int CompareTo(object obj)
    {
        if (this.distance < ((BondDistances)obj).distance)
        {
            return -1;
        }
        if (this.distance > ((BondDistances)obj).distance)
        {
            return 1;
        }
        return 0;
    }
}
