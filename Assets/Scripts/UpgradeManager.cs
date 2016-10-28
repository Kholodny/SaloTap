using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public Click click;
	public Text itemInfo;
	public float cost;
	public int count = 0;
	public int clickPower;
	public string itemName;
	private float _newCost;
//	private float baseCost;
	public Color affordable;
	public Color standard;
	private Slider _slider;
	public PlayerProfile profile;

	void Start(){
		//baseCost = cost;
		_slider = GetComponentInChildren<Slider> ();

	}
	
	// Update is called once per frame
	void Update() {
		itemInfo.text = itemName + "\nCost: " + cost + "\nPower: + " + clickPower;


		/*if (click.gold >= cost) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image> ().color = standard;
		}*/

		/*_slider.value = click.gold / cost * 100;
		if (_slider.value >= 100) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image> ().color = standard;
		}*/ 

	}

	public void PurchaseUpgrade(){
		if (profile.getScore() >= cost) {
			//click.gold -= cost;
			//profile.setScore (profile.getScore () - cost);
			profile.score -=cost;
			count++;
			//click.goldPerClick += clickPower;
			//profile.setPtsPerClick(profile.getPtsPerClick() + clickPower);
			profile.ptsPerClick += clickPower;
			cost = Mathf.Round (cost * 1.15f);
			_newCost = Mathf.Pow (cost, _newCost = cost);
			//cost = Mathf.Round(baseCost * Mathf.Pow (1.15f, count));
		}
	}
}
