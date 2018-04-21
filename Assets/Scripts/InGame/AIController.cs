using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	[SerializeField]private Rigidbody2D _ballPosition;
	[SerializeField]private float _speed = 10f; // 10m/s 
	[SerializeField]private float _minDistance = .5f;
	[SerializeField]private Transform _goalTransform;
	private Rigidbody2D _rigidbody2D;
	private Vector2 _goalPosition;

	// Use this for initialization
	void Awake () {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		// _goalPosition = new Vector2(_goalTransform.position.x, _goalTransform.position.y);
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Distance between the target and the enemy
		float distance = (_ballPosition.position - _rigidbody2D.position).magnitude;

		// Movement direction
		Vector2 dir = (_ballPosition.position - _rigidbody2D.position).normalized;
		Vector2 deltaPos = dir * _speed * Time.deltaTime;

		// Vector2 temp = (_ballPosition.position - _goalPosition).normalized;


		// If it is too close, stop!
		if(distance <= _minDistance)
			return;

		// Move!
		_rigidbody2D.position += deltaPos;
	}

}
