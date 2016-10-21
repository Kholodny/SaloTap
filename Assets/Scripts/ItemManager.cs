using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour {

	public Text itemInfo;
	public Click click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	private float baseCost;
	public Color affordable;
	public Color standard;
	public PlayerProfile profile;
	void Start(){
		baseCost = cost; 
	}

	void Update(){
		itemInfo.text = itemName + "\nCost: " + cost + "\nGold: " + tickValue + "/s";

		if (profile.getScore() >= cost) {
			GetComponent<Image> ().color = affordable;
		} else {
			GetComponent<Image> ().color = standard;
		}
	}

	public void PurchaseItem(){
		//if (profile.getScore() >= cost) {
		if(profile.score >= cost){
			//click.gold -= cost;
			profile.score -= cost;
			//profile.setScore (profile.getScore () - cost);
			count++;
			cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, count));

		}
	}
}
