using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	/* Скрипт для скролла
	 * Добавлять его надо на триггер
	 * В cubes добавить панель с предметами, которые будут скроллить
	 * Послушать Сидоджи
	*/

	public GameObject cubes;
	private Vector3  screenPoint, offset;
	private float lockedYPos;

	void Update(){
		if (cubes.transform.position.x > -5f)
			cubes.transform.position = Vector3.MoveTowards (cubes.transform.position, new Vector3 (3f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
		else if(cubes.transform.position.x < -5f)
			cubes.transform.position = Vector3.MoveTowards (cubes.transform.position, new Vector3 (-5f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
	}

	void OnMouseDown(){
		lockedYPos = screenPoint.x;
		offset = cubes.transform.position - Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Cursor.visible = false;

	}


	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		curPosition.y = lockedYPos;
		cubes.transform.position = curPosition;
	}

	void OnMouseUp(){
		Cursor.visible = true;
	}


}
