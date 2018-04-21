using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	GameObject player;
	PlayerStats playerStats;

	private void Awake() {
		playerStats = player.getComponenet<PlayerStats>();
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
