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
		if(!GameManager.Instance.canPlay){
			_anim.StopPlayback();
			return;
		}

		_anim.SetBool("isWalking", _movement.canMove);
	}
}
