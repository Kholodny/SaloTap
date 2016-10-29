using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class WeaponObject : ScriptableObject {

	public string weaponName = "Weapon Name Here";
	public int cost = 50;
	public string description;
	public Sprite itemImage;
	public int damage = 10;
	public bool isBougth;

	void Start(){
		if (PlayerPrefs.GetString (weaponName) == "bought") {
			isBougth = true;
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