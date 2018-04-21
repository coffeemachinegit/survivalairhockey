using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;
public class PlayerManager : Singleton<PlayerManager> {

	public GameObject player; //The Player
	public PlayerStats playerStats; //The stats

	protected override void Awake() {
		IsPersistentBetweenScenes = false;
		base.Awake();
		playerStats = player.GetComponent<PlayerStats>();
	}
}
