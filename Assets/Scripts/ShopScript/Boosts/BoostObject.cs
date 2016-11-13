using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class BoostObject : ScriptableObject {

	public string boostName = "Weapon Name Here";
	public long cost = 50;
	public string description;
	public Sprite itemImage;
	public long damage = 10;
	public bool isBougth;
	public int levelToOpen;
	public long baseCost;
	public int count;

	void Start(){
		baseCost = cost;
		if (PlayerPrefs.GetString (boostName) == "bought") {
			isBougth = true;
		}

		if (isBougth == true) {
			PlayerPrefs.SetString (boostName, "bought");
		}
	}

	void Update(){
		if (isBougth == true) {
			PlayerPrefs.SetString (boostName, "bought");
			PlayerPrefs.Save ();
			cost = 0;
			description = "Куплен ебать";
		} else {
			PlayerPrefs.SetString (boostName, "not_bought");
			PlayerPrefs.Save ();
		}
	}
}