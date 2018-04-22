using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GoalType{Your,Enemy}
public class BallCheck : MonoBehaviour {

	Vector3 newBallVelocity = new Vector3(0,0,0);
	public GoalType type;
	//Make a goal
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Ball"){
			if(type == GoalType.Your)
				GameManager.Instance.EnemyGoal();
			else if(type == GoalType.Enemy)
				GameManager.Instance.Goal();
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Ball"){
			other.transform.position = GameManager.Instance.ballStartPosition.position;
			GameManager.Instance.ballRB.velocity = newBallVelocity;
			GameManager.Instance.ballRB.angularVelocity = 0;
		}
	}
}
