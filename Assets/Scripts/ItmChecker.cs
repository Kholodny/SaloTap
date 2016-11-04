using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ItmChecker : MonoBehaviour {

	private const float 
	hoursToDegrees = 360f / 12f, 
	minutesToDegrees = 360f / 60f, 
	secondsToDegrees = 360f / 60f; 
	private float seconds = 180f;
	public Text timeText;

	void Update () { 
		testTimer ();
		DateTime time = DateTime.Now;
		
//		timeText.text = time.Hour + ":" + time.Minute + ":" + time.Second + " / Timer: " + seconds;
			 
			//hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees); 
			//minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees); 
			//seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees); 
		print(time.Hour + ":" + time.Minute+ ":" + time.Second + " / Timer: " + seconds);
		//print (time.Millisecond);
		Application.runInBackground = true;
	} 


	void testTimer(){
		seconds -= Time.deltaTime;
	}
}
