using UnityEngine;
using System.Collections;

public class BuyItem : MonoBehaviour {
	/*Скрипт для кнопки покупки, перенести на кнопку покупки естьжи
	 * 
	 *
	 */
	public GameObject selectBtn, whichItem, mainItem;

	void Start(){
		PlayerPrefs.SetInt ("Coins", 500);
	}


	void OnMouseDown(){
		if (PlayerPrefs.GetInt ("Coins") >= 50) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 50);
			PlayerPrefs.SetString (whichItem.GetComponent<SelectItem> ().thisItem, "Open");
			mainItem.GetComponent<SpriteRenderer> ().sprite = GameObject.Find (whichItem.GetComponent<SelectItem> ().thisItem).GetComponent<SpriteRenderer>().sprite;
			selectBtn.SetActive (true);
		}
	}
}
