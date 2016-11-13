using UnityEngine;
using System.Collections;

public class CurrencyConverter : MonoBehaviour {

	private static  CurrencyConverter instance;
	public static CurrencyConverter Instance{
		get{
			return instance;
		}
	}

	void Awake(){
		CreateIsntance ();
	}

	void CreateIsntance(){
		if (instance == null) {
			instance = this;
		}
	}

	public string GetCurrencyIntoString(float valueToConvert, bool currencyPerSec, bool currencyPerClick){
		string converted;
		if (valueToConvert >= 1000000000) {
			converted = (valueToConvert / 1000000000f).ToString ("f3") + " Bill";

		} else if (valueToConvert >= 1000000) {
			converted = (valueToConvert / 1000000f).ToString ("f3") + " Mill";

		} else if (valueToConvert >= 1000) {
			converted = (valueToConvert / 1000f).ToString ("f3") + " K";
		} else {
			converted = "" + valueToConvert;
		}


		if (currencyPerSec == true) {
			converted += " gps";
		}

		if (currencyPerClick == true) {
			converted = converted +  " gpc";
		}

		return converted; 
	}

}
