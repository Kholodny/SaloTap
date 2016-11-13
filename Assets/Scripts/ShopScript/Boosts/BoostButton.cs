using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CompleteProject
{
	public class BoostButton : MonoBehaviour {

		public PlayerProfile profile;
		public int weaponNumber;

		public Text name;
		public Text cost;
		public Text description;
		public Image btImg;


		void Start () 
		{
			//btImg.sprite = profile.boosts [weaponNumber].itemImage;
			SetButton ();
			if(weaponNumber == profile.currentBoost){
				description.text = "Selected";
			}
		}

		void Update(){
			SetButton ();
			if(weaponNumber == profile.currentBoost){
				description.text = "Selected";
			}


		}

		void SetButton()
		{
			if (profile.weapons [weaponNumber].isBougth == false && profile.Coins >= profile.weapons [weaponNumber].cost) {

				//name.text = profile.boosts [weaponNumber].name;
				cost.text = "$" + profile.boosts [weaponNumber].cost;
				//description.text = profile.boosts [weaponNumber].description;
			} else if (profile.boosts [weaponNumber].isBougth == true) {
				cost.text = "$" + profile.boosts [weaponNumber].cost;
				//name.text = profile.boosts [weaponNumber].name;
				//cost.text = "Bought";
				//description.text = profile.boosts [weaponNumber].description;
			} else {
				//name.text = profile.boosts [weaponNumber].name;
				cost.text = "$" + profile.boosts [weaponNumber].cost;
				long nadoDeneg = profile.boosts [weaponNumber].cost - profile.score;
				description.text = "Need Coins:" + nadoDeneg.ToString();
			}
		}

		public void OnClick()
		{ 
			if (profile.boosts [weaponNumber].isBougth == false && profile.Coins >= profile.boosts [weaponNumber].cost) {
				
				profile.boosts[weaponNumber].cost = (long)Mathf.Round(profile.boosts[weaponNumber].baseCost * Mathf.Pow(1.15f, profile.boosts[weaponNumber].count));
			
				profile.score -= profile.boosts [weaponNumber].cost;

				print (profile.boosts [weaponNumber].cost);

				profile.currentBoost = weaponNumber;
				profile.boosts [weaponNumber].isBougth = true;

				} else if (profile.boosts [weaponNumber].isBougth == true) {
					profile.boosts[weaponNumber].cost = (long)Mathf.Round(profile.boosts[weaponNumber].baseCost * Mathf.Pow(1.15f, profile.boosts[weaponNumber].count));
					profile.score -= profile.boosts [weaponNumber].cost;

				print (profile.boosts [weaponNumber].cost);

					profile.boosts [weaponNumber].damage += profile.boosts [weaponNumber].damage;
					profile.currentBoost = weaponNumber;
					cost.text = "ээ блэт тудох";
				} else if (profile.Coins < profile.weapons [weaponNumber].cost) {
					print ("Бляя)) Пизда бомжара сука");
				} 

		}


	}

}