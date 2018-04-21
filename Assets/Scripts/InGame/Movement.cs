using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField]private float _speed = 10f; // 10m/s
	[SerializeField]private float _force = 10f; 
	private Rigidbody2D _rigidbody2D;
	private bool _isCoroutineRunning;

	public bool isCoroutineRunning{get{return _isCoroutineRunning;}}

	// Use this for initialization
	void Awake () {
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public void Move(Vector2 destination, Rigidbody2D ball, Vector2 dirToShoot)
	{
		Vector2 direction = (destination - _rigidbody2D.position).normalized;
		_rigidbody2D.position = Vector2.MoveTowards(_rigidbody2D.position, destination, _speed * Time.deltaTime);

		if(_rigidbody2D.position == destination){
			StartCoroutine(Shoot(ball, dirToShoot));
		}
	}

	IEnumerator Shoot(Rigidbody2D ball, Vector2 dirToShoot)
	{
		_isCoroutineRunning = true;
		yield return new WaitForSeconds(.3f);
		if(ball.velocity.sqrMagnitude == 0)
			ball.AddForce(dirToShoot * _force, ForceMode2D.Impulse);
		_isCoroutineRunning = false;
	}
}
