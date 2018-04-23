using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour {

	Vector3 direction;
	float distance;
	private Rigidbody2D ball;

	private PlayerAnimation animation;
	[SerializeField]
	private float _force,maxDistance=1f;

	public AudioSource source;
	public AudioClip kick;

	PlayerRotation refer;
	private void Start () {
		animation = GetComponentInChildren<PlayerAnimation>();
		ball = GameManager.Instance.ball.GetComponent<Rigidbody2D>();
		refer = GetComponentInChildren<PlayerRotation> ();

	}
	private void Update () {
		animation.KickAnimation(false);
		direction = refer.direction;
		distance = refer.distance;
		if (distance <= maxDistance) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Joystick1Button0)) {
				source.PlayOneShot(kick);
				Shoot (ball, direction);
			}
		}
	}
	void Shoot (Rigidbody2D ball, Vector2 dirToShoot) {
		animation.KickAnimation(true);
		ball.AddForce (dirToShoot * _force, ForceMode2D.Impulse);
	}
}