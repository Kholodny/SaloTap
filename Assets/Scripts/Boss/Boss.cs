using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Boss : MonoBehaviour {

	public float HealphPoint;
	public float maxHP;
	public Text hpText;
	public Text readyText;

	public PlayerProfile player;

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
	public Text priseText;
	public Text timerText;

	public AudioClip punchClip, backGroundMusic;

	public string bossName;
	private string killStatus;
    TimeSpan unbiasedRemaining;
    private TimerColldown timer;
    // Use this for initialization

    void Awake()  {
        timer = GetComponent<TimerColldown>();
        print("Cool: " + unbiasedRemaining);
    }

    void Start () {
		gameObject.GetComponent<AudioSource> ().clip = punchClip;

		Time.timeScale = 1;
		player = FindObjectOfType<PlayerProfile> ();

		killStatus = PlayerPrefs.GetString (bossName);
		if (killStatus == "killed") {
			player.bosses [thisBoss].isKilled = true;
		} else {
			player.bosses [thisBoss].isKilled = false;
		}
		print ((player.bosses [thisBoss].isKilled).ToString());
		/*maxHP = HealphPoint;
		MaxTimer = Timer;
		hpSlider.maxValue = HealphPoint;
		TimerSlider.maxValue = Timer;*/
	//	spriteOfBoss = player.bosses [thisBoss].itemImage;
	
		//HealphPoint = maxHP = player.bosses [thisBoss].HP;
		//MaxTimer = player.bosses [thisBoss].timeToKill_seconds;
		//hpSlider.maxValue = HealphPoint;
		//TimerSlider.maxValue = MaxTimer;
	}

	// Update is called once per frame
	void Update () {
        
        //Если че, вернуть обратно в старт
        if (player.bosses [thisBoss].isKilled == true) {
            wonGold = (int)player.bosses[thisBoss].goldPerKill / 2;
            wonXP = (float)player.bosses[thisBoss].XPperKill / 2;
        }


		hpSlider.value = HealphPoint;
		TimerSlider.value = Timer;
		if (preGamePanel.activeSelf == true) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
			StartCoroutine (TimerGo ());
			TimerSlider.value = Timer;
			hpText.text = maxHP + " / " + HealphPoint;
			if (Timer <= 0) {
				PlayerPrefs.SetString (bossName, "notKilled");
				PlayerPrefs.Save ();
				OpenLosePanel ();
			}
			if(HealphPoint <=0 && Timer > 0){
				HealphPoint = 0;
				player.bosses [thisBoss].isKilled = true;
				PlayerPrefs.SetString (bossName, "killed");
				PlayerPrefs.Save ();
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

	public void GetDamage(){
		gameObject.GetComponent<AudioSource> ().Play ();
		HealphPoint -= player.ptsPerClick;

		print (HealphPoint);
	}

	IEnumerator TimerGo(){
		yield return new WaitForSeconds (0.1f);
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
		priseText.text = "+Coins: " + wonGold + "\n+XP: " + wonXP;
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
		Timer = 1f;
		losePanel.SetActive (false);
		bossCanvas.SetActive (false);
		mainCanvas.SetActive (true);
		SceneManager.LoadScene("gameScene");
	}

	public void StartFight(){
		preGamePanel.SetActive (false);
		HealphPoint = maxHP;
		Timer = MaxTimer;
	}

	public void GetYourPrise(){
		player.Coins += wonGold;
		player.xp += wonXP;
		HealphPoint = 1;
		Time.timeScale = 1;
		bossCanvas.SetActive (false);
		mainCanvas.SetActive (true);


        //WriteTimestamp(player.bosses[thisBoss].bossName + "_timer", );
        player.bosses[thisBoss].coolDownEndTimeStamp = UnbiasedTime.Instance.Now().AddSeconds(player.bosses[thisBoss].cdTimer);
        player.bosses[thisBoss].WriteTimestamp(player.bosses[thisBoss].bossName + "_timer", player.bosses[thisBoss].coolDownEndTimeStamp);
        //unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now().AddSeconds(60);
        // this.WriteTimestamp("unbiasedTimer", unbiasedTimerEndTimestamp);
        SceneManager.LoadScene("gameScene");
	}

    private DateTime ReadTimestamp(string key, DateTime defaultValue)
    {
        long tmp = Convert.ToInt64(PlayerPrefs.GetString(key, "0"));
        if (tmp == 0)
        {
            return defaultValue;
        }
        return DateTime.FromBinary(tmp);
    }

    private void WriteTimestamp(string key, DateTime time)
    {
        PlayerPrefs.SetString(key, time.ToBinary().ToString());
    }




}
