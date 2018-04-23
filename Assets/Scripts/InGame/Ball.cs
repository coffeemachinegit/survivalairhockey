using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	private float minSpeed = 1f;

	// Use this for initialization
	void Awake () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
}
