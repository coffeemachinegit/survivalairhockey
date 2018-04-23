using System.Collections;
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
	public AudioSource bgSource;
	public AudioClip endGameWhistle;
	public AudioClip goalAudio;
	public AudioClip enemyGoalAudio;

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
		source.PlayOneShot(goalAudio);
		score++;
		UIManager.Instance.ChangeScore(score,enemy_score);
	}
	public void EnemyGoal(){
		source.PlayOneShot(enemyGoalAudio);
		enemy_score++;
		UIManager.Instance.ChangeScore(score,enemy_score);
	}

	public void Score(int value){
		kill_monster_score += value;
	}
	public void GameOver(){
		source.volume = 0.4f;
		source.PlayOneShot(endGameWhistle);
		ballRB.velocity = Vector2.zero;
		ballPosition.rotation = Quaternion.identity;
		UIManager.Instance.ShowInsertName();
		canPlay = false;
		finalScore = (int) ((((score - enemy_score)*0.7f) + (SurvivalManager.Instance.survivalTime * 0.3f))+(float)kill_monster_score);
	}

	public void ReloadGame(){
		SceneManager.LoadScene("GameScene");
	}

	


}
