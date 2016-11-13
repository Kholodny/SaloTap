using UnityEngine;
using System.Collections;
using System.Xml;

public class Saver : MonoBehaviour {
	private PlayerProfile plr;

	void Awake(){
		plr = FindObjectOfType<PlayerProfile> ();
	}

	public void SaveGame(){
		XmlDocument xmlDoc = new XmlDocument ();
		XmlNode rootNod = xmlDoc.CreateElement ("Information");
		xmlDoc.AppendChild (rootNod);

		XmlNode userNode;

		userNode = xmlDoc.CreateElement ("Score");
		userNode.InnerText = plr.score.ToString ();
		rootNod.AppendChild (userNode);

		xmlDoc.Save ("Data/anal.xml");
	}

	public void LoadGame(){
		
	}
}
