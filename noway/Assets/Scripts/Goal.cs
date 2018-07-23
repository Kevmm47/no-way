using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Goal : MonoBehaviour {

	public Image overlay;
	public GameObject overlayTextObject;
	private bool fading;

	public void Start() {
		fading = false;
		Time.timeScale = 1f;
		if (overlay == null) {
			gameObject.SetActive(false);
		} else {
			overlay.enabled = true;
			overlayTextObject.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {	
			if (col.gameObject.tag == "Player") {
				GameController.GoalReached.Invoke();
				fading = true;
				Time.timeScale = 0f;
				overlayTextObject.SetActive(true);
			}
		}

	void Update() {
        if (fading == true) {
            overlay.CrossFadeAlpha(1.0f, .1f, true);
        } else {
            overlay.CrossFadeAlpha(0, .5f, false);
        }
    }
}
