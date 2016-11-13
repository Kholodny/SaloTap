/*using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeWeaponObject 
{
	[MenuItem("Assets/Create/Weapon Object")]
	public static void Create()
	{
		BoostObject asset = ScriptableObject.CreateInstance<BoostObject> ();
		AssetDatabase.CreateAsset (asset, "Assets/ShopItems/BoostItems/NewBoostObject.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}

}*/