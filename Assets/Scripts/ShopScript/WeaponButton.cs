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

		/*
		 * Добавить меню выбора предметов, куда перекидываются предметы и их там можно выбирать, а в магазине кнопку делать неактивной 
		 * Скорее всего нужно это добавить в этом скрипте, используя условие покупки ->
		 * ->Если предмет куплен, то в вашем сундуке вызывать функционал выбора его, а в магазине interectible = false
		 * 
		*/

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

			//Здесь добавить условие, при котором если предмет куплен, то будет выводиться только его левел и урон, без цены
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