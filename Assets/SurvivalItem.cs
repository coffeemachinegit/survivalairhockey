using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{Food,Liquid}

public class SurvivalItem : MonoBehaviour {

	public int value;
	public ItemType type;

	public AudioClip eat,drink;
	public AudioSource source;

	private void Start() {
		source = GameManager.Instance.source;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			if(type == ItemType.Food){
				SurvivalManager.Instance.AddStatus("hungry",value);
				if(source.isPlaying){
					source.Stop();
					source.Play();
				}
				source.PlayOneShot(eat);
			}else{
				SurvivalManager.Instance.AddStatus(string.Empty,value);
				source.PlayOneShot(drink);
			}
			GameManager.Instance.nItem--;
			gameObject.SetActive(false);
		}
	}
}
