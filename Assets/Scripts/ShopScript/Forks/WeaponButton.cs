using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CompleteProject
{
	public class WeaponButton : MonoBehaviour {

		public PlayerProfile profile;
		public int weaponNumber;
		private Button bt;

		public Text name;
		public Text cost;
		public Text description;
		public Image btImg;
		string boughtStatus;
		public Color dfCoin;
		public Color goldCoin;
		public Image coinImage;
		public Sprite bought, selected, defaultSpr;
		//public Sprite btImage;

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

			bt = GetComponent<Button> ();
			boughtStatus = PlayerPrefs.GetString(profile.weapons [weaponNumber].weaponName);
			//print (profile.weapons [weaponNumber].weaponName + "::" + boughtStatus);
			btImg.sprite = profile.weapons [weaponNumber].itemImage;
			SetButton ();
			if(weaponNumber == profile.currentWeapon){
				coinImage.sprite = selected;
				description.text = profile.weapons [weaponNumber].description;
				dfCoin = goldCoin;
			}
		}

		void Update(){
			SetButton ();
			boughtStatus = PlayerPrefs.GetString(profile.weapons [weaponNumber].weaponName);
			if (boughtStatus == "bought") {
				description.text = profile.weapons [weaponNumber].description;
				profile.weapons [weaponNumber].isBougth = true;
			}

			if (weaponNumber == profile.currentWeapon) {
				description.text = profile.weapons [weaponNumber].description;
				coinImage.sprite = selected;
				dfCoin = goldCoin;
			} else if (profile.weapons [weaponNumber].isBougth == true && weaponNumber != profile.currentWeapon) {
				coinImage.sprite = bought;
			} else {
				coinImage.sprite = defaultSpr;
			}

			if (profile.levelDisplay < profile.weapons [weaponNumber].levelToOpen) {
				bt.interactable = false;
			} else {
				bt.interactable = true;
			}


		}

		void SetButton()
		{
			if (profile.weapons [weaponNumber].isBougth == false && profile.Coins >= profile.weapons [weaponNumber].cost /*&& profile.weapons [weaponNumber].isIAP == false*/) {
				name.text = profile.weapons [weaponNumber].weaponName;
				cost.text = "" + profile.weapons [weaponNumber].cost;
				description.text = profile.weapons [weaponNumber].description + ", Lvl: " + profile.weapons [weaponNumber].levelToOpen;
			} else if (profile.weapons [weaponNumber].isBougth == true) {
				name.text = profile.weapons [weaponNumber].weaponName;
				cost.text = "";
				description.text = profile.weapons [weaponNumber].description + ", Lvl: " + profile.weapons [weaponNumber].levelToOpen;
			} else /*if (profile.Coins < profile.weapons [weaponNumber].cost) */{
				name.text = profile.weapons [weaponNumber].weaponName;
				cost.text = "" + profile.weapons [weaponNumber].cost;
				int nadoDeneg = profile.weapons [weaponNumber].cost - profile.Coins;
				description.text = "Need more gold:" + nadoDeneg.ToString () + ", lvl: " + profile.weapons [weaponNumber].levelToOpen;
			}/*else if(profile.weapons [weaponNumber].isIAP == true) {
				name.text = profile.weapons [weaponNumber].weaponName;
				cost.text = "GOLD:" + profile.weapons [weaponNumber].costGold;
				description.text = profile.weapons [weaponNumber].description;
			}*/
			if (profile.weapons [weaponNumber].isIAP == true) {
				cost.text = "" + profile.weapons [weaponNumber].costGold;
				coinImage.color = goldCoin;
			}
			if (profile.weapons [weaponNumber].isIAP == true && profile.weapons [weaponNumber].isBougth == true) {
				cost.text = "";
				coinImage.color = goldCoin;
			}
			//Здесь добавить условие, при котором если предмет куплен, то будет выводиться только его левел и урон, без цены
		}

		public void OnClick()
		{ 
			if (profile.weapons [weaponNumber].isIAP == false && profile.weapons [weaponNumber].isBougth == false && profile.Coins >= profile.weapons [weaponNumber].cost) {

				profile.Coins -= profile.weapons [weaponNumber].cost;
				profile.currentWeapon = weaponNumber;
				profile.weapons [weaponNumber].isBougth = true;
				PlayerPrefs.SetString (profile.weapons [weaponNumber].weaponName, "bought");

			} else if (profile.weapons [weaponNumber].isBougth == true) {
				profile.currentWeapon = weaponNumber;
				cost.text = "ээ блэт тудох";
			} else if (profile.Coins < profile.weapons [weaponNumber].cost) {
				print ("Бляя)) Пизда бомжара сука");
			} else if (profile.weapons [weaponNumber].isIAP == true && profile.weapons [weaponNumber].isBougth == false && profile.Gold >= profile.weapons [weaponNumber].costGold) {
				profile.Gold -= profile.weapons [weaponNumber].costGold;
				profile.currentWeapon = weaponNumber;
				profile.weapons [weaponNumber].isBougth = true;
				PlayerPrefs.SetString (profile.weapons [weaponNumber].weaponName, "bought");
			}

			PlayerPrefs.Save ();

		}


	}

}