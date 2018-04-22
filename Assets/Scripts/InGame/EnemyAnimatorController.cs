using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour {

	[SerializeField] private FollowMovement _movement;
	private Animator _anim;

	void Awake()
	{
		_anim = GetComponent<Animator>();
	}


	void Update()
	{
		_anim.SetBool("isWalking", _movement.canMove);
	}
}
