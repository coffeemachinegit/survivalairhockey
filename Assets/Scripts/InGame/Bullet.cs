using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private float _speed = 10f; //10m/s
	[SerializeField] private int _bulletDamage = 1;				// 1 damage
	private Rigidbody2D _rigidbody2d;
	private float offset = 1f; 					// 1 unit out

	// Use this for initialization
	void Awake () {
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		if(IsOutOfBounds())
			gameObject.SetActive(false);
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move();
	}

	void Move()
	{
		Vector2 right = new Vector2(transform.right.x, transform.right.y);
		_rigidbody2d.position += right * _speed * Time.fixedDeltaTime;
	}

	bool IsOutOfBounds()
	{
		if(_rigidbody2d.position.x >= CameraUtil.halfScreenWidthInWorldUnits + offset || _rigidbody2d.position.x <= -CameraUtil.halfScreenWidthInWorldUnits - offset)
			return true;

		if(_rigidbody2d.position.y >= CameraUtil.halfScreenHeightInWorldUnits + offset || _rigidbody2d.position.y <= -CameraUtil.halfScreenHeightInWorldUnits - offset)
			return true;

		return false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			PlayerManager.Instance.TakeDamage(_bulletDamage);

			// Player takes damage
			gameObject.SetActive(false);
		}

	}
}
