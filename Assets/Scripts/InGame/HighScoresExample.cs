/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoresExample : MonoBehaviour {

	const string privateCode = "YOUR PRIVATE";
	const string publicCode = "YOU  PUBLIC";
	const string webURL = "http://dreamlo.com/lb/";

	public HighScoreDataExample[] highScoreList;

	public void AddNewHighScore(string username, float score){
		StartCoroutine(UploadNewHighScore(username,score));
	}

	public void DownloadHighScore(){
		StartCoroutine("DownloadHighScoreFromDatabase");
	}

	IEnumerator UploadNewHighScore(string username, float score){
		WWW www = new WWW(webURL+privateCode+"/add/"+WWW.EscapeURL(username)+ "/" + score);
		yield return www;

		if(string.IsNullOrEmpty(www.error)){
			DownloadHighScore();
		}else{
		}
	}

	IEnumerator DownloadHighScoreFromDatabase(){
		WWW www = new WWW(webURL+publicCode+"/pipe/");
		yield return www;

		if(string.IsNullOrEmpty(www.error)){
			FormatHighScore(www.text);
			UIManager.Instance.OnHighScoresDownloaded(highScoreList);
		}else{
		}
	}

	void FormatHighScore(string textStream){
		string[] entries = textStream.Split(new char[] {'\n'},System.StringSplitOptions.RemoveEmptyEntries);
		highScoreList = new HighScoreDataExample[entries.Length];
		for(int i=0;i<entries.Length;i++){
			string[] entryInfo = entries[i].Split(new char[]{'|'});
			string[] completeName = entryInfo[0].Split(new char[]{'+'});
			string username = "";
			for(int j=0;j<completeName.Length;j++){
				username += completeName[j]+" ";
			}
			float score = float.Parse(entryInfo[1]);
			highScoreList[i] = new HighScoreDataExample(username,score);
		}
	}
}

public struct HighScoreDataExample{
	public string username;
	public float score;

	public HighScoreDataExample(string _username, float _score){
		username = _username;
		score = _score;
	}
}
*/