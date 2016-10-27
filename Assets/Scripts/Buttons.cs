using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
	public Sprite maxImage, minImage;
	public string action;
	public GameObject menuOverlay;
	public string bossName;
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
			Application.LoadLevel ("gameScene");
			//Application.OpenURL("http://geyportal.net/uploads/posts/2014-10/1414098012_h11nkd6cij0.jpg");
			break;

		case "ShowMenu":
			
			//menuButtons [0].SetActive (false);
			menuOverlay.SetActive (true);
			/*for (int i = 1; i < menuButtons.Length; i++) {
				menuButtons [i].SetActive (true);
			}*/
			break;

		case "MainMenu":
			Application.LoadLevel ("mainMenu");
			break;

		case "CloseMenu":
			//menuButtons [0].SetActive (true);
			menuOverlay.SetActive (false);
			/*for (int i = 1; i < menuButtons.Length; i++) {
				menuButtons [i].SetActive (false);

			}*/
			break;

		case "RestartQST":
			Application.LoadLevel ("quests");
			Debug.Log ("work");
			break;
		
		case "gameScene":
			Application.LoadLevel ("gameScene");
			//Debug.Log ("work");
			break;

		case "Boss":
			Application.LoadLevel (bossName);
			break;
		}
	}
}
