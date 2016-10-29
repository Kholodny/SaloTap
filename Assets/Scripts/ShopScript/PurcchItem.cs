using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PurcchItem : MonoBehaviour {

	public GameObject originalItem;
	public GameObject shopItem;
	public GameObject confDialog;
	public  bool isBougth, canBuy;
	public  string itemBought, itemName;
	private string boughtName;
	public  int price;
	public  int levelToOpen;
	private int playerBabki;
	PlayerProfile profile;
	public Button btYes, btNo;

	public GameObject iconExist, iconLetsBuy;


	void Awake(){
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();
		//PlayerPrefs.SetString (itemName, itemName);
		profile = FindObjectOfType<PlayerProfile> ();

		boughtName = itemName + "_bought";
		print (boughtName);
		itemName = PlayerPrefs.GetString (itemName);
		print (itemName);

		if (itemName == boughtName) {
			isBougth = true;
		} else {
			isBougth = false;
		}

	}
		

	void Update(){

		if (PlayerPrefs.GetInt ("Level") >= levelToOpen) {
			shopItem.SetActive (true);
		}

		/*if (PlayerPrefs.GetString (itemOpenStatus) == "Open")
			canBuy = true;
		else
			canBuy = false;*/
		if (PlayerPrefs.GetString(itemName) == boughtName) {
			isBougth = true;
		}
		if (isBougth == true) {
			iconExist.SetActive (true);
			iconLetsBuy.SetActive (false);
		} else if (isBougth == false) {
			iconExist.SetActive (false);
			iconLetsBuy.SetActive (true);
		}

	}

	public   void preBuy(){
		print ("название предмета " + PlayerPrefs.GetString(itemName));
		if (PlayerPrefs.GetString (itemName) != boughtName) {
			print ("Покупка " + PlayerPrefs.GetString(itemBought));
			ShowConfirmDialouege ();
		} else if(PlayerPrefs.GetString(itemName) == boughtName) {
			originalItem.GetComponent<Image> ().sprite = shopItem.GetComponent<Image> ().sprite;
			print ("Установка скина " + PlayerPrefs.GetString(itemBought));
		}
	}

	void ShowConfirmDialouege(){
		confDialog.SetActive (true);
	}

	public void Yes(){
		if (isBougth == false && PlayerPrefs.GetInt ("Coins") >= price) {
			profile.Coins -= price;
			//itemName = itemName + "_bought";
			PlayerPrefs.SetString (itemName, itemName + "_bought");
			print ("Установка имени: " + itemName);
			//PlayerPrefs.SetString (itemBought, "bought");
			PlayerPrefs.Save ();
			isBougth = true;
			originalItem.GetComponent<Image> ().sprite = shopItem.GetComponent<Image> ().sprite;
			iconExist.SetActive (true);
			iconLetsBuy.SetActive (false);

			print ("название предмета " + PlayerPrefs.GetString(itemName));
			print ("Вы купили этуй хуйню, статус: " + PlayerPrefs.GetString (itemBought));
			print (profile.Coins);
			print (isBougth);

		} else if (PlayerPrefs.GetInt ("Coins") < price) {
			print ("Недостаточно денег!");
		} else {
			print ("Товар куплен!");
		}

		print (PlayerPrefs.GetString (itemBought));
		confDialog.SetActive (false);
	}

	public void No(){
		confDialog.SetActive (false);
	}

}
