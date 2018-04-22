using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CerfGames.Utils;

public class StartUIManager : Singleton<StartUIManager> {

	public CanvasGroup startGameGroup; //Start canvas group
	public TextMeshProUGUI pressText; //The blinkable text

	protected override void Awake() {
		IsPersistentBetweenScenes = false;
		base.Awake();
	}
	void Start () {
		startGameGroup.alpha = 1;
		StartCoroutine(BlinkPressText());
	}
	
	// Update is called once per frame
	void Update () {
		//Start the game
		if(Input.GetKeyDown(KeyCode.Space) && startGameGroup.alpha == 1){
			startGameGroup.alpha = 0;
			UIManager.Instance.gameGroup.alpha = 1;
			GameManager.Instance.canPlay = true;
		}
	}

	public void StartGameOff(){
		startGameGroup.alpha = 0;
		startGameGroup.blocksRaycasts = false;
		startGameGroup.interactable = false;
	}

	//Start the credits
	public void CreditsGroupButton(){
		startGameGroup.alpha = 0;
		UIManager.Instance.creditsGroup.blocksRaycasts = true;
		UIManager.Instance.creditsGroup.alpha = 1;
	}

	//Blink the text
	IEnumerator BlinkPressText(){
		bool isVisible = true;
		WaitForSeconds wait = new WaitForSeconds(0.01f);
		while(!Input.GetKeyDown(KeyCode.Space)){
			if(!isVisible){
				pressText.alpha += 1*Time.deltaTime;
			}else{
				pressText.alpha -= 1*Time.deltaTime;
			}
			if(pressText.alpha <= 0){
				isVisible = false;
			}else if(pressText.alpha >= 1){
				isVisible = true;
			}
			yield return wait;
		}
		yield return null;
	}
}
