using UnityEngine;
using System.Collections;

public class RightMat : MonoBehaviour {
	public GameObject[] items;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < items.Length; i++) {
			if (PlayerPrefs.GetString ("ThisItem") == items [i].name) {
				GetComponent<SpriteRenderer> ().sprite = items [i].GetComponent<SpriteRenderer> ().sprite;
				break;
			}
		}
	}
	

}
