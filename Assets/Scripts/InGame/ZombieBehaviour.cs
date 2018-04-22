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
	private bool _isPlayingAttack = false, _isPlayingWalk = false;


	void Awake()
	{
		_audioSource = GetComponentInChildren<AudioSource>();
		_movement = GetComponent<FollowMovement>();
		_playerSpriteRenderer = GameObject.Find("Player").GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{
		if(!GameManager.Instance.canPlay){
			_audioSource.Stop();
			return;
		}

		if(!_movement.canMove)
		{
			_isPlayingWalk = false;
			PlayerManager.Instance.TakeDamage(_damage * Time.deltaTime);
			
			// Change color
			float pingPong = Mathf.PingPong(Time.time, .5f);
         	Color color = Color.Lerp(Color.white, Color.red, pingPong);
			_playerSpriteRenderer.color = color;
			
			if(!_isPlayingAttack)
			{
				_isPlayingAttack = true;
				_audioSource.loop = true;
				_audioSource.clip = _clipAttack;
				_audioSource.Play();
			}
		}
		else
		{
			_playerSpriteRenderer.color = Color.white;
			_isPlayingAttack = false;
			if(!_isPlayingWalk)
			{
				_isPlayingWalk = true;
				_audioSource.loop = true;
				_audioSource.clip = _clipWalk;
				_audioSource.Play();
			}
		}
	}

	void OnEnable()
	{
		_audioSource.loop = false;
		_audioSource.clip = _clipSpawn;
		_audioSource.volume = .2f;
		_audioSource.Play();
	}


	// void OnTriggerExit2D(Collider2D other)
	// {
	// 	if(other.CompareTag("Player"))
	// 	{
	// 		_audioSource.loop = true;
	// 		_audioSource.clip = _clipWalk;
	// 		_audioSource.Play();
	// 	}
	// }
}
