using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chap : MonoBehaviour {

	public GameObject destroyEffect;

	// Use this for initialization
	void Start () {
		GameController.ChapCollected.AddListener(explodeSelf);
	}

	void explodeSelf(GameObject go, Collision2D col) {
		if (GameObject.ReferenceEquals(go, gameObject) ) {
			GameObject effect = Instantiate(destroyEffect, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
			// Destroy the effect 1 second after its animation ends
			Destroy (effect, effect.GetComponent<ParticleSystem>().duration + 1f); 
		}
	}
	
	void OnDestroy() {
		GameController.ChapCollected.RemoveListener(explodeSelf);
	}
}
