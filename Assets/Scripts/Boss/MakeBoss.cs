using UnityEngine;
using System.Collections;
using UnityEditor;
public class MakeBoss {

	[MenuItem("Assets/Create/Boss Object")]
	public static void Create()
	{
		BossObject asset = ScriptableObject.CreateInstance<BossObject> ();
		AssetDatabase.CreateAsset (asset, "Assets/Bosses/NewBoss.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}

}