using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {
	public PlayerProfile profile;


	void Update(){

		profile.scoreDisplay.text = "Score:" + CurrencyConverter.Instance.GetCurrencyIntoString (profile.score, false, false);
		//profile.scoreDisplay.text = "Score: " + profile.score;
		profile.levelSet.text = "LvL:" + profile.levelDisplay;
		profile.xpShow.text = profile.xp + " XP / " + profile.xpToLvlup + " Next Lvl XP"; //Вывод экспы к уровню
		//profile.xpLvlShow.text = profile.xpToLvlup + " Next LvL Xp";
	}

	public void Clicked(){
		//New Version
		profile.score += profile.ptsPerClick;
		profile.xp = profile.xp + profile.plusXP;
		profile.LevelUp ();

	}
}