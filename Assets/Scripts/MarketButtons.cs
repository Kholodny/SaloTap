using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarketButtons : MonoBehaviour {
	public GameObject panel_1;
	public GameObject panel_2;
	//public int gamePanelNubmer = 0;


	public void pickItemsShop(){
		panel_1.SetActive (true);
		panel_2.SetActive (false);
	}

	public void pickAnotherShop(){
		panel_1.SetActive (false);
		panel_2.SetActive (true);
	}

	public void ConfirmPurchInShop(){
		MarketItem.acceptToBuy = true;
	}
	public void DiscardPurchInShop(){
		MarketItem.acceptToBuy = false;
	}
}
