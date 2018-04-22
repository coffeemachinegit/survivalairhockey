using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class EnemySpawner : MonoBehaviour {

	ObjectPool enemypool;

	public int maxEnemy,nEnemy;
	[SerializeField]
	private float timeToSpawn = 1f;

	GameObject enemyToSpawn;
	private void Start () {
		enemypool = GetComponent<ObjectPool> ();
		StartCoroutine ("spawn");
	}
	IEnumerator spawn () {
		yield return new WaitForSeconds (timeToSpawn);
		if (nEnemy <= maxEnemy) {
			enemyToSpawn = enemypool.GetPooledObject ();
			enemyToSpawn.transform.position = generateRandomCoord ();
			enemyToSpawn.SetActive (true);
			nEnemy++;
		} 
	}

	Vector3 generateRandomCoord () {
		return new Vector3 (Random.Range (CameraUtil.Xmin / 2, CameraUtil.Xmax - 2), Random.Range (CameraUtil.Ymin + 2, CameraUtil.Ymax - 2), 0);
	}
	public void killEnemy (GameObject enemy) {
		nEnemy--;
		enemy.SetActive (false);
	}
}