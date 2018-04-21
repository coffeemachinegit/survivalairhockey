using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour {

	private Rigidbody2D _rigidbody2d;
	[SerializeField] private Transform _transformToFollow;
	[SerializeField] private float _speed = 2f;

	// Use this for initialization
	void Awake () {
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Move(_transformToFollow.position);
	}

	void Move(Vector2 target)
	{
		_rigidbody2d.position = Vector2.MoveTowards(_rigidbody2d.position, target, _speed * Time.deltaTime);
	}
}
