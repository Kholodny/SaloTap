using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameShop : MonoBehaviour {

	public GameObject ShopPanel;
	public GameObject inventoryPanel;

	public GameObject shp_page1;
	public GameObject shp_page2;

	public GameObject bosses_Panel;

	public GameObject mainCanvas, bossCanvas;



	public void OpenShop(){
		ShopPanel.SetActive (true);

	}

	public void CloseShop(){
		ShopPanel.SetActive (false);
	}



	public void openFirstPage(){
		shp_page1.SetActive (true);
		shp_page2.SetActive (false);
	}

	public void openSecondPage(){
		shp_page1.SetActive (false);
		shp_page2.SetActive (true);
	}
		
	//Меню с боссами

	public void OpenBossesPanel(){
		bosses_Panel.SetActive (true);

	}

	public void CloseBossesPanel(){
		bosses_Panel.SetActive (false);
	}

	public void ChooseBoss(){
		mainCanvas.SetActive (false);
		bossCanvas.SetActive (true);
	}
}
