using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarketItem : MonoBehaviour {

	public int price;
	public bool isBought = false;
	public static bool acceptToBuy = false;
	public GameObject confirmPanel;
	//public GameObject item;
	public Button item;
	//public int damage;


	void Update(){
		if (isBought == false) {
			item.interactable = false;
		} else
			item.interactable = true;
	}
		



	void buyItem(){
		confirmPanel.SetActive (true);
		if (isBought == false) {
			if (PlayerProfile.Coins >= price) {
				if (acceptToBuy == true) {
					PlayerProfile.Coins -= price;
					item.interactable = true;
					isBought = true;

				}
			}
		}
		confirmPanel.SetActive (false);
		acceptToBuy = false;
	}

	/*bool ShowWarningBeforeBuy(){
		confirmPanel.SetActive (true);
		if(){


			confirmPanel.SetActive (false);
		}else
			confirmPanel.SetActive (false);
			return false;
	}*/

}
