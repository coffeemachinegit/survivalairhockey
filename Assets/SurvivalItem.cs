using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{Food,Liquid}

public class SurvivalItem : MonoBehaviour {

	public int value;
	public ItemType type;

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			if(type == ItemType.Food){
				PlayerManager.Instance.playerStats.Hungry += value;
			}else{
				PlayerManager.Instance.playerStats.Thirst += value;
			}
		}
		gameObject.SetActive(false);
	}
}
