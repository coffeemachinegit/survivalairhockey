using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody2D rigidbody2D;
	private 

	// Use this for initialization
	void Awake () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Rigidbody2D otherRb = other.gameObject.GetComponent<Rigidbody2D>();
		// if(otherRb != null)
		// {
		//		rigidbody2D.velocity = otherRb.velocity * 1.2f;
		// }
		print("BALL");
	}
}
