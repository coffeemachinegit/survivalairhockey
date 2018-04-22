using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBehaviour : MonoBehaviour {

	[SerializeField] private float _fireRate = 1f; // 1 second for each shot
	[SerializeField] private float _distanceToShoot;
	[SerializeField] private Transform _transformToShoot;
	[SerializeField] private ObjectPool _pool;
	[SerializeField] private Transform[] _shootPositions;
	[SerializeField] private AudioClip _shotClip;
	[SerializeField] private Smoke _smokeLeft, _smokeRight;
	[SerializeField] private Slider _healthBarSlider;
	[SerializeField] private int _health = 2;

	private AudioSource _audioSource = null;

	private float _time;
	private float _nextTimeToShoot;
	void Awake () {
		_nextTimeToShoot = Time.timeSinceLevelLoad + _fireRate;
		_time = 0f;
		_audioSource = GetComponent<AudioSource> ();
		_pool = GameObject.Find ("BulletPool").GetComponent<ObjectPool> ();
		_healthBarSlider.maxValue = _health;
		_healthBarSlider.value = _health;
	}

	void Enable () {
		_health = 2;
		_healthBarSlider.maxValue = _health;
		_healthBarSlider.value = _health;
	}

	private void Start () {
		_transformToShoot = PlayerManager.Instance.playerTransform;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < CameraUtil.Ymax && transform.position.y > CameraUtil.Ymin && !GetComponent<Collider2D> ().enabled)
			GetComponent<Collider2D> ().enabled = true;
		if (!GameManager.Instance.canPlay)
			return;

		_time += Time.deltaTime;
		if (_time >= _nextTimeToShoot) {
			float dist = (transform.position - _transformToShoot.position).magnitude;
			if (dist <= _distanceToShoot) {
				if (transform.position.y < CameraUtil.Ymax && transform.position.y > CameraUtil.Ymin) {
					Shoot ();
					_nextTimeToShoot = Time.timeSinceLevelLoad + Random.Range (_fireRate, _fireRate + 2f);
				}
			}
		}
	}

	void Shoot () {
		int index = Random.Range (0, _shootPositions.Length);
		Vector2 position = _shootPositions[index].position;

		StartCoroutine (_shootPositions[index].GetComponentInChildren<Smoke> ().Smoking ());

		print ("SHOOT!");
		GameObject bullet = _pool.GetPooledObject ();
		bullet.transform.position = position;
		bullet.transform.rotation = transform.rotation;
		bullet.SetActive (true);
		_audioSource.PlayOneShot (_shotClip);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.CompareTag ("Ball")) {
			_health--;
			_healthBarSlider.value = _health;
			if (_health == 0) {
				transform.parent.gameObject.SetActive (false);
				GameManager.Instance.nZombie--;
			}
		}
	}

}