using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForParticle : MonoBehaviour {
	private ParticleSystem ps;

	public GameObject item;
	// Use this for initialization
	void Start () {
		
		ps = this.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!ps.isEmitting){
			item.SetActive (true);
		}
	}
}
