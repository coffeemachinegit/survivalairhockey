using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour {

	[SerializeField] private float _fireRate = 1f; 	// 1 second for each shot
	[SerializeField] private float _distanceToShoot;
	[SerializeField] private Transform _transformToShoot;
	[SerializeField] private ObjectPool _pool;
	[SerializeField] private Transform[] _shootPositions;
	[SerializeField] private AudioClip _shotClip;
	[SerializeField] private Smoke _smokeLeft, _smokeRight;
	
	private AudioSource _audioSource = null;

	private float _time;
	private float _nextTimeToShoot;
	void Awake()
	{
		_nextTimeToShoot = Time.timeSinceLevelLoad + _fireRate;
		_time = 0f;
		_audioSource = GetComponent<AudioSource>();
		_pool = GameObject.Find("BulletPool").GetComponent<ObjectPool>();
	}

	private void Start() {
		_transformToShoot = PlayerManager.Instance.playerTransform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_time += Time.deltaTime;
		if(_time >= _nextTimeToShoot)
		{
			float dist = (transform.position - _transformToShoot.position).magnitude;
			if(dist <= _distanceToShoot)
			{
				Shoot();
				_nextTimeToShoot = Time.timeSinceLevelLoad + Random.Range(_fireRate, _fireRate + 2f);
			}
		}
	}

	void Shoot()
	{
		int index = Random.Range(0, _shootPositions.Length);
		Vector2 position = _shootPositions[index].position;

		print("SHOOT!");
		GameObject bullet = _pool.GetPooledObject();
		bullet.transform.position = position;
		bullet.transform.rotation = transform.rotation;
		bullet.SetActive(true);
		_audioSource.PlayOneShot(_shotClip);
	}
}
