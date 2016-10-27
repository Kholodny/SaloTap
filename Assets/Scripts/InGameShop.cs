using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InGameShop : MonoBehaviour {

	public GameObject ShopPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OpenShop(){
		ShopPanel.SetActive (true);
	}

	public void CloseShop(){
		ShopPanel.SetActive (false);
	}
}
