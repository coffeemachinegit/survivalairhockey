using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class EnemySpawner : MonoBehaviour {

	ObjectPool enemypool;

	public int maxEnemy, nEnemy,spawnOffset = 2;
	[SerializeField]
	private float timeToSpawn = 1f;

	[SerializeField]
	bool flag = false;

	GameObject enemyToSpawn;
	private void Start () {
		enemypool = GetComponent<ObjectPool> ();
		StartCoroutine ("spawn");
	}
	IEnumerator spawn () {
		while (true) {
			yield return new WaitForSeconds (timeToSpawn);
			if (nEnemy <= maxEnemy) {
				enemyToSpawn = enemypool.GetPooledObject ();
				enemyToSpawn.transform.position = generateRandomCoord ();
				enemyToSpawn.SetActive (true);
				nEnemy++;
			}
		}
	}

	Vector3 generateRandomCoord () {
		if(!flag)
		//Enemies
			return new Vector3 (Random.Range (spawnOffset, CameraUtil.Xmax - spawnOffset), Random.Range (CameraUtil.Ymin + spawnOffset, CameraUtil.Ymax - spawnOffset), 0);
		else
		//Items
			return new Vector3 (Random.Range (CameraUtil.Xmin + spawnOffset, spawnOffset), Random.Range (CameraUtil.Ymin + spawnOffset, CameraUtil.Ymax - spawnOffset), 0);
		
	}
	public void killEnemy (GameObject enemy) {
		nEnemy--;
		enemy.SetActive (false);
	}
}