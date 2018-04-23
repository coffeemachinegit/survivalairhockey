using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItem : MonoBehaviour {

	bool flag;
	SpriteRenderer spriteRenderer;
	CircleCollider2D nailCollider;
	PolygonCollider2D woodCollider;
	public Sprite[] sprites = new Sprite[2];

	Vector3 woodScale = new Vector3 (0.5f,0.5f,0.5f);
	Vector3 nailScale = new Vector3 (1,1,1);

	private void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		nailCollider = GetComponent<CircleCollider2D>();
		woodCollider = GetComponent<PolygonCollider2D>();
	}

	private void OnEnable() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		nailCollider = GetComponent<CircleCollider2D>();
		woodCollider = GetComponent<PolygonCollider2D>();
		if(Random.Range(0,2) == 1){
			flag = true;
			spriteRenderer.sprite = sprites[0];
			spriteRenderer.color = Color.white;
			gameObject.transform.localScale = woodScale;
			woodCollider.enabled = true;
			nailCollider.enabled = false;
		}else{
			flag = false;
			spriteRenderer.sprite = sprites[1];
			spriteRenderer.color = Color.black;
			gameObject.transform.localScale = nailScale;
			woodCollider.enabled = false;
			nailCollider.enabled = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			CraftManager.Instance.Crafting(flag);
			gameObject.SetActive(false);
		}
	}
}
