using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour {

	public Text itemInfo;
	public PlayerProfile click;
	public long cost;
	public long tickValue;
	public long tickAll;
	public int count;
	public float bstXp;
	public float baseXp;
	public string itemName;
	private long baseCost;
	public Color affordable;
	public Color standard;
	public GameObject imageOpen;

	public string itmName;
	public string itmNamexp;
	public string itmNameTick;

	string loadCost;
	string loadTick;

	string ptest;

	void Awake(){
		LoadItm ();
		ptest = tickValue.ToString ();
		//click.boostScore = int.Parse(ptest);
	}

	void Start(){
		baseCost = cost;
		baseXp = bstXp;
		print (tickAll);
		//LoadItm ();
	}

	void Update(){
		itemInfo.text = itemName + "\nCost: " + cost + "pts";

		if (click.score >= cost) {
			//GetComponent<Image> ().color = affordable;
			GetComponent<Button>().interactable = true;
		} else {
			//GetComponent<Image> ().color = standard;
			GetComponent<Button>().interactable = false;
		}
		SaveItm ();
	}

	public void PurchaseItem(){
		if (click.score >= cost) {
			
			click.score -= cost;
			count++;
			tickValue += tickValue;
			//bstXp += bstXp;
			//cost = (long)Mathf.Round(baseCost * Mathf.Pow(1.15f, count));
			cost = (long)Mathf.Round(baseCost * Mathf.Pow(2f, count));
			click.boostScore += (int)tickValue;
			//click.boostXP += bstXp;
			SaveItm ();


		}
	}

	void SaveItm(){
			PlayerPrefs.SetString (itmName, cost.ToString());
			PlayerPrefs.SetString (itmNameTick, tickValue.ToString());
			PlayerPrefs.SetFloat (itmNamexp, bstXp);
			PlayerPrefs.Save ();
	}

	void LoadItm(){
		loadCost = PlayerPrefs.GetString (itmName);
		loadTick = PlayerPrefs.GetString (itmNameTick);

		if (!PlayerPrefs.HasKey (itmName) && !PlayerPrefs.HasKey (itmNameTick)) {
			PlayerPrefs.SetString (itmName, cost.ToString());
			PlayerPrefs.SetString (itmNameTick, tickValue.ToString());
		} else {
			cost = long.Parse (loadCost);
			tickValue = long.Parse (loadTick);

				
		}


		bstXp = PlayerPrefs.GetFloat (itmNamexp);
	}
	
}
