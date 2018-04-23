using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxFalling : MonoBehaviour {

	private Animator parachute;
	public GameObject smoke, item;

	

	private void Start () {
		parachute = GetComponentInChildren<Animator> ();
		
		smoke.SetActive (false);
		item.SetActive (false);
	}
	private void OnEnable () {
		smoke.SetActive (false);
		item.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		if (parachute.GetCurrentAnimatorStateInfo (0).IsName ("Stop")) {
			smoke.SetActive (true);
			gameObject.SetActive (false);
			

		}
	}
}