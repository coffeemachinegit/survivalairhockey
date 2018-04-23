using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;

public class SurvivalManager : Singleton<SurvivalManager> {

	public float hungryMultiplier,thirstMultiplier; //The multipliers used to drain status

	public float hungryStart,thirstStart,hungryNew,thirstNew;
	public float survivalTime;
	
	float time; //Time to use in the drain function
	
	protected override void Awake(){
		IsPersistentBetweenScenes = false;
		base.Awake();
	}
	private void Start() {
		PlayerManager.Instance.playerStats.Hungry = 100;
		PlayerManager.Instance.playerStats.Thirst = 100;
		hungryMultiplier = 2f;
		hungryStart = hungryMultiplier;
		thirstMultiplier = 2f;
		thirstStart = thirstMultiplier;
		hungryNew = 3f;
		thirstNew = 4f;
	}

	private void Update() {
		if(!GameManager.Instance.canPlay)
			return;

		survivalTime+= 1 * Time.deltaTime;
		if(GameManager.Instance.canPlay){
			time = Time.deltaTime;
			DrainStatus("hungry");
			DrainStatus("thirst");
			CheckStatus();
		}
	}

	/*
	 * Drain player status based on a flag
	 */
	void DrainStatus(string flag){
		if(flag == "hungry" && PlayerManager.Instance.playerStats.Hungry > 0){
			PlayerManager.Instance.playerStats.Hungry -= hungryMultiplier * time;
			UIManager.Instance.UpdateSliderValue(flag,PlayerManager.Instance.playerStats.Hungry);
		}else if(flag == "thirst" && PlayerManager.Instance.playerStats.Thirst > 0){
			PlayerManager.Instance.playerStats.Thirst -= thirstMultiplier * time;
			UIManager.Instance.UpdateSliderValue(flag,PlayerManager.Instance.playerStats.Thirst);
		}
		if(PlayerManager.Instance.playerStats.Hungry < 0){
			PlayerManager.Instance.playerStats.Hungry = 0;
		}
		if(PlayerManager.Instance.playerStats.Thirst < 0){
			PlayerManager.Instance.playerStats.Thirst = 0;
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
			if(PlayerManager.Instance.playerStats.Thirst+value < 100)
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
		if(PlayerManager.Instance.playerStats.Hungry <= 0){
			PlayerManager.Instance.TakeDamage(1*Time.deltaTime);
		}
		if(PlayerManager.Instance.playerStats.Thirst <= 0){
			PlayerManager.Instance.TakeDamage(1*Time.deltaTime);
		}
	}

	public void ChangeMultiplier(bool flag){
		//Coloca o modificador maior
		if(flag){
			thirstMultiplier = thirstNew;
		}//Volta aos valores normais
		else{
			thirstMultiplier = thirstStart;
		}
		
	}



}
