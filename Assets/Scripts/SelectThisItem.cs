using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectThisItem : MonoBehaviour {

	public GameObject  whichItem, mainItem;
	void OnMouseDown(){
		if(mainItem != null)
			mainItem.GetComponent<Image> ().sprite = GameObject.Find (whichItem.GetComponent<SelectItem> ().thisItem).GetComponent<Image>().sprite;
			PlayerPrefs.SetString ("ThisItem", whichItem.GetComponent<SelectItem> ().thisItem);
	}
}
