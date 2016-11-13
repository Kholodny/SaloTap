using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class WeaponObject : ScriptableObject {

	public string weaponName = "Weapon Name Here";
	public int cost = 50;
	public int costGold;
	public string description;
	public Sprite itemImage;
	public int damage = 10;
	public bool isBougth;
	public int levelToOpen;
	public bool isIAP;

	void Start(){
		if (PlayerPrefs.GetString (weaponName) == "bought") {
			isBougth = true;
		}

		if (isBougth == true) {
			PlayerPrefs.SetString (weaponName, "bought");
		}
	}

	void Update(){
		PlayerPrefs.SetString (weaponName, "bought");
		PlayerPrefs.Save ();
		if (isBougth == true) {
			cost = 0;
			description = "Куплен ебать";
		}
	}
}