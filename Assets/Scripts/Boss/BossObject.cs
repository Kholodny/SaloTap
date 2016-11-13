using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class BossObject : ScriptableObject {

	public string bossName = "Boss Name";
	public float HP = 300;
	public string description;
	public Sprite itemImage;
	public float timeToKill_seconds = 25;
	public bool isKilled;
	public int levelToOpen;
	public int goldPerKill;
	public float XPperKill;
	public string bossPrefix;

	void Start(){
		if (PlayerPrefs.GetString (bossName) == "killed") {
			isKilled = true;
		}
		if (isKilled == true) {
			PlayerPrefs.SetString (bossName, "killed");
		}

	}

	void Update(){
		PlayerPrefs.SetString (bossName, "killed");
		PlayerPrefs.Save ();
		if (isKilled == true) {
			Debug.Log ("Убил");
		}
	}

}