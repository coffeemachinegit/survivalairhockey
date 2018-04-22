using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour {

	Vector3 direction;
	float distance;
	private Rigidbody2D ball;
	[SerializeField]
	private float _force,maxDistance=1f;

	PlayerRotation refer;
	private void Start () {
		ball = GameManager.Instance.ball.GetComponent<Rigidbody2D>();
		refer = GetComponentInChildren<PlayerRotation> ();

	}
	private void Update () {
		direction = refer.direction;
		distance = refer.distance;
		if (distance <= maxDistance) {
			if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Joystick1Button0)) {
				Shoot (ball, direction);
			}
		}
	}
	void Shoot (Rigidbody2D ball, Vector2 dirToShoot) {
		ball.AddForce (dirToShoot * _force, ForceMode2D.Impulse);
	}
}