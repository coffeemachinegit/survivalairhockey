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
	private void Start () {
		PlayerRotation refer = GetComponentInChildren<PlayerRotation> ();
		direction = refer.direction;
		distance = refer.distance;
	}
	private void Update () {
		if (distance <= 2) {
			if (Input.GetKey ("Fire")) {
				Shoot(ball,direction);
			}
		}
	}
	void Shoot (Rigidbody2D ball, Vector2 dirToShoot) {
		if (ball.velocity.sqrMagnitude == 0)
			ball.AddForce (dirToShoot * _force, ForceMode2D.Impulse);
	}
}