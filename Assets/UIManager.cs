using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CerfGames.Utils;

public class UIManager : Singleton<UIManager> {

	//The canvas group from each UI Screen
	public CanvasGroup gameGroup;
	public CanvasGroup creditsGroup;
	public CanvasGroup insertNameGroup;
	public CanvasGroup highScoreGroup;
	//--------------------------------------------
	//Variables from UI Elements
	public TMP_InputField nameInput;
	public Slider hungrySlider,thristSlider,hpSlider; //All the on screen slider
	public TextMeshProUGUI scoreBoardText; //The game Score
	//--------------------------------------------
	float time;

	protected override void Awake() {
		IsPersistentBetweenScenes = false;
		base.Awake();
	}
	private void Start() {
		gameGroup.alpha = 0;
		creditsGroup.alpha = 0;
	}

	//Update the slider choosed by flag
	public void UpdateSliderValue(string flag,float value){
		if(flag == "hungry"){
			hungrySlider.value = value;
		}else if(flag == "thirst"){
			thristSlider.value = value;
		}else{
			hpSlider.value -= value;
		}
	}

	//Update the scoreboard
	public void ChangeScore(int home, int visitor){
		scoreBoardText.text = home+" x "+visitor;
	}

	//In credits menu, go back to start menu
	public void BackCredits(){
		creditsGroup.alpha = 0;
		creditsGroup.blocksRaycasts = false;
		StartUIManager.Instance.startGameGroup.alpha = 1;
	}
	public void ShowHighScore(){
		highScoreGroup.alpha = 1;
		highScoreGroup.blocksRaycasts = true;
		highScoreGroup.interactable = true;
	}

	public void ShowInsertName(){
		gameGroup.alpha = 0;
		insertNameGroup.alpha = 1;
		insertNameGroup.blocksRaycasts = true;
		insertNameGroup.interactable = true;
	}

	public void InsertName(){
		GameManager.Instance.playerName = UIManager.Instance.nameInput.text;
		insertNameGroup.blocksRaycasts = false;
		insertNameGroup.interactable = false;
		insertNameGroup.alpha = 0;
		ShowHighScore();
	}
}
