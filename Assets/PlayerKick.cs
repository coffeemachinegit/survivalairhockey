using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour {

	Vector3 direction;
	float distance;
	[SerializeField]
	private Rigidbody2D ball;
	[SerializeField]
	private float _force;

	PlayerRotation refer;
	private void Start () {
		refer = GetComponentInChildren<PlayerRotation> ();

	}
	private void Update () {
		direction = refer.direction;
		distance = refer.distance;
		if (distance <= 0.5) {
			if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Joystick1Button0)) {
				Shoot (ball, direction);
			}
		}
	}
	void Shoot (Rigidbody2D ball, Vector2 dirToShoot) {
		ball.AddForce (dirToShoot * _force, ForceMode2D.Impulse);
	}
}