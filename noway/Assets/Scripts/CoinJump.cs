using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinJump : MonoBehaviour {

	public float jumpForce = 1000f;
	public AudioSource chipCollide;
	public GameObject destroyEffect;

	Rigidbody2D rigidbody;
	int chapsLayer;

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		chapsLayer = LayerMask.NameToLayer("Chaps");

	}

    void OnCollisionEnter2D(Collision2D col)
    {	
		if (col.gameObject.layer == chapsLayer) {
			if (rigidbody.velocity.y < 0) {
				rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
			}
			rigidbody.AddForce(new Vector2(0f, jumpForce));
			if (chipCollide) {
				chipCollide.Play(0);
			}
			GameObject effect = Instantiate(destroyEffect, col.gameObject.transform.position, Quaternion.identity);
			Destroy(col.gameObject);
			// Destroy the effect 1 second after its animation ends
			Destroy (effect, effect.GetComponent<ParticleSystem>().duration + 1f); 
		}
    }
}
