using UnityEngine;
using System.Collections;

public class SelectItem : MonoBehaviour {
	//Скрипт перенести на кнопку селект 
	public GameObject selectItem, buyItem, mainItem;
	//МАССИВ В RIGHTMAT.CS
	public string thisItem;

	void Start(){
		if (PlayerPrefs.GetString ("Cube") != "Open")
			PlayerPrefs.SetString ("Cube", "Open");
		/*
		 * В массив нужно перетащить все шмотки
		 * 
		 */
		//ЦИКЛ ЩАС В RIGTHMAT.CS!
	}

	void OnTriggerEnter(Collider other){
		thisItem = other.gameObject.name;
		other.transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
		if (PlayerPrefs.GetString (other.gameObject.name) == "Open") {
			selectItem.SetActive (true);
			buyItem.SetActive (false);
		} else {
			selectItem.SetActive (false);
			buyItem.SetActive (true);
		}
			
	}

	void OnTriggerExit(Collider other){
		other.transform.localScale -= new Vector3 (0.5f, 0.5f, 0.5f);
	}
}
