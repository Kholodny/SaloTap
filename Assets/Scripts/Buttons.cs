using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
	public Sprite maxImage, minImage;
	public string action;
	public GameObject menuOverlay;
	public Button menuButton;
	public Button foobObj;
	//public GameObject[] menuButtons;


	 void OnMouseDown(){
		GetComponent<SpriteRenderer> ().sprite = minImage;
	}

	 void OnMouseUp(){
		GetComponent<SpriteRenderer> ().sprite = maxImage;

	}

	public void OnMouseUpAsButton(){
		switch (action) {
		case "Play":
			Application.LoadLevel ("228");
			//Application.OpenURL("http://geyportal.net/uploads/posts/2014-10/1414098012_h11nkd6cij0.jpg");
			break;

		case "ShowMenu":
			menuOverlay.SetActive (true);
			menuButton.interactable = false;
			foobObj.interactable = false;
			break;

		case "MainMenu":
			Application.LoadLevel ("mainMenu");
			break;

		case "CloseMenu":
			menuOverlay.SetActive (false);
			menuButton.interactable = true;
			foobObj.interactable = true;
			break;
		}

		
	}
}
