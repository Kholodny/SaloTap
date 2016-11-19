using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public static Buttons Instance { get; set; }

	public Sprite maxImage, minImage;
	public string action;
	public GameObject menuOverlay, mainCanvas, bossCanvas, anotherButton, thisButton;
	public GameObject soundSource;
	public string bossName;
	public Button gameButton;
	public Slider soundSlider, musicSlider;

	public float soundVol = 1f;

	void Update(){
		
	}

	void OnMouseDown(){
		GetComponent<SpriteRenderer> ().sprite = minImage;
	}

	void OnMouseUp(){
		GetComponent<SpriteRenderer> ().sprite = maxImage;

	}

	public void OnMouseUpAsButton(){
		switch (action) {
		case "Play":
                SceneManager.LoadScene("gameScene");
			break;

		case "ShowMenu":
			menuOverlay.SetActive (true);
			break;

		case "MainMenu":
                SceneManager.LoadScene("mainMenu");

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
		
		case "ExitBoss":
			Time.timeScale = 1;
			bossCanvas.SetActive (false);
			mainCanvas.SetActive (true);
			SceneManager.LoadScene ("gameScene");
			break;

		case "DefaultScene":
			SceneManager.LoadScene ("DefaultScene");
			break;
		}
			
	}


	public void ShowConfirm(){
		menuOverlay.SetActive (true);
	}

	public void MuteSound(){
		
		soundSource.GetComponent<AudioSource> ().volume = 0;
	
		PlayerPrefs.SetInt ("Sound", 0);
		PlayerPrefs.Save ();
		thisButton.SetActive (false);
		anotherButton.SetActive (true);
	}

	public void OnSound(){
		
		soundSource.GetComponent<AudioSource> ().volume = 1;
	
		PlayerPrefs.SetInt ("Sound", 1);
		PlayerPrefs.Save ();
		thisButton.SetActive (false);
		anotherButton.SetActive (true);
	}

	public void MuteMusic(){
		
			soundSource.GetComponent<AudioSource> ().volume = 0;


		PlayerPrefs.SetInt ("Music", 0);
		PlayerPrefs.Save ();
		thisButton.SetActive (false);
		anotherButton.SetActive (true);
	}

	public void OnMusic(){
		
			soundSource.GetComponent<AudioSource> ().volume = 1;

		PlayerPrefs.SetInt ("Music", 1);
		PlayerPrefs.Save ();
		thisButton.SetActive (false);
		anotherButton.SetActive (true);
	}

	public void ChangeValue(){
		soundVol = gameObject.GetComponent<Slider> ().value;
	}
}
