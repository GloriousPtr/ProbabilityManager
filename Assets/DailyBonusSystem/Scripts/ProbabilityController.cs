using System;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine;

public class ProbabilityController
{
	public static int ChoiceRandom(BonusItem[] items)
    {
        int total_probability = items.Sum(reward => reward.ProbabilityPercent);

        Array.Sort(items, (x, y) => -x.CompareTo(y));
        var array = new float[items.Length];

        for (int index = 0; index < items.Length; index++)
            array[index] = (float) items[index].ProbabilityPercent / total_probability;

        var choice = GetRandom(array);

        return choice;
    }

    public static int GetRandom(float[] probability)
    {
        float total = probability.Sum();

        if (total > 1)
            throw new Exception("Overall probability is greater than 1, total = " + total);

        var randomPoint = Random.value * total;

        for (int i = 0; i < probability.Length; i++)
        {
            if (randomPoint <= probability[i])
                return i;

            randomPoint -= probability[i];
        }

        return probability.Length - 1;
    }
}