﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[System.Serializable]
public class BossObject : ScriptableObject {

	public string bossName = "Boss Name";
	public float HP = 300;
	public string description;
	public Sprite itemImage;
	public float timeToKill_seconds = 25;
	public bool isKilled;
	public int levelToOpen;

	public int goldPerKill;
	public float XPperKill;

    public string bossPrefix;
    public DateTime coolDownTimer;
    public float cdTimer;

    public DateTime coolDownEndTimeStamp;
    TimeSpan unbiasedRemaining;
    private PlayerProfile profile;
    private int bossNumber;

    void Start(){
		if (PlayerPrefs.GetString (bossName) == "killed") {
			isKilled = true;
		}
		if (isKilled == true) {
			PlayerPrefs.SetString (bossName, "killed");
		}

	}

	void Update(){
		PlayerPrefs.SetString (bossName, "killed");
		PlayerPrefs.Save ();
		if (isKilled == true) {
			Debug.Log ("Убил");
		}
	}




    void Awake()
    {
          profile = FindObjectOfType<PlayerProfile>();
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {

            this.WriteTimestamp(profile.bosses[bossNumber].bossName + "_timer", coolDownEndTimeStamp);
        }
        else
        {

            coolDownEndTimeStamp = this.ReadTimestamp(profile.bosses[bossNumber].bossName + "_timer", UnbiasedTime.Instance.Now().AddSeconds(0));
        }
    }

    void OnApplicationQuit()
    {
        this.WriteTimestamp(profile.bosses[bossNumber].bossName + "_timer", coolDownEndTimeStamp);
    }


    //------------
    public DateTime ReadTimestamp(string key, DateTime defaultValue)
    {
        long tmp = Convert.ToInt64(PlayerPrefs.GetString(key, "0"));
        if (tmp == 0)
        {
            return defaultValue;
        }
        return DateTime.FromBinary(tmp);
    }

    public void WriteTimestamp(string key, DateTime time)
    {
        PlayerPrefs.SetString(key, time.ToBinary().ToString());
    }
    //-------------




}