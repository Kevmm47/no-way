using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelRestarter: MonoBehaviour {

	public string restartLevelButton = "r";
	public int secondsToRestart = 2;
	public Stopwatch gameTime = new Stopwatch();
	public GameObject icon;
	private Image iconImage;
	private Text levelRestartText;
	private Vector4 colorValue;


	// Use this for initialization
	void Start () {
	
		//iconLocation = .rectTransform.TransformPoint.
		if (icon != null) {
			levelRestartText = icon.GetComponent<Text>();
			//iconImage = icon.GetComponent<Image>();
			//colorValue = iconImage.color;
		}
		//setImageAlpha(255f);
	}

	
	// Update is called once per frame
	void Update () {
		bool restart = Input.GetKey(restartLevelButton);
		float timePassed = gameTime.Elapsed.Seconds + gameTime.Elapsed.Milliseconds / 1000f;
		if (restart && !gameTime.IsRunning) {
			gameTime.Start();
			levelRestartText.text = "Restarting...";
			//setImageAlpha(255f);
			//iconImage.CrossFadeAlpha(0.1f, 1.0f, false);
		} else if (restart && gameTime.IsRunning) {
			// check if over 2 seconds
			if(timePassed > secondsToRestart) {
				levelRestartText.text = "Restarting Now!";
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
				//UnityEngine.Debug.Log("Restarting!!");
			} else {
				//iconImage.CrossFadeAlpha(0.1f, 1.0f, false);
				//setImageAlpha(255f * timePassed / secondsToRestart);

				//UnityEngine.Debug.Log(255f * timePassed / secondsToRestart);
			}
		} else if (!restart && gameTime.IsRunning) {
			gameTime.Stop();
			gameTime.Reset();
			levelRestartText.text = "";

			//setImageAlpha(0f);
			//UnityEngine.Debug.Log("Stopped!");
		} 
	}

	void setImageAlpha(float alpha) {
		colorValue.w = alpha;
		iconImage.color = colorValue;
	}
}
