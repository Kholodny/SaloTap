using UnityEngine;
using System.Collections;

public class ShopBack : MonoBehaviour {

	public GameObject detectClicks;


	void OnEnable(){
		detectClicks.SetActive (false);
	}

	void OnDisable(){
		detectClicks.SetActive (true);
	}

}
