using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {
	public LayerMask touchInputMask;
	private List<GameObject> touchList = new List<GameObject> ();
	private GameObject[] touchesOld;
	private RaycastHit hit;
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR 
		if(Input.GetMouseButton(0) ||Input.GetMouseButtonDown(0)||Input.GetMouseButtonUp(0) ){

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchesOld);
			touchList.Clear ();
		
				Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);


				if (Physics.Raycast (ray, out hit, touchInputMask)) {
					GameObject recep = hit.transform.gameObject;
					touchList.Add (recep);
				if (Input.GetMouseButtonDown(0)) {
						recep.SendMessage ("OnTouchDOwn", hit.point, SendMessageOptions.DontRequireReceiver);
					}
				if (Input.GetMouseButtonUp(0)) {
						recep.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
					}
				if (Input.GetMouseButton(0)) {
						recep.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
					}
				}
			
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains (g)) {
					g.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
#endif
		if(Input.touchCount > 0){

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchesOld);
			touchList.Clear ();

		foreach (Touch touch in Input.touches) {
			Ray ray = GetComponent<Camera>().ScreenPointToRay (touch.position);
		

			if (Physics.Raycast (ray, out hit, touchInputMask)) {
				GameObject recep = hit.transform.gameObject;
					touchList.Add (recep);
				if (touch.phase == TouchPhase.Began) {
					recep.SendMessage ("OnTouchDOwn", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Ended) {
					recep.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Stationary ||touch.phase == TouchPhase.Moved) {
					recep.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Canceled) {
					recep.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains (g)) {
					g.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
