using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {
	public PlayerProfile profile;


	void Update(){

		profile.scoreDisplay.text = "Score:" + CurrencyConverter.Instance.GetCurrencyIntoString (profile.score, false, false);
		//profile.scoreDisplay.text = "Score: " + profile.score;
		profile.levelSet.text = "LvL:" + profile.levelDisplay;
		profile.xpShow.text = profile.xp + " XP / ";
		profile.xpLvlShow.text = profile.xpToLvlup + " Next LvL Xp";
	}

	public void Clicked(){
		//profile.getScore() += profile.getPtsPerClick();
		//profile.getXP = profile.getXP + 100.0f;
		//levelDisplay++;

		/*float upScore = (profile.getScore() + profile.getPtsPerClick());
		profile.setScore(upScore);
		profile.setXP(profile.getXP() + 100.0f);
		profile.LevelUp();*/


		//New Version
		profile.score += profile.ptsPerClick;
		profile.xp = profile.xp + profile.plusXP;
		profile.LevelUp ();
		Debug.Log ("228");

	}
}