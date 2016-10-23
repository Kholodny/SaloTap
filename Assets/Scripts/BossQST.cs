using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossQST : MonoBehaviour {

	public float BossHP;
	private float BossMaxHP;
	public PlayerProfile player;
	public float timeToLose;
	//private float timeToLoseINNER;
	public Slider hpSlider;
	private bool isPause = false;
	public GameObject winLosePanel;

	//Переменные для вывода
	public Text time;
	public Text showHP;
	public Text showWinLose;

	// Use this for initialization


	void Start () {
		timeToLose = timeToLose;
		hpSlider.maxValue = BossHP;
		BossMaxHP = BossHP;
	}
	
	// Update is called once per frame
	void Update () {
		
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
		isPause = false;
		Application.LoadLevel ("quests");
	}

	public void setIsPause(bool pause){
		this.isPause = pause;
	}

}
