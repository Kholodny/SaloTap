using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerColldown : MonoBehaviour {

    public DateTime coolDownEndTimeStamp;
    public Text cdText;
    TimeSpan unbiasedRemaining;
    private PlayerProfile profile;
    private int bossNumber;

    void Awake()
    {
        profile = FindObjectOfType<PlayerProfile>();
        bossNumber = profile.currentBoss;
        coolDownEndTimeStamp = this.ReadTimestamp(profile.bosses[bossNumber].bossName + "_timer", UnbiasedTime.Instance.Now().AddSeconds(180));
    }

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {

            this.WriteTimestamp(profile.bosses[bossNumber].bossName + "_timer", coolDownEndTimeStamp);
        }
        else
        {

            coolDownEndTimeStamp = this.ReadTimestamp(profile.bosses[bossNumber].bossName + "_timer", UnbiasedTime.Instance.Now().AddSeconds(60));
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
