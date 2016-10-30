using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
		//public Sprite btImage;

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
			//boss = FindObjectOfType<Boss> ();
			bt = GetComponent<Button> ();
			SetButton ();
			if(bossNumber == profile.currentWeapon){
				description.text = "Selected";
			}
		}

		void Update(){
			SetButton ();
			if(profile.levelDisplay < profile.bosses[bossNumber].levelToOpen){
				bt.interactable = false;
			}


		}

		void SetButton()
		{
			name.text = profile.bosses [bossNumber].bossName;
			description.text = profile.bosses [bossNumber].description;
			time.text = profile.bosses [bossNumber].description;

			//Здесь добавить условие, при котором если предмет куплен, то будет выводиться только его левел и урон, без цены
		}

		public void OnClick()
		{ 
			/*if (profile.bosses [bossNumber].isKilled == false && profile.levelDisplay >= profile.bosses[bossNumber].levelToOpen) {

				//profile.Coins -= profile.weapons [bossNumber].cost;
				profile.currentBoss = bossNumber;
				profile.bosses[bossNumber].isKilled = true;
				boss.HealphPoint = profile.bosses [bossNumber].HP;
				boss.Timer = profile.bosses [bossNumber].timeToKill_seconds;

			} else if (profile.bosses [bossNumber].isKilled == true) {
				profile.currentBoss = bossNumber;
				time.text = "ээ блэт тудох";
			} else if (profile.levelDisplay < profile.bosses[bossNumber].levelToOpen) {
				print ("Уровень мал!");
			} */

			/*profile.currentBoss = bossNumber;
			profile.bosses[bossNumber].isKilled = true;
			boss.HealphPoint = profile.bosses [bossNumber].HP;
			boss.Timer = profile.bosses [bossNumber].timeToKill_seconds;*/
			profile.currentBoss = bossNumber;
			boss.HealphPoint = boss.maxHP = profile.bosses [bossNumber].HP;
			boss.MaxTimer = profile.bosses [bossNumber].timeToKill_seconds;
			boss.hpSlider.maxValue = boss.HealphPoint;
			boss.TimerSlider.maxValue = boss.MaxTimer;
			//boss.maxHP = profile.bosses [bossNumber].HP;
			//boss.MaxTimer = profile.bosses [bossNumber].timeToKill_seconds;
			/*
			 *  HealphPoint = maxHP = player.bosses [thisBoss].HP;
				MaxTimer = player.bosses [thisBoss].timeToKill_seconds;
				hpSlider.maxValue = HealphPoint;
				TimerSlider.maxValue = MaxTimer;
			 */ 
			ChooseBoss ();

		}

		public void ChooseBoss(){
			mainCanvas.SetActive (false);
			bossCanvas.SetActive (true);
		}


	}

}