using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour {

	public AudioSource source;
	public AudioClip bounce;

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Campo"){
			source.PlayOneShot(bounce);
		}
	}
}
