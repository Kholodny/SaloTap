using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class PlayAd : MonoBehaviour {

	
	void Start(){
		if (Advertisement.isSupported) {
			Advertisement.Initialize ("1200195", false);
		} else {
			Debug.Log ("Not supported on your govno!");
		}
	}

	public void ShowAdForPrise(){
		
		
		if (Advertisement.IsReady ()) {
			Advertisement.Show ("rewardedVideo", new ShowOptions (){ resultCallback = HandleAdResult });
		}

	}

	private void HandleAdResult(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			print ("+10 монет, он пидор досмотрел)");
			print (result);
			break;
		case ShowResult.Skipped:
			print ("Не бля, ты пропстил ебать)");
			print (result);
			break;
		case ShowResult.Failed:
			print ("шота с инетом");
			print (result);
			break;
		}
	}
}
