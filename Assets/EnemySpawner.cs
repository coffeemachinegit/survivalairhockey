using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class EnemySpawner : MonoBehaviour {

	ObjectPool enemypool;

	public int maxEnemy, nEnemy, spawnOffset = 2;
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
			if (GameManager.Instance.canPlay) {
				if (flag) {
					if (GameManager.Instance.nZombie <= maxEnemy) {
						Debug.Log("N Zombie:"+GameManager.Instance.nZombie);
						Debug.Log("Max Enemy:"+maxEnemy);
						enemyToSpawn = enemypool.GetPooledObject ();
						enemyToSpawn.transform.position = generateRandomCoord ();
						enemyToSpawn.SetActive (true);
						enemyToSpawn.GetComponent<Collider2D> ().enabled = false;
						GameManager.Instance.nZombie++;
					}
				} else {
					if (GameManager.Instance.nShooter <= maxEnemy) {
						enemyToSpawn = enemypool.GetPooledObject ();
						enemyToSpawn.transform.position = generateRandomCoord ();
						enemyToSpawn.SetActive (true);
						enemyToSpawn.GetComponentInChildren<Collider2D> ().enabled = false;
						GameManager.Instance.nShooter++;
					}
				}
			}
		}
	}

	Vector3 generateRandomCoord () {
		if (Random.Range (0f, 1f) <= 0.5f) {
			//Nascer em cima
			return new Vector3 (Random.Range (spawnOffset, CameraUtil.Xmax - spawnOffset), CameraUtil.Ymin - spawnOffset, 0);
		} else {
			//Nascer em baixo
			return new Vector3 (Random.Range (spawnOffset, CameraUtil.Xmax - spawnOffset), CameraUtil.Ymax + spawnOffset, 0);
		}

	}
	public void killEnemy (GameObject enemy) {
		nEnemy--;
		enemy.SetActive (false);
	}
}