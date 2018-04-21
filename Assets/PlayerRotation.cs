using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
	public Transform ballPostion;
	public float lookRadious;
	Vector3 direction;
	float angle, distance;
	Quaternion rotation;
	// Use this for initialization
	// Update is called once per frame
	public void UpdateRotation () {
		distance = Vector3.Distance (transform.position, ballPostion.position);
		if (distance <= lookRadious) {
			direction = (ballPostion.position - transform.position).normalized;
			angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = GenerateRotation();
		} else {
			direction.Set(transform.rotation.x,transform.rotation.y,0);
			rotation = Quaternion.LookRotation(direction);
			transform.rotation = GenerateRotation();
			return;
		}
	}

	Quaternion GenerateRotation(){
		return Quaternion.Slerp(transform.rotation,rotation,5f * Time.deltaTime);
	}
}