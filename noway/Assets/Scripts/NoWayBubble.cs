using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWayBubble : MonoBehaviour {
	public GameObject player;
	public GameController gameController;
	public Vector3 playerOffset = new Vector3(1f, 1f, 0f);

	// Use this for initialization
	void Awake () {
		GameController.ComboBroken.AddListener(sayNoWay);
		if (player == null) {
			player = GameObject.FindWithTag("Player");
		}
		if (gameController == null) {
			GameObject gc = GameObject.FindWithTag("GameController");
			gameController = gc.GetComponent<GameController>();
		}
	}

	void sayNoWay() {
		if (gameController.combo > 1) {
			gameObject.SetActive(true);
			StartCoroutine(noWay());
		}
	}

	IEnumerator noWay() {
		yield return new WaitForSeconds(2f);
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.gameTime.Elapsed.TotalSeconds < 1) {
			gameObject.SetActive(false);
		}

		gameObject.transform.position = player.transform.position;
		gameObject.transform.Translate(playerOffset);
	}
}
