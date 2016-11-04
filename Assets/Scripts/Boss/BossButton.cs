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
			btnImg.sprite = profile.bosses [bossNumber].itemImage;
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
			time.text = profile.bosses [bossNumber].description;
			description.text = "Opens in " + profile.bosses [bossNumber].levelToOpen + " lvl.";

			//Здесь добавить условие, при котором если предмет куплен, то будет выводиться только его левел и урон, без цены
		}

		public void OnClick()
		{ 
			ChooseBoss ();
			profile.currentBoss = bossNumber;

			boss.HealphPoint = boss.maxHP = profile.bosses [bossNumber].HP;
		

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