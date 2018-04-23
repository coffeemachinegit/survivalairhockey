using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {
	



	// Update is called once per frame
	void Update () {

		if(!GameManager.Instance.canPlay)
		{
			Cursor.visible = true;
			return;
		}
		else
		{
			Cursor.visible = false;
		}


		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		transform.position = mousePos;
	}
}
