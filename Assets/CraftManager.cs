using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CerfGames.Utils;

public class CraftManager : Singleton<CraftManager> {

	public float craftWood = 2;
	public float craftNail = 1;

	public int option = 0;

	public GameObject shoulder,helmet,foot;

	public AudioSource source;
	public AudioClip craftSFX;

	protected override void Awake(){
		IsPersistentBetweenScenes = false;
		base.Awake();
	}

	public void Crafting(bool flag){
		if(flag && craftWood > 0){
			craftWood--;
			UIManager.Instance.UpdateCraftUI(flag,craftWood);
		}
		else if(!flag && craftNail > 0){
			craftNail--;
			UIManager.Instance.UpdateCraftUI(flag,craftNail);
		}
		CheckCraft();

	}

	public void CheckCraft(){
		if (craftNail == 0 && craftWood == 0){
			if(option == 0){
				//foot.SetActive(true);
				option++;
				craftNail = 2;
				craftWood = 3;
				UIManager.Instance.UpdateCraftUI(true,craftWood);
				UIManager.Instance.UpdateCraftUI(false,craftNail);
			}else if(option == 1){
				//helmet.SetActive(true);
				option++;
				craftNail = 3;
				craftWood = 4;
				UIManager.Instance.UpdateCraftUI(true,craftWood);
				UIManager.Instance.UpdateCraftUI(false,craftNail);
			}else if(option == 2){
				//shoulder.SetActive(true);
			}
			PlayerManager.Instance.playerStats.DamageReceivePercentual -= 0.1f;
			source.PlayOneShot(craftSFX);
		}
	}
	
}
