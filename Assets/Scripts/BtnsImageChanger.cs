using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnsImageChanger : MonoBehaviour {

	int count;
	public Button targetButton;
	public Sprite stanardImage;
	public Sprite foodDamage1;
	public Sprite foodDamage2;
	public Sprite foodDamage3;
	public Sprite foodDamage4;

	public Sprite stanardImage_anim;
	public Sprite foodDamage1_anim;
	public Sprite foodDamage2_anim;
	public Sprite foodDamage3_anim;
	public Sprite foodDamage4_anim;

	void Start(){
		targetButton.GetComponent<Image> ().sprite = stanardImage;
	}

	void Update(){
		if (count <= 10) {
			targetButton.GetComponent<Image> ().sprite = stanardImage;
		} else if (count > 10 && count <= 20) {
			targetButton.GetComponent<Image> ().sprite = foodDamage1;
		}else if (count > 20 && count <= 35) {
			targetButton.GetComponent<Image> ().sprite = foodDamage2;
		}else if (count > 35 && count <= 45) {
			targetButton.GetComponent<Image> ().sprite = foodDamage3;
		}else if (count >= 45) {
			targetButton.GetComponent<Image> ().sprite = foodDamage4;
		}
	}

	public void plusClick(){
		count++;
		}



}
