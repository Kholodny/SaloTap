using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
namespace CompleteProject
{
    public class BossButton : MonoBehaviour {

        public PlayerProfile profile;
        public int bossNumber;
        public GameObject mainCanvas, bossCanvas;

        public Text name;
        public Text time;
        public Text description;
        private Button bt;
        public Boss boss;
        public Image btnImg;
        public DateTime coolDownEndTimeStamp;
        public Text cdText;
        TimeSpan unbiasedRemaining;
        private TimerColldown colldown;
        private float cdTime;
        //public Sprite btImage;
        private string bossKillStatus;
        public Button thisBt;

        /*
		 * Добавить меню выбора предметов, куда перекидываются предметы и их там можно выбирать, а в магазине кнопку делать неактивной 
		 * Скорее всего нужно это добавить в этом скрипте, используя условие покупки ->
		 * ->Если предмет куплен, то в вашем сундуке вызывать функционал выбора его, а в магазине interectible = false
		 * 
		*/

        //private AudioSource source;

        void Awake()
        {
            colldown = GetComponent<TimerColldown>();
            // cdTime = profile.bosses[bossNumber].coolDownTimer;
            coolDownEndTimeStamp = colldown.ReadTimestamp(profile.bosses[bossNumber].bossName + "_timer", UnbiasedTime.Instance.Now().AddSeconds(0));
        }

        // Use this for initialization
        void Start()
        {
            bossKillStatus = PlayerPrefs.GetString(profile.bosses[bossNumber].bossPrefix);


            btnImg.sprite = profile.bosses[bossNumber].itemImage;
            bt = GetComponent<Button>();
            SetButton();
            if (bossNumber == profile.currentWeapon) {
                description.text = "Selected";
            }
        }

        void Update() {
            unbiasedRemaining = coolDownEndTimeStamp - UnbiasedTime.Instance.Now();
            //cdText.text = (/*profile.bosses[bossNumber].bossName + */":CD: " + unbiasedRemaining.TotalSeconds.ToString("0"));
            string unbiasedFormatted = "Available";
            if (unbiasedRemaining.TotalSeconds > 0)
            {
                unbiasedFormatted = string.Format("{0}:{1:D2}:{2:D2}", unbiasedRemaining.Hours, unbiasedRemaining.Minutes, unbiasedRemaining.Seconds);
               
            }
            
            cdText.text = unbiasedFormatted;

            SetButton();
            if (profile.levelDisplay < profile.bosses[bossNumber].levelToOpen || unbiasedRemaining.TotalSeconds > 0)
            {
                bt.interactable = false;
            }
            else
            {
                bt.interactable = true;
            }


		}

		void SetButton()
		{
			name.text = profile.bosses [bossNumber].bossName;
			//time.text = profile.bosses [bossNumber].description;
			time.text = "HP: " + profile.bosses [bossNumber].HP + "\nTime: " + profile.bosses [bossNumber].timeToKill_seconds + " sec";
			description.text = "Opens in " + profile.bosses [bossNumber].levelToOpen + " lvl.";
			if (bossKillStatus == "killed" || profile.bosses [bossNumber].isKilled == true) {
				name.text = profile.bosses [bossNumber].bossName + "\nkilled";
			}
			if (profile.bosses [bossNumber].levelToOpen <= profile.levelDisplay) {
				description.text = "Open";
			} else {
				description.text = "Opens in " + profile.bosses [bossNumber].levelToOpen + " lvl.";
			}

			//Здесь добавить условие, при котором если предмет куплен, то будет выводиться только его левел и урон, без цены
		}

		public void OnClick()
		{ 
			ChooseBoss ();
			profile.currentBoss = bossNumber;

			boss.HealphPoint = boss.maxHP = profile.bosses [bossNumber].HP;
		
			boss.bossName = profile.bosses [bossNumber].bossPrefix;

			boss.MaxTimer = profile.bosses [bossNumber].timeToKill_seconds;

			boss.hpSlider.maxValue = boss.HealphPoint;

			boss.TimerSlider.maxValue = boss.MaxTimer;

			boss.wonGold = profile.bosses [bossNumber].goldPerKill;

			boss.wonXP = profile.bosses [bossNumber].XPperKill;

			boss.GetComponent<Image> ().sprite = profile.bosses [bossNumber].itemImage;

			boss.thisBoss = bossNumber;



		}
        

        public void ChooseBoss(){
			mainCanvas.SetActive (false);
			bossCanvas.SetActive (true);
		}


	}

}