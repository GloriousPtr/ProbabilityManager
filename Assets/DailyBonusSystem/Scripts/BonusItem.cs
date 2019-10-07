using System;
using UnityEngine;

[Serializable]
public class BonusItem
{
	public string name;

    [Range(0,100)]
    public int ProbabilityPercent;

    public float Angle;

    public float Percent => (float) ProbabilityPercent / 100;

    public int CompareTo(object obj) => Percent.CompareTo(((BonusItem) obj).Percent);
}