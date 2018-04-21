using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator playerMove;
	// Use this for initialization
	void Start () {
		playerMove = GetComponent<Animator> ();
	}

	// Update is called once per frame
	public void MovimentAnimation (float x, float y, float speed) {
		playerMove.speed = speed / 10;
		bool xValue = x < 0 || x > 0;
		bool yValue = y < 0 || y > 0;
		if(xValue || yValue){
			playerMove.SetBool("isWalking",true);
		}else{
			playerMove.SetBool("isWalking",false);
		}
	}
}