using UnityEngine;
using System.Collections;

public class PurchaseItem_V1_2 : MonoBehaviour {

	public GameObject[] items;
	public int[] prices;
	private int itemPrice;
	public string name;

	void Start(){
		SetPrices ();
	}

	void SetPrices(){
		for (int i = 1; i < items.Length; i++) {
			//items [i].SetActive (false);

		}
	}


}
