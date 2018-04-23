using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour {

	private Rigidbody2D _rigidbody2d;
	[SerializeField] private Transform _transformToFollow;
	[SerializeField] private float _speed = 2f;
	[SerializeField] private float _distToStop;
	[SerializeField] private bool _canMove;

	public bool canMove { get { return _canMove; }}

	// Use this for initialization
	void Awake () {
		_rigidbody2d = GetComponent<Rigidbody2D>();
		_canMove = true;
	}

	private void Start() {
		_transformToFollow = PlayerManager.Instance.playerTransform;
	}

	void Update()
	{
		_rigidbody2d.velocity = Vector2.zero;
		float dist = (transform.position - _transformToFollow.position).magnitude;
		_canMove = dist >= _distToStop ? true : false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(!GameManager.Instance.canPlay)
			return;

		if(_canMove)
			Move(_transformToFollow.position);
	}

	void Move(Vector2 target)
	{
		_rigidbody2d.position = Vector2.MoveTowards(_rigidbody2d.position, target, _speed * Time.deltaTime);
	}
}
