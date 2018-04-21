using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	[SerializeField]private Rigidbody2D _ballRigidbody;
	[SerializeField]private Transform _goalTransform;
	private Rigidbody2D _rigidbody2D;
	private Vector2 _goalPosition;
	private Movement _movement;

	// Use this for initialization
	void Awake () {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_goalPosition = new Vector2(_goalTransform.position.x, _goalTransform.position.y);
		_movement = GetComponent<Movement>();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if(_movement.isCoroutineRunning || _ballRigidbody.position.x > 0)
			return;

		// Direction opposite to the goal
		Vector2 temp = (_ballRigidbody.position - _goalPosition).normalized * 0.5f;

		// Position to be
		Vector2 finalPos = temp + _ballRigidbody.position;

		Debug.DrawLine(_rigidbody2D.position, _goalPosition, Color.green);

		_movement.Move(finalPos, _ballRigidbody, (_goalPosition - _ballRigidbody.position).normalized);
	}

}
