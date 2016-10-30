using UnityEngine;
using System.Collections;

public class ClearAllSaves : MonoBehaviour {

	void Awake(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
	}
}
