﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	public float HealphPoint;
	public float maxHP;
	public Text hpText;
	public Text readyText;

	private PlayerProfile player;

	public Slider hpSlider;
	public Slider TimerSlider;

	public float Timer;
	public float MaxTimer;
	public GameObject mainCanvas, bossCanvas, boss, preGamePanel, readyPanel;
	public int thisBoss;

	//Winner's Prises
	public int wonGold;
	public float wonXP;
	public Sprite spriteOfBoss;


	public GameObject losePanel, winPanel;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		player = FindObjectOfType<PlayerProfile> ();
		/*maxHP = HealphPoint;
		MaxTimer = Timer;
		hpSlider.maxValue = HealphPoint;
		TimerSlider.maxValue = Timer;*/
	//	spriteOfBoss = player.bosses [thisBoss].itemImage;
		HealphPoint = maxHP = player.bosses [thisBoss].HP;
		MaxTimer = player.bosses [thisBoss].timeToKill_seconds;
		hpSlider.maxValue = HealphPoint;
		TimerSlider.maxValue = MaxTimer;


	}

	// Update is called once per frame
	void Update () {
		
		


		hpSlider.value = HealphPoint;
		TimerSlider.value = Timer;
		if (preGamePanel.activeSelf == true) {
			Time.timeScale = 0;
			
			print ("pause");
		} else {
			Time.timeScale = 1;
			print ("figth");
			StartCoroutine (TimerGo ());
			TimerSlider.value = Timer;
			hpText.text = maxHP + " / " + HealphPoint;
			if (Timer <= 0) {
				print ("Проиграл!");
				OpenLosePanel ();
			}
			if(HealphPoint <=0 && Timer > 0){
				HealphPoint = 0;
				print("win");
				OpenWinPanel ();
			}
		}
	}

	void OnMouseDown(){
		GetDamage ();
		transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
	}

	void OnMouseUp(){
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	void GetDamage(){
		HealphPoint -= player.ptsPerClick;
		print (HealphPoint);
	}

	IEnumerator TimerGo(){
		yield return new WaitForSeconds (0.7f);
		if (Timer > 0) {
			Timer -= Time.deltaTime;
		}
	}

	void OpenLosePanel(){
		Time.timeScale = 0;
		boss.SetActive (false);
		losePanel.SetActive (true);
	}

	void OpenWinPanel(){
		Time.timeScale = 0;
		boss.SetActive (false);
		winPanel.SetActive (true);
	}


	public void TryAgain(){
		HealphPoint = maxHP;
		Timer = MaxTimer;
		losePanel.SetActive (false);
		boss.SetActive (true);
		preGamePanel.SetActive (true);
		//
		//ReadyToFight ();
		Time.timeScale = 1;
	}

	public void NotAgain(){
		Time.timeScale = 1;
		losePanel.SetActive (false);
		bossCanvas.SetActive (false);
		mainCanvas.SetActive (true);
	}

	public void StartFight(){
		preGamePanel.SetActive (false);
		HealphPoint = maxHP;
		Timer = MaxTimer;
	}

	public void GetYourPrise(){
		player.Coins += wonGold;
		player.xp += wonXP;

		Time.timeScale = 1;
		bossCanvas.SetActive (false);
		mainCanvas.SetActive (true);
	}
		
}
