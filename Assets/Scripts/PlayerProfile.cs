using UnityEngine;
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

	//test
	public Text xpShow;
	public float xpToLvlup;
	public Text xpLvlShow;
	public float plusXP;



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
