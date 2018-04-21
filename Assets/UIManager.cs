using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CerfGames.Utils;

public class UIManager : Singleton<UIManager> {

	//The canvas group from each UI Screen
	public CanvasGroup startGameGroup;
	public CanvasGroup gameGroup;
	public CanvasGroup creditsGroup;
	//--------------------------------------------
	//Variables from UI Elements
	public Slider hungrySlider,thristSlider,hpSlider; //All the on screen slider
	public TextMeshProUGUI scoreBoardText; //The game Score
	//--------------------------------------------
	float time;

	protected override void Awake() {
		IsPersistentBetweenScenes = false;
		base.Awake();
	}

	private void Update() {
		
	}

	public void UpdateSliderValue(string flag,float value){
		if(flag == "hungry"){
			hungrySlider.value = value;
		}else if(flag == "thirst"){
			thristSlider.value = value;
		}else{
			hpSlider.value -= (int)value;
		}
	}

	public void ChangeScore(int home, int visitor){
		scoreBoardText.text = home+" x "+visitor;
	}
}
