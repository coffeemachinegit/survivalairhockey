using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperAI : MonoBehaviour {

	private Transform ballTransform;

	private float deltaX;
	private bool ballCatch = false;
	
	public float speed;
	public float yTop,yDown;

	private Vector2 newPos;
	private Vector3 nullVelocity = new Vector3(0,0,0);

	public PlayerRotation rotation;
	public Transform playerGoal;
	public Transform ballPoss;

	public Animator animator;

	
	void Start () {
		ballTransform = GameManager.Instance.ballPosition;
		newPos = new Vector2(transform.position.x,0);
	}
	
	
	void Update () {
		if(!GameManager.Instance.canPlay)
			return;
			
		deltaX = ballTransform.position.x - gameObject.transform.position.x;
		if(deltaX < 5 && !ballCatch){
			newPos.y = Mathf.Clamp(ballTransform.position.y,yDown,yTop);
			animator.SetBool("isWalking",true);
			transform.position = Vector2.MoveTowards(transform.position,newPos,speed * Time.deltaTime);
		}else
			animator.SetBool("isWalking",false);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(!GameManager.Instance.canPlay)
			return;

		if(other.gameObject.tag == "Ball"){
			if(Random.Range(0,2) == 1){
				ballCatch = true;
				GameManager.Instance.ballRB.velocity = nullVelocity;
				GameManager.Instance.ballPosition.localRotation = Quaternion.identity;
				other.gameObject.transform.SetParent(gameObject.transform);
				rotation.ballPostion = playerGoal;
				other.gameObject.transform.position = ballPoss.position;
				StartCoroutine(KickBall(other.gameObject));
			}
		}
	}
	
	IEnumerator KickBall(GameObject ball){
		yield return new WaitForSeconds(1);
		Vector2 newVelocity = new Vector2(Random.Range(-5,-11),Random.Range(-11,12));
		ball.transform.SetParent(null);
		GameManager.Instance.ballRB.AddForce(newVelocity,ForceMode2D.Impulse);
		rotation.ballPostion = ball.transform;
		ballCatch = false;

	}
}
