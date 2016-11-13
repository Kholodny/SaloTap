using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {
	public PlayerProfile profile;
	public AudioClip clickSound;


	void Start(){
		gameObject.GetComponent<AudioSource>().clip = clickSound;
	}

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
		gameObject.GetComponent<AudioSource>().Play();
		profile.score += profile.ptsPerClick;
		profile.xp = profile.xp + profile.plusXP;
		profile.LevelUp ();
		transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	void ShowStats(){
		//----Старый дисплей
		//profile.scoreDisplay.text = "Score:" + CurrencyConverter.Instance.GetCurrencyIntoString (profile.score, false, false);
		//profile.coinsText.text = CurrencyConverter.Instance.GetCurrencyIntoString (profile.Coins, false, false);
		//profile.goldText.text = CurrencyConverter.Instance.GetCurrencyIntoString (profile.Gold, false, false);
		//--Новый дисплей
		profile.scoreDisplay.text = profile.score.ToString();
		profile.coinsText.text = profile.Coins.ToString();
		profile.goldText.text = profile.Gold.ToString();

		//profile.scoreDisplay.text = "Score: " + profile.score;
		profile.levelSet.text = "LvL:" + profile.levelDisplay;
		profile.xpShow.text = profile.xp + " XP / " + profile.xpToLvlup + " Next Lvl XP"; //Вывод экспы к уровню
		//profile.xpLvlShow.text = profile.xpToLvlup + " Next LvL Xp";
	}
}