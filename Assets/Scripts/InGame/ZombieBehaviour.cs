using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {


	[SerializeField] private AudioClip _clipAttack;
	[SerializeField] private AudioClip _clipWalk;
	[SerializeField] private AudioClip _clipSpawn;
	[SerializeField] private float _damage;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private SpriteRenderer _playerSpriteRenderer;


	private FollowMovement _movement;
	private bool _isPlaying = false;


	void Awake()
	{
		_audioSource = GetComponentInChildren<AudioSource>();
		_movement = GetComponent<FollowMovement>();
	}

	void Update()
	{
		if(!_movement.canMove)
		{
			PlayerManager.Instance.TakeDamage(_damage * Time.deltaTime);
			float pingPong = Mathf.PingPong(Time.time, 1);
         	Color color = Color.Lerp(Color.white, Color.red, pingPong);
			_playerSpriteRenderer.color = color;
			if(!_isPlaying)
			{
				_isPlaying = true;
				_audioSource.loop = true;
				_audioSource.clip = _clipAttack;
				_audioSource.Play();
			}
		}
		else
		{
			_isPlaying = false;
		}
	}

	void OnEnable()
	{
		_audioSource.loop = false;
		_audioSource.clip = _clipSpawn;
		_audioSource.volume = .3f;
		_audioSource.Play();
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			_audioSource.loop = true;
			_audioSource.clip = _clipWalk;
			_audioSource.Play();
		}
	}
}
