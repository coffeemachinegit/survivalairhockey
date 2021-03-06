﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
	public Transform ballPostion;
	public float lookRadious, _rotationSpeed = 5f;
	public Vector3 direction;
	public float angle, distance;

	Quaternion rotation;
	// Use this for initialization
	// Update is called once per frame

	private void Start() {
		if(gameObject.name == "PlayerImage"){
			lookRadious = Mathf.Infinity;
		}else if(gameObject.name == "GoalKeeperImage"){
			ballPostion = GameManager.Instance.ball.transform;
		}
		else
			ballPostion = PlayerManager.Instance.playerTransform;
	}
	void Update () {
		if(!GameManager.Instance.canPlay)
			return;

		distance = Vector3.Distance (transform.position, ballPostion.position);
		if (distance <= lookRadious) {
			if(gameObject.name == "PlayerImage")
				direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
			else
				direction = (ballPostion.position - transform.position).normalized;
			angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = GenerateRotation ();
		} else {
			if (transform.rotation.z > 0 || transform.rotation.z < 0) {
				direction.Set (transform.rotation.x, transform.rotation.y, 0);
				rotation = Quaternion.identity;
				transform.rotation = GenerateRotation ();
			}
			return;
		}
	}

	Quaternion GenerateRotation () {
		return Quaternion.Slerp (transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
	}
}