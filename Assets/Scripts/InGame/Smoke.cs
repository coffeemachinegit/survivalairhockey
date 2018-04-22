using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

	[SerializeField] private SpriteRenderer _renderer;

	private Color initialColor;
	private Vector3 initialScale;

	private void Awake()
	{
		initialColor = _renderer.color;
		initialScale = _renderer.transform.localScale;
	}

	public IEnumerator Smoking()
	{
		_renderer.color = initialColor;
		_renderer.transform.localScale = initialScale;

		_renderer.gameObject.SetActive(true);

		Color c = _renderer.color;
		Vector3 scale = _renderer.transform.localScale;

		while(_renderer.color.a >= 0)
		{
			c.a -= .1f;
			_renderer.color = c;

			scale *= 1.05f;
			_renderer.transform.localScale = scale;

			yield return new WaitForSeconds(.1f);
		}

		_renderer.gameObject.SetActive(true);
	}
}
