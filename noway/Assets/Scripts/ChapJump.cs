using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapJump: MonoBehaviour {

	public AudioSource chapSound;
	public float jumpForce = 1000f;

	Rigidbody2D rigidbody;
	int chapsLayer;

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		chapsLayer = LayerMask.NameToLayer("Chaps");
		GameController.ChapCollected.AddListener(chapJump);
	}

    void OnCollisionEnter2D(Collision2D col)
    {	
		if (col.gameObject.layer == chapsLayer) {
			GameController.ChapCollected.Invoke(col.gameObject, col);
		} else {
			ContactPoint2D contact = col.contacts[0];
			Vector2 pos = contact.point;
			float y_contact_diff = gameObject.transform.position.y - pos.y;
			if (y_contact_diff > 0.5f) {
				GameController.ComboBroken.Invoke();
			}
		}
    }

	void chapJump(GameObject chap, Collision2D col) {
		if (rigidbody.velocity.y < 0) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
		}
		rigidbody.AddForce(new Vector2(0f, jumpForce));
		if (chapSound) {
			chapSound.Play(0);
		}
	}
}
