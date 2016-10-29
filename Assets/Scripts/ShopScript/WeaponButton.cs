using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CompleteProject
{
	public class WeaponButton : MonoBehaviour {

		public PlayerProfile profile;
		public int weaponNumber;

		public Text name;
		public Text cost;
		public Text description;

		//private AudioSource source;

		// Use this for initialization
		void Start () 
		{
			SetButton ();
		}

		void SetButton()
		{
			string costString = profile.weapons [weaponNumber].cost.ToString ();
			name.text = profile.weapons [weaponNumber].name;
			cost.text = "$" + profile.weapons [weaponNumber].cost;
			description.text = profile.weapons [weaponNumber].description;
		}

		public void OnClick()
		{
			if (profile.weapons [weaponNumber].isBougth == false && profile.Coins >= profile.weapons [weaponNumber].cost) {

				profile.Coins -= profile.weapons [weaponNumber].cost;
				profile.currentWeapon = weaponNumber;
				profile.weapons [weaponNumber].isBougth = true;

			} else if (profile.weapons [weaponNumber].isBougth == true) {
				profile.currentWeapon = weaponNumber;
				cost.text = "ээ блэт тудох";
			} else {
				print ("Бляя)) Пизда бомжара сука");
			}
		}

	}

}