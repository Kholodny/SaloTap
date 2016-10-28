using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

	public int Damage;
	public PlayerProfile profile;
	public Sprite img;
	public Image target;


	// Use this for initialization
	void Start () {
		profile.ptsPerClick = Damage;
		target.sprite = img;
	}


		
	public void setWeapon(){
		target.sprite = img;
		profile.ptsPerClick = Damage;
	}


}
