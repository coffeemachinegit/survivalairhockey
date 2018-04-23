using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType { Your, Enemy }
public class BallCheck : MonoBehaviour {

	Vector3 newBallVelocity = new Vector3 (0, 0, 0);
	public GoalType type;

	[SerializeField] private ParticleSystem[] _particleSystems;

	//Make a goal
	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Ball") {
			if (type == GoalType.Your){
				GameManager.Instance.EnemyGoal ();
				ResetBall(other);
			}
			else if (type == GoalType.Enemy) {
				foreach (ParticleSystem particleSystem in _particleSystems)
				{
					particleSystem.Play();
				}
				GameManager.Instance.Goal ();
				ResetBall(other);
			}
		}
	}

	private void ResetBall (Collider2D other) {
		if (other.tag == "Ball") {
			newBallVelocity.x = Random.Range (-4f, 5f);
			newBallVelocity.y = Random.Range (-4f, 5f);
			if (newBallVelocity.x < 0)
				newBallVelocity.z = Random.Range (-4f, 0f);
			else
				newBallVelocity.z = Random.Range (0f, 5f);
			other.transform.position = GameManager.Instance.ballStartPosition.position;
			GameManager.Instance.ballRB.velocity = newBallVelocity;
			GameManager.Instance.ballRB.angularVelocity = 0;
		}
	}
}