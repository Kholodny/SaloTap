using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowConfirmBuy : MonoBehaviour {
	public static GameObject confDialog;

	void Start(){
		confDialog = GetComponent<GameObject> ();
	}

	/*public  void ButtonYes(){
		int minusBabki = PlayerPrefs.GetInt ("Coins") - PurcchItem.getPrice();
		PlayerPrefs.SetInt ("Coins", minusBabki);
		print ("Boutgh!");
		print (PlayerPrefs.GetInt ("Coins"));
		PurcchItem.setisBougth (true);
	}*/

	public void ButtinNo(){
		confDialog.SetActive (false);
	}

	public static void showConfirmDialouge(){
		confDialog.SetActive (true);
	}
}
