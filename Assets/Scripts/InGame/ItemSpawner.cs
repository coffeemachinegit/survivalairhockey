using System.Collections;
using System.Collections.Generic;
using CerfGames.Utils;
using UnityEngine;
public class ItemSpawner : MonoBehaviour {

	ObjectPool itemPool;

	public int maxItem, nItem, spawnOffset = 2;
	[SerializeField]
	public float timeToSpawn = 1f;

	GameObject itemToSpawn;

	public Sprite[] itemsSprite;

	private SurvivalItem survivalItem;
	private void Start () {
		itemPool = GetComponent<ObjectPool> ();
		StartCoroutine ("spawn");
	}
	IEnumerator spawn () {
		while (true) {
			yield return new WaitForSeconds (timeToSpawn);
			if (GameManager.Instance.canPlay) {
				if (GameManager.Instance.nItem <= maxItem) {
					int type = Random.Range (0, 4);
					Debug.Log (type);
					itemToSpawn = itemPool.GetPooledObject ();
					itemToSpawn.transform.position = generateRandomCoord ();
					survivalItem = itemToSpawn.GetComponent<SurvivalItem> ();
					if (type == 0) { //Agua
						itemToSpawn.GetComponent<SpriteRenderer> ().sprite = itemsSprite[0];
						survivalItem.value = 10;
						survivalItem.type = ItemType.Liquid;
					} else if (type == 1) { //Refri
						itemToSpawn.GetComponent<SpriteRenderer> ().sprite = itemsSprite[1];
						survivalItem.value = 5;
						survivalItem.type = ItemType.Liquid;
					} else if (type == 2) { //Burgão
						itemToSpawn.GetComponent<SpriteRenderer> ().sprite = itemsSprite[2];
						survivalItem.value = 10;
						survivalItem.type = ItemType.Food;
					} else { //Franguinho
						itemToSpawn.GetComponent<SpriteRenderer> ().sprite = itemsSprite[3];
						survivalItem.value = 5;
						survivalItem.type = ItemType.Food;
					}
					survivalItem = null;
					itemToSpawn.SetActive (true);
					GameManager.Instance.nItem++;
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