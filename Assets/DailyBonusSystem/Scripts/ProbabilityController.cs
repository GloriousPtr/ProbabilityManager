using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class ProbabilityController
{
	public static int ChoiceRandom(List<BonusItem> items)
    {

//		DailyBonusController.main.BonusItems.Sort ();
		var array = new float[items.Count];

		for (int index = 0; index < items.Count; index++)
            array[index] = items[index].Percent;

        var choice = GetRandom(array);

        return choice;
    }

    public static int GetRandom(float[] probability)
    {
		int target = 0;
		int total_probability = 0;
		foreach (BonusItem reward in DailyBonusController.main.BonusItems)
			total_probability += reward.ProbabilityPercent;
		target = Random.Range(0, total_probability);
		for (int i = 0; i < DailyBonusController.main.BonusItems.Count; i++) {
			target -= DailyBonusController.main.BonusItems [i].ProbabilityPercent;
			if (target <= 0) {
				target = i;
				break;
			}
		}
		return target;
    }
}