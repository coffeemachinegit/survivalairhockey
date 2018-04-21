using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;
public class PlayerManager : Singleton<PlayerManager> {

	public GameObject player;
	public PlayerStats playerStats;

	protected override void Awake() {
		IsPersistentBetweenScenes = false;
		base.Awake();
		playerStats = player.GetComponent<PlayerStats>();
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
