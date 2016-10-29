using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InGameShop : MonoBehaviour {

	public GameObject ShopPanel;
	public GameObject gameProcess;

	public GameObject shp_page1;
	public GameObject shp_page2;



	public void OpenShop(){
		ShopPanel.SetActive (true);
		gameProcess.SetActive (false);
	}

	public void CloseShop(){
		ShopPanel.SetActive (false);
		gameProcess.SetActive (true);
	}

	public void openFirstPage(){
		shp_page1.SetActive (true);
		shp_page2.SetActive (false);
	}

	public void openSecondPage(){
		shp_page1.SetActive (false);
		shp_page2.SetActive (true);
	}
}
