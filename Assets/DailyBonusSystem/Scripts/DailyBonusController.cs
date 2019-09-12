using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DailyBonusController : MonoBehaviour
{
	public static DailyBonusController main;

	public List<BonusItem> BonusItems = new List<BonusItem>();
	public Transform arrow;

    private RectTransform arrowRect;

    private bool canRotate;

    private void Awake()
	{
		main = this;
	}

    private void Start()
    {
        arrowRect = arrow.GetComponent<RectTransform>();
    }

    public void ChoiceRandom()
    {
		canRotate = true;
    }

	private void Update()
	{
		if (canRotate)
			arrowRect.Rotate (new Vector3(0,0,250) * Time.deltaTime);
	}

	public void StopArrow()
	{
		canRotate = false;

		var choice = ProbabilityController.ChoiceRandom(BonusItems);
		print (choice.ToString());
        var rotation = arrowRect.rotation;
        StartCoroutine(
			RotateToAngle(new Vector3(0,0,1),
				rotation.eulerAngles.z,
                rotation.eulerAngles.z + (360 - rotation.eulerAngles.z) + BonusItems[choice].Angle,
				1, () =>
                {
                    print(BonusItems[choice].name);
                    // Do something BonusItem related here.
                }));
	}

    private IEnumerator RotateToAngle(Vector3 rotateAxis,float currentAngle, float targetAngleValue, float speed = 10, Action endFired = null)
    {
		var itemSoundAngle = currentAngle + (360/BonusItems.Count);
        while (true)
        {
            var step = ((targetAngleValue - currentAngle) + speed) * Time.deltaTime;
            if (currentAngle + step > targetAngleValue)
            {
                step = targetAngleValue - currentAngle;
				arrowRect.Rotate(rotateAxis, step);
                endFired?.Invoke();

                break;
            }
            currentAngle += step;
            if (currentAngle >= itemSoundAngle)
            {
//              Play your sound here
                itemSoundAngle = currentAngle + (360 / BonusItems.Count);
            }
			arrowRect.Rotate(rotateAxis, step);

            yield return null;
        }
    }
}