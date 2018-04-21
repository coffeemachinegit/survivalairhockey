using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;

public class SurvivalManager : Singleton<SurvivalManager> {

	public float hungryMultiplier,thirstMultiplier; //The multipliers used to drain status
	
	float time; //Time to use in the drain function
	

	private void Start() {
		PlayerManager.Instance.playerStats.Hungry = 100;
		PlayerManager.Instance.playerStats.Thirst = 100;
		hungryMultiplier = 2f;
		thirstMultiplier = 2f;
	}

	private void Update() {
		time = Time.deltaTime;
		DrainStatus("hungry");
		DrainStatus("thrist");
		CheckStatus();
	}

	/*
	 * Drain player status based on a flag
	 */
	void DrainStatus(string flag){
		if(flag == "hungry"){
			PlayerManager.Instance.playerStats.Hungry -= hungryMultiplier * time;
			UIManager.Instance.UpdateSliderValue("hungry",PlayerManager.Instance.playerStats.Hungry);
		}else{
			PlayerManager.Instance.playerStats.Thirst -= thirstMultiplier * time;
			UIManager.Instance.UpdateSliderValue("thirst",PlayerManager.Instance.playerStats.Thirst);
		}
	}

	/*
	 * Add a value to a status (used by items)
	 * This function made a automatic check if the status go above 100
	 */
	public void AddStatus(string flag, int value){
		if(flag == "hungry"){
			if(PlayerManager.Instance.playerStats.Hungry+value < 100)
				PlayerManager.Instance.playerStats.Hungry += value;
			else
				PlayerManager.Instance.playerStats.Hungry = 100;
			UIManager.Instance.UpdateSliderValue("hungry",PlayerManager.Instance.playerStats.Hungry);
		}else{
			if(PlayerManager.Instance.playerStats.Hungry+value < 100)
				PlayerManager.Instance.playerStats.Thirst += value;
			else
				PlayerManager.Instance.playerStats.Thirst = 100;
			UIManager.Instance.UpdateSliderValue("thirst",PlayerManager.Instance.playerStats.Thirst);
		}
	}

	/*
	 * check if the game ended
	 */
	public void CheckStatus(){
		if(PlayerManager.Instance.playerStats.Hungry <= 0 || PlayerManager.Instance.playerStats.Thirst <= 0){
			Debug.Log("EndGame");
		}
	}



}
