using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

	[SerializeField] private SpriteRenderer _renderer;
	
	public IEnumerator Smoking()
	{
		_renderer.gameObject.SetActive(true);
		Color c = _renderer.color;
		while(_renderer.color.a >= 0)
		{
			c.a -= .1f;
			_renderer.color = c;
			yield return new WaitForSeconds(.2f);
		}
	}
}
