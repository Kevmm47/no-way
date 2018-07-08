using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinJump : MonoBehaviour {

	public float jumpForce = 1000f;
	public AudioSource chipCollide;

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
			rigidbody.AddForce(new Vector2(0f, jumpForce));
			if (chipCollide) {
				chipCollide.Play(0);
			}
			Destroy(col.gameObject);
		}
    }
}
