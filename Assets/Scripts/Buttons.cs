using UnityEngine;
using System.Collections;
//using UnityEngine.Sprite;

public class Buttons : MonoBehaviour {
	public Sprite maxImage, minImage;
	public string action;


	void OnMouseDown(){
		GetComponent<SpriteRenderer> ().sprite = minImage;
	}

	void OnMouseUp(){
		GetComponent<SpriteRenderer> ().sprite = maxImage;
	}

	void OnMouseUpAsButton(){
		switch (action) {
		case "Play":
			Application.LoadLevel ("228");
			Application.OpenURL("http://geyportal.net/uploads/posts/2014-10/1414098012_h11nkd6cij0.jpg");
			break;
		}
	}
}
