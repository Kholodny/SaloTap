using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {
	public PlayerProfile profile;
	public AudioClip clickSound;
	public int clickCount;
	public int clickBoost;
	public static Click Instans{ get; set; }



	public float timerIn = 3f;
	private float timerTmp;
	public float ckps;
	private int pstToX2 = 25;
	private int pstToX4 = 75;
	private int pstToX6 = 125;

	private float timerToX2 = 5f;
	private float timerToX4 = 2.5f;
	private float timerToX6 = 1.5f;
	public GameObject boostAnim;
	public Text boostText;
	private RectTransform rec;
	public float speed = 5f, checkPos = 0;

	void Start(){
		gameObject.GetComponent<AudioSource>().clip = clickSound;
		timerTmp = timerIn;
		rec = boostAnim.GetComponent<RectTransform> ();
	}

	void FixedUpdate(){
		CheckBoost ();
	}

	void Update(){
		ShowStats ();



	

		if (timerIn > 0) {
			timerIn -= Time.deltaTime;

			//Повышение бонyсов
			if (clickCount >= pstToX2 && clickCount < pstToX4) {
				clickBoost = 2;
				//timerTmp = 3f;
				timerTmp = timerToX2;
			} else if (clickCount >= pstToX4 && clickCount < pstToX6) {
				clickBoost = 4;
				//timerTmp = 2.1f;
				timerTmp = timerToX4;
			} else if (clickCount >= pstToX6) {
				clickBoost = 6;
				//timerTmp = 0.3f;
				timerTmp = timerToX6;
			} else {
				clickBoost = 0;
				timerTmp = 10;
				//clickCount = 0;
			}

			//Снижение бонyсов
			if (clickBoost == 6 && timerIn <= 0) {
				clickBoost = 4;
				clickCount = pstToX4;
				timerIn = timerToX4;
			} 
			else if (clickBoost == 4 && timerIn <= 0) {
				clickBoost = 2;
				clickCount = pstToX2;
				timerIn = timerToX2;
			}
			else if (clickBoost == 2 && timerIn <= 0) {
				clickBoost = 0;
				clickCount = 0;
				timerIn = 10;
			}

		} else {
			clickBoost = 0;
			clickCount = 0;

		}


	
		print ("Tim:" + timerIn + ", boost: " + clickBoost + ", count: " + clickCount);

	}

	void OnMouseDown(){
		Clicked ();
		transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
	}

	void OnMouseUp(){
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}


	public void Clicked(){
		//CheckBoost ();
		//New Version
		timerIn = timerTmp;
		clickCount++;
		gameObject.GetComponent<AudioSource>().Play();
		profile.score += profile.ptsPerClick;
		profile.xp = profile.xp + profile.plusXP;
		profile.LevelUp ();
		transform.localScale = new Vector3 (0.9f, 0.9f, 0.9f);
		transform.localScale = new Vector3 (1f, 1f, 1f);


	}

	void CheckBoost(){
		switch (clickBoost) {
		case 2:

			boostText.text = "x2";
			profile.ptsPerClick = profile.defaultPtsPerClick*2;
			profile.plusXP = profile.DefaultPlusXP*4;
			break;
		case 4:

			boostText.text = "x4";
			profile.ptsPerClick = profile.defaultPtsPerClick*4;
			profile.plusXP = profile.DefaultPlusXP*6;
			break;
		case 6:
			
			boostText.text = "x6";
			profile.ptsPerClick = profile.defaultPtsPerClick*6;
			profile.plusXP = profile.DefaultPlusXP*10;
			break;
		default:
			boostText.text = "";
			profile.ptsPerClick = profile.defaultPtsPerClick;
			profile.plusXP = profile.DefaultPlusXP;
			break;
		}
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