using System;
using UnityEngine;

public class Clock : MonoBehaviour {

	const float 
		degreesPerHour = 30f,
		degreesPerMinute = 6f,
		degreesPerSecond = 6f;

    public Transform hoursTransform, minutesTransform, secondsTransform;

	public bool continuous;

    void UpdateContinuous () {
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler (0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }

	//In the original tutorial all hands used discrete time (ie used "DateTime time = Datetime.Now" instead of TimeSpan and DateTime.Now.TimeofDay). 
	//In my version only the second hand time is discrete, the others are continuous.
	//I think the UpdateDiscrete clock animation looks better this way.
	void UpdateDiscrete () {
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler (0f, DateTime.Now.Second * degreesPerSecond, 0f);
	}

	void Update () {
		if (continuous) {
			UpdateContinuous();
		} 
		else {
			UpdateDiscrete();
		}
	}
}