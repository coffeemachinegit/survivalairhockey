using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {


	[SerializeField] private float _damage;
	[SerializeField] private AudioSource _audioSource;

	void Awake()
	{
		_audioSource = GetComponentInChildren<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			_audioSource.Play();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			_audioSource.Stop();
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			PlayerManager.Instance.TakeDamage(_damage * Time.deltaTime);
		}
	}
}
