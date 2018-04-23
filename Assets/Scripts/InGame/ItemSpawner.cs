using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class ItemSpawner : MonoBehaviour {

	ObjectPool itemPool;

	public int maxItem, nItem, spawnOffset = 2;
	[SerializeField]
	public float timeToSpawn = 1f;

	public bool craftFlag;

	GameObject itemToSpawn;

	private void Start () {
		itemPool = GetComponent<ObjectPool> ();
		StartCoroutine ("spawn");
	}
	IEnumerator spawn () {
		while (true) {
			yield return new WaitForSeconds (timeToSpawn);
			if (GameManager.Instance.canPlay) {
				if(craftFlag){
					if (GameManager.Instance.nCraftItem < maxItem) {
						itemToSpawn = itemPool.GetPooledObject ();
						itemToSpawn.transform.position = generateRandomCoord ();
						itemToSpawn.SetActive (true);
						GameManager.Instance.nCraftItem++;
					}
				}else{
					if (GameManager.Instance.nItem < maxItem) {
						itemToSpawn = itemPool.GetPooledObject ();
						itemToSpawn.transform.position = generateRandomCoord ();
						itemToSpawn.SetActive (true);
						GameManager.Instance.nItem++;
					}
				}
			}
		}
	}

	Vector3 generateRandomCoord () {
		return new Vector3 (Random.Range (CameraUtil.Xmin + spawnOffset, spawnOffset), Random.Range (CameraUtil.Ymin + spawnOffset, CameraUtil.Ymax - spawnOffset), 0);

	}
	public void UseItem (GameObject item) {

		item.SetActive (false);
	}
}