using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFadeAlpha : MonoBehaviour {

	[SerializeField] private CanvasGroup _canvasGroup;
	private bool _playerIsIn, _ballIsIn;

	// Use this for initialization
	void Start () {
		
	}

	void Update()
	{
		if(_playerIsIn || _ballIsIn)
		{
			_canvasGroup.alpha = 0.2f;
		}
		else
		{
			_canvasGroup.alpha = 1f;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			_playerIsIn = true;
		}else if(other.CompareTag("Ball"))
		{
			_ballIsIn = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			_playerIsIn = false;
		}
		else if(other.CompareTag("Ball"))
		{
			_ballIsIn = false;
		}
	}
}
