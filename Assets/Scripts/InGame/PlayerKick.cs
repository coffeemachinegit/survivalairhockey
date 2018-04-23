using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour {

	Vector3 direction;
	float distance;
	private Rigidbody2D ball;

	private PlayerAnimation animation;
	[SerializeField]
	private float maxDistance = 1f;
	[SerializeField] private float _forceMax;

	public AudioSource source;
	public AudioClip kick;

	PlayerRotation refer;
	bool canKick = false;
	private void Start () {
		animation = GetComponent<PlayerAnimation> ();
		ball = GameManager.Instance.ball.GetComponent<Rigidbody2D> ();
		refer = GetComponent<PlayerRotation> ();

	}
	private void Update () {
		if(!GameManager.Instance.canPlay)
			return;

		animation.KickAnimation (false);
		direction = refer.direction;
		distance = refer.distance;
		if (canKick) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Joystick1Button0) || Input.GetMouseButtonDown (0)) {
				source.PlayOneShot (kick);
				Shoot (ball, direction);
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.transform.name == "Ball") {
			canKick = true;
		}
	}
	private void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.transform.name == "Ball") {
			canKick = false;
		}
	}
	void Shoot (Rigidbody2D ball, Vector2 dirToShoot) {
		animation.KickAnimation (true);
		ball.AddForce (dirToShoot * _forceMax, ForceMode2D.Impulse);
	}
}