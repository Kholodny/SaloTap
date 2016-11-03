﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour {

	public Text gpc;
	public Text scoreDisplay;
	public float score = 0.00f;
	public int ptsPerClick = 1;
	public Slider levelSlider;
	public int levelDisplay = 1;
	public float xp = 0.00f;
	public Color affordable;
	public Color standard;
	public Text levelSet;

	//weapons

	public WeaponObject[] weapons;
	public int currentWeapon;
	public Image weaponImage;

	//Bosses

	public BossObject[] bosses;
	public int currentBoss;
	public Image bossImage;

	//test
	public Text xpShow;
	public float xpToLvlup;
	public Text xpLvlShow;
	public float plusXP = 1;
	public  int Coins = 0;
	public  int Gold = 0;
	public Text coinsText;

	void Awake(){
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();
		LoadGame ();
	}



	void Update(){
		coinsText.text = "Coins: " + Coins;
		ptsPerClick = weapons [currentWeapon].damage;
		weaponImage.sprite = weapons [currentWeapon].itemImage;
		SaveGame ();
	}

	void SaveGame(){
		PlayerPrefs.SetFloat ("XPtoLVL", xpToLvlup);
		PlayerPrefs.SetFloat ("Score", score);
		PlayerPrefs.SetInt ("Level", levelDisplay);
		PlayerPrefs.SetInt ("Coins", Coins);
		PlayerPrefs.SetInt ("Damage", ptsPerClick);
		PlayerPrefs.SetFloat ("XP", xp);
		PlayerPrefs.SetInt ("WeaponSelected", currentWeapon);
		//PlayerPrefs.SetFloat ("XPBoost", plusXP);
		PlayerPrefs.Save ();
	}

	void LoadGame(){
		xp = PlayerPrefs.GetFloat ("XP");
		currentWeapon = PlayerPrefs.GetInt ("WeaponSelected");
		score = PlayerPrefs.GetFloat ("Score");
		levelDisplay = PlayerPrefs.GetInt ("Level");
		levelSlider.value = PlayerPrefs.GetFloat ("XP");
		ptsPerClick = PlayerPrefs.GetInt ("Damage");
		levelSlider.maxValue = PlayerPrefs.GetFloat ("XPtoLVL");
		xpToLvlup = PlayerPrefs.GetFloat ("XPtoLVL");
		Coins = PlayerPrefs.GetInt ("Coins");
		//plusXP = PlayerPrefs.GetFloat ("XPBoost");

	}


	//Getters/Setters
	//-------------SCORE------------//
	public float getScore(){
		return score;
	}
	public void setScore(float _score){
		this.score = _score;
	}//--------SCORE----------//

	//_------ POINTS PER CLICK-----------
	public int getPtsPerClick(){
		return ptsPerClick;
	}
	public void setPtsPerClick(int _pts){
		this.ptsPerClick = _pts;
	}//--------PTS PER CLICK -------------

	//---------XP------------------//
	public float getXP(){
		return xp;
	}
	public void setXP(float _xp){
		this.xp = _xp;
	}//-----------XP--------------//

	//------LEVEL DISPLAY-----//
	public int getLevelDisplay(){
		return levelDisplay;
	}
	public void setLevelDisplay(int _level){
		this.levelDisplay = _level;
	}//----------LEVEL DISPLAY------
	 
	//END OF GETTERS AND SETTERS---------------------//

	public void LevelUp(){
		

		//Реализация поднятия уровня
		xpToLvlup = ((levelDisplay + 1) * ((levelDisplay + 1) - 1) / 2) * 1000;
		if (xp >= xpToLvlup) {
			levelDisplay++;
			xp = 0;
			levelSlider.value = 0;
		}//Конец реализации поднятия уровня

		//Реализация ползунка опыта
		levelSlider.maxValue = xpToLvlup; 
		if (xp <= levelSlider.maxValue) {
			levelSlider.value += plusXP;
		} else {
			levelSlider.value = 0;
		}//Конец реализации ползунка опыта


		/*while (xp < levelSlider.maxValue) {
			Debug.Log ("Test");
		}*/
		/*while (xp <= levelSlider.maxValue) {
			levelSlider.value = levelSlider.value + xp;
		}//Конец реализации ползунка опыта*/
	}
}
