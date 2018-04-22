using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager> {

	public bool canPlay = false;
	public int score = 0;
	public int enemy_score = 0;

	public float finalScore = 0f;

	public Transform ballStartPosition; //The center of the map
	public GameObject ball;
	public Transform ballPosition;
	public Rigidbody2D ballRB;

	protected override void Awake() {
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

	public void Score(float value){
		finalScore += value;
	}

	public void GameOver(){
		//Digite seu nome
		finalScore +=(int) (((score - enemy_score)*0.7f) + (SurvivalManager.Instance.survivalTime * 0.3f));
		//salvar e Mostrar o leaderboard
		Debug.Log("Final Score"+finalScore);
		SceneManager.LoadScene("GameScene");
	}

	


}
