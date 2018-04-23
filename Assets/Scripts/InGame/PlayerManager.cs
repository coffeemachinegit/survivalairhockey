using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;
public class PlayerManager : Singleton<PlayerManager> {

	public GameObject player; //The Player
	public PlayerStats playerStats; //The stats

	public Transform playerTransform;

	protected override void Awake() {
		IsPersistentBetweenScenes = false;
		base.Awake();
		playerStats = player.GetComponent<PlayerStats>();
		playerTransform = player.transform;
	}

	public void TakeDamage(float value){
		if(!GameManager.Instance.canPlay)
			return;
		float realValue = value * playerStats.DamageReceivePercentual;
		playerStats.Hp -= realValue;
		UIManager.Instance.UpdateSliderValue("life",realValue);
		if(playerStats.Hp <= 0){
			GameManager.Instance.GameOver();
		}
		
	}
}
