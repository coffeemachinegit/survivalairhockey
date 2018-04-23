using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{Food,Liquid}

public class SurvivalItem : MonoBehaviour {

	public int value;
	public ItemType type;

	public AudioClip eat,drink;
	public AudioSource source;

	public Sprite[] itemsSprite = new Sprite[4];
	public SpriteRenderer spriteRenderer;

	int itemChoosed;

	private void Start() {
		source = GameManager.Instance.bgSource;
	}

	private void OnEnable() {
		itemChoosed = Random.Range (0, 4);
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (itemChoosed == 0) { //Agua
			spriteRenderer.sprite = itemsSprite[0];
			value = 10;
			type = ItemType.Liquid;
		} else if (itemChoosed == 1) { //Refri
			spriteRenderer.sprite = itemsSprite[1];
			value = 5;
			type = ItemType.Liquid;
		} else if (itemChoosed == 2) { //Burgão
			spriteRenderer.sprite = itemsSprite[2];
			value = 10;
			type = ItemType.Food;
		} else { //Franguinho
			spriteRenderer.sprite = itemsSprite[3];
			value = 5;
			type = ItemType.Food;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			if(type == ItemType.Food){
				SurvivalManager.Instance.AddStatus("hungry",value);
				if(source.isPlaying){
					source.Stop();
					source.Play();
				}
				source.PlayOneShot(eat);
			}else{
				SurvivalManager.Instance.AddStatus(string.Empty,value);
				source.PlayOneShot(drink);
			}
			GameManager.Instance.nItem--;
			gameObject.transform.parent.gameObject.SetActive(false);
		}
	}
}
