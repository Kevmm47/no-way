using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



[System.Serializable]
public class ChapCollectedEvent : UnityEvent<GameObject, Collision2D> {}
public class ComboBrokenEvent : UnityEvent {}
public class GoalReachedEvent : UnityEvent {}

public class GameController : MonoBehaviour {
	
	public static ChapCollectedEvent ChapCollected = new ChapCollectedEvent();
	public static ComboBrokenEvent ComboBroken = new ComboBrokenEvent();
	public static GoalReachedEvent GoalReached = new GoalReachedEvent();


	public Text hudText;
	public Text playerSpeechBubble;
	public Stopwatch gameTime = new Stopwatch();
	public int chapsCollected = 0;
	public int combo = 0;
	private int totalChaps = 0;

	// Use this for initialization
	void Start () {
		gameTime.Start();
		totalChaps = GameObject.FindGameObjectsWithTag("Chap").Length;

		ChapCollected.AddListener(addChap);
		ComboBroken.AddListener(zeroCombo);
		GoalReached.AddListener(goalReached);
	}
	
	// Update is called once per frame
	void Update () {
		setHUDText();
	}

	public void nextLevel() {
		SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
	}

	void goalReached() {
		gameTime.Stop();
	}

	void zeroCombo() {
		combo = 0;
	}

	void addChap(GameObject chap, Collision2D col) {
		chapsCollected++;
		combo++;
	}

	void setHUDText() {
		TimeSpan ts = gameTime.Elapsed;
		string curGT = string.Format("Elapsed Time: {0:00}.{1:00}", ts.Seconds, ts.Milliseconds);
		string chapsCol = string.Format("Chaps: {0}/{1}", chapsCollected, totalChaps);
		string curCombo = string.Format("Combo: {0}", combo);

		string text = string.Format("{0}\n{1}\n{2}\n", curGT, chapsCol, curCombo);
		hudText.text = text;
	}
}
