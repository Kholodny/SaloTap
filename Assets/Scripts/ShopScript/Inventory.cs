using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject[] buttons;
	private PlayerProfile profile;

	void Start(){
		profile = FindObjectOfType<PlayerProfile> ();
	}

	void Update(){
		for (int i = 0; i < profile.weapons.Length; i++) { 
				buttons [i].SetActive (true);
			buttons [i].GetComponent<Sprite> ();

			buttons [i].GetComponent<Image> ().sprite = profile.weapons [i].itemImage;
		}
	}

}
