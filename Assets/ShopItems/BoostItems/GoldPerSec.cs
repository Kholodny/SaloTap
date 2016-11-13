using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldPerSec : MonoBehaviour {

	public Text gpsDisplay;
	public PlayerProfile click;
	public ItemManager[] items;

	void Start(){
		StartCoroutine (AutoTick ());
	}

	void Update(){
		//gpsDisplay.text = GetGoldPerSec() + " gold/sec";
	}

	public  long GetGoldPerSec(){
		float tick = 0;
		foreach (ItemManager item in items) {
			tick += item.count * item.tickValue;
		}

		return (long)tick;
	}

	public void AutoGoldPerSec(){
		click.score += GetGoldPerSec ();
	}

	IEnumerator AutoTick(){
		while(true){
			AutoGoldPerSec ();
			yield return new WaitForSeconds (0.10f);
		}
	}

}
