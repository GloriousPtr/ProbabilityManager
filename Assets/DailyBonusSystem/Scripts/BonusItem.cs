using System;
using UnityEngine;

[System.Serializable]
public class BonusItem
{
	public string name;
    public int ProbabilityPercent;
    public float Angle; // create class viewer info


    public float Percent
    {
        get { return ProbabilityPercent / 1000; }
    }
}