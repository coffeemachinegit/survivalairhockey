﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager> {

	public bool canPlay = false;
	public int score = 0;

	public int nZombie,nShooter,nItem;
	public int enemy_score = 0;
	public int kill_monster_score = 0;
	public float finalScore = 0f;

	public Transform ballStartPosition; //The center of the map
	public GameObject ball;
	public Transform ballPosition;
	public Rigidbody2D ballRB;
	public string playerName;

	public AudioSource source;
	public AudioClip endGameWhistle;

	protected override void Awake() {
		nZombie = 0;
		nShooter = 0;
		nItem = 0;
		IsPersistentBetweenScenes = false;
		ballPosition = ball.transform;
		ballRB = ball.GetComponent<Rigidbody2D>();
		base.Awake();
	}

	public void Goal(){
		score++;
		UIManager.Instance.ChangeScore(score,enemy_score);
	}
	public void EnemyGoal(){
		enemy_score++;
		UIManager.Instance.ChangeScore(score,enemy_score);
	}

	public void Score(int value){
		kill_monster_score += value;
	}
	public void GameOver(){
		source.PlayOneShot(endGameWhistle);
		UIManager.Instance.ShowInsertName();
		canPlay = false;
		finalScore = (int) ((((score - enemy_score)*0.7f) + (SurvivalManager.Instance.survivalTime * 0.3f))+(float)kill_monster_score);
	}

	public void ReloadGame(){
		SceneManager.LoadScene("GameScene");
	}

	


}
