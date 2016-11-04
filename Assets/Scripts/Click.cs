using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {
	public PlayerProfile profile;


	void Update(){
		ShowStats ();

	}

	void OnMouseDown(){
		Clicked ();
		transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
	}

	void OnMouseUp(){
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}


	public void Clicked(){
		//New Version
		profile.score += profile.ptsPerClick;
		profile.xp = profile.xp + profile.plusXP;
		profile.LevelUp ();
		transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	void ShowStats(){
		profile.scoreDisplay.text = "Score:" + CurrencyConverter.Instance.GetCurrencyIntoString (profile.score, false, false);
		profile.coinsText.text = CurrencyConverter.Instance.GetCurrencyIntoString (profile.Coins, false, false);
		profile.goldText.text = CurrencyConverter.Instance.GetCurrencyIntoString (profile.Gold, false, false);
		//profile.scoreDisplay.text = "Score: " + profile.score;
		profile.levelSet.text = "LvL:" + profile.levelDisplay;
		profile.xpShow.text = profile.xp + " XP / " + profile.xpToLvlup + " Next Lvl XP"; //Вывод экспы к уровню
		//profile.xpLvlShow.text = profile.xpToLvlup + " Next LvL Xp";
	}
}