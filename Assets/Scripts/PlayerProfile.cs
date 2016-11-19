using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml.Serialization;//подключаем using для работы с XmlSerializer
using System.IO;//подключаем using для записи файлов
using System.Xml;

[System.Serializable]
public class PlayerProfile : MonoBehaviour {

	public static PlayerProfile Instanse{ get; set; }

	public Text gpc;
	public Text scoreDisplay;
	public GoldPerSec gps;

	//public float score = 0.00f;
	public long score = 0;
	public int ptsPerClick = 1;
	public int defaultPtsPerClick;

	public Slider levelSlider;

	public int levelDisplay = 1;

	public float xp = 0.00f;

	public Color affordable;
	public Color standard;
	public Text levelSet;

	//weapons

	public WeaponObject[] weapons;
	public int currentWeapon;
	public Image[] weaponImage;

	//Bosses

	public BossObject[] bosses;
	public int currentBoss;
	public Image bossImage;

	//Boosts
	public BoostObject[] boosts;
	public int currentBoost;
	public Image boostImage;

	//test
	public Text xpShow;
	public float xpToLvlup;
	public Text xpLvlShow;
	public float plusXP = 5;

	public float DefaultPlusXP;

	public  int Coins = 100;
	public  int Gold = 100;
	public Text coinsText;
	public Text goldText;

	public Text coinsTextShp;
	public Text goldTextShp;

	string saveScoreToString;

	public int boostScore = 0;
	//public float boostXP;

	//Combos

	private Click click;



	void Awake(){
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();
		click =  FindObjectOfType<Click>();

		defaultPtsPerClick = ptsPerClick;
		DefaultPlusXP = plusXP;

		LoadGame ();
	}

	void Start(){
		StartCoroutine (Booster (0.30f));
		print (boostScore);
	}



	void Update(){
		LevelUp ();
		//ComboClick ();

		coinsTextShp.text = Coins.ToString ();
		goldTextShp.text = Gold.ToString ();
		/*if (weapons [currentWeapon].isBougth == false) {
			currentWeapon = 0;
		}*/

		coinsText.text = "Coins: " + Coins;

		ptsPerClick = weapons [currentWeapon].damage;

		levelSlider.maxValue = xpToLvlup;
		levelSlider.value = xp;

		//Установка изображений на оружие 
		for (int i = 0; i < weaponImage.Length; i++) {
			weaponImage[i].sprite = weapons [currentWeapon].itemImage;
		}
		SaveGame ();

	}

	void SaveGame(){
		PlayerPrefs.SetFloat ("XPtoLVL", xpToLvlup); 
		PlayerPrefs.SetString ("Score_Str", score.ToString());
		PlayerPrefs.SetInt ("Level", levelDisplay); 
		PlayerPrefs.SetInt ("Coins", Coins);
		PlayerPrefs.SetInt ("Gold", Gold);
		PlayerPrefs.SetInt ("Damage", ptsPerClick);
		PlayerPrefs.SetFloat ("XP", xp);
		PlayerPrefs.SetInt ("WeaponSelected", currentWeapon);
		PlayerPrefs.SetInt ("Booster", boostScore);
		//PlayerPrefs.SetFloat ("XPBoost", plusXP);
		PlayerPrefs.Save ();
	}

	void LoadGame(){

		xp = PlayerPrefs.GetFloat ("XP");
		currentWeapon = PlayerPrefs.GetInt ("WeaponSelected");
		//score = long.Parse(PlayerPrefs.GetString ("Score1"));
		saveScoreToString = PlayerPrefs.GetString("Score_Str");

		if (PlayerPrefs.HasKey ("Score_Str")) 
			score = long.Parse (saveScoreToString);

		 else 
			score = 0;

		boostScore = PlayerPrefs.GetInt ("Booster");

		levelDisplay = PlayerPrefs.GetInt ("Level");
		levelSlider.value = PlayerPrefs.GetFloat ("XP");
		ptsPerClick = PlayerPrefs.GetInt ("Damage");
		levelSlider.maxValue = PlayerPrefs.GetFloat ("XPtoLVL");
		xpToLvlup = PlayerPrefs.GetFloat ("XPtoLVL");
		Coins = PlayerPrefs.GetInt ("Coins");
		Gold = PlayerPrefs.GetInt ("Gold");
		//plusXP = PlayerPrefs.GetFloat ("XPBoost");
	}

	private IEnumerator Booster(float waitTime){
		//float bosstXP = 0;
		while (true) {
			yield return new WaitForSeconds (waitTime);
			//bosstXP = (float)(boostScore/100);
			score = score + boostScore;
			//xp += boostXP;
		}
	}
	 

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
	}
    
   /* public void SetBossCoolDown(){
        bosses[currentBoss].bossName;
    }*/


	private void StartRefreshTimer(float maxTime){
		if(maxTime > 0){
			maxTime -= Time.deltaTime;
		}
	}
	
}
