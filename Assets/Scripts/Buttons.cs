using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
	public Sprite maxImage, minImage;
	public string action;
	public GameObject menuOverlay;
	public string bossName;


	void OnMouseDown(){
		GetComponent<SpriteRenderer> ().sprite = minImage;
	}

	void OnMouseUp(){
		GetComponent<SpriteRenderer> ().sprite = maxImage;

	}

	public void OnMouseUpAsButton(){
		switch (action) {
		case "Play":
			//Application.LoadLevel ("gameScene");
			SceneManager.LoadScene("gameScene");
			//Application.OpenURL("http://geyportal.net/uploads/posts/2014-10/1414098012_h11nkd6cij0.jpg");
			break;

		case "ShowMenu":
			menuOverlay.SetActive (true);
			break;
		case "MainMenu":
			SceneManager.LoadScene ("mainMenu");
			//Application.LoadLevel ("mainMenu");

			break;

		case "CloseMenu":
			//Time.timeScale = 1;
			menuOverlay.SetActive (false);
		break;

		case "gameScene":
		//	Application.LoadLevel ("gameScene");
			SceneManager.LoadScene ("gameScene");
			//Debug.Log ("work");
			break;
		}
	}
}
