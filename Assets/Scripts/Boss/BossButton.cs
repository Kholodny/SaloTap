using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
		//public Sprite btImage;
		private string bossKillStatus;

		/*
		 * Добавить меню выбора предметов, куда перекидываются предметы и их там можно выбирать, а в магазине кнопку делать неактивной 
		 * Скорее всего нужно это добавить в этом скрипте, используя условие покупки ->
		 * ->Если предмет куплен, то в вашем сундуке вызывать функционал выбора его, а в магазине interectible = false
		 * 
		*/

		//private AudioSource source;

		// Use this for initialization
		void Start () 
		{
			bossKillStatus = PlayerPrefs.GetString (profile.bosses [bossNumber].bossPrefix);
		

			btnImg.sprite = profile.bosses [bossNumber].itemImage;
			bt = GetComponent<Button> ();
			SetButton ();
			if(bossNumber == profile.currentWeapon){
				description.text = "Selected";
			}
		}

		void Update(){
			SetButton ();
			if (profile.levelDisplay < profile.bosses [bossNumber].levelToOpen) {
				bt.interactable = false;
			} else {
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