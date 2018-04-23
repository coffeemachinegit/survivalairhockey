using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour {

	public AudioSource source;
	public AudioClip bounce;
	public AudioClip block;

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Campo"){
			source.PlayOneShot(bounce);
		}if(other.gameObject.tag == "Trave"){
			source.PlayOneShot(block);
		}
	}
}
