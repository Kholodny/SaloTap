using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossQST : MonoBehaviour {

	public float BossHP;
	private float BossMaxHP;
	public PlayerProfile player;
	public float timeToLose;
	private float timeToLoseINNER;
	public Slider hpSlider;
	private bool isPause = false;
	public GameObject winLosePanel;
	public Button startGame;
	public GameObject preGamePanel;
	public string bossSceneToReload;
	public GameObject shopBt;

	//Переменные для вывода
	public Text time;
	public Text showHP;
	public Text showWinLose;

	// Use this for initialization


	void Start () {

		preGamePanel.SetActive (true);
		//Time.timeScale = 1;
		timeToLose = timeToLose;
		hpSlider.maxValue = BossHP;
		BossMaxHP = BossHP;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (preGamePanel.activeSelf == true) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}


		if (isPause == false) { // если пауза не стоит -> делать:
			TimerOfLose ();
			time.text = timeToLose.ToString ("f2");
			showHP.text = BossMaxHP + " \\ " + BossHP;
			hpSlider.value = BossHP;
			PlayerWin ();
		} else { //Ставится пауза
			Time.timeScale = 0;
		}

	}

	void PlayerWin(){
		if (BossHP == 0 && timeToLose > 0) {
			isPause = true;
			showWinLose.text = "You'r Win!";
			winLosePanel.SetActive (true);
		}
	}

	void TimerOfLose(){//НАчало метода таймер
		if (timeToLose > 0) {
			timeToLose -= Time.deltaTime;
		} else {
			isPause = true;
		}
	}//Конец метода таймер

	//Получаене урона боссом
	public void getBossDamageByClick(){
		BossHP -= player.ptsPerClick;
	}//Конец метода получения дмг


	public void RestartLevel(){
		Application.LoadLevel (bossSceneToReload);
		//preGamePanel.SetActive (true);
	}

	public void setIsPause(bool pause){
		this.isPause = pause;
	}

	public void ClikToStart(){
		shopBt.SetActive (false);
		timeToLose = 15.04f;
		preGamePanel.SetActive (false);
	}

}
