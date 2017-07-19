using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour {
	public float speed;
	public float upSpeed;
	static public bool DuckAlive = false;
	static public bool OnScreen = false;
	static public bool MovingRight = true;
	static public bool SpawnedFromR = true;
	public AudioClip sound;
	private bool SoundPlayed = false;

	void Update () {
		if (MovingRight == true && DuckAlive == true && Movement.pause == false) {
			transform.position += new Vector3 (speed, upSpeed);
		} else  if (MovingRight == false && DuckAlive == true && Movement.pause == false){
			transform.position += new Vector3 (-speed, upSpeed);
		}
		if (DuckAlive == false && SoundPlayed == false && Movement.pause == false) {
			GetComponent<AudioSource> ().PlayOneShot (sound);
			GetComponent<Rigidbody2D> ().gravityScale = 1;
			SoundPlayed = true;
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == "BorderRight") {
			if (BulletSpawner.BulletCount == 0) {
				OnScreen = false;
				Destroy (gameObject);
			}
			transform.rotation = Quaternion.Euler (0, 180, 0);
			MovingRight = false;
		} else if (collider.name == "BorderLeft") {
			if (BulletSpawner.BulletCount == 0) {
				OnScreen = false;
				Destroy (gameObject);
			}
			transform.rotation = Quaternion.Euler (0, 0, 0);
			MovingRight = true;
		} else if (collider.name == "Ground" && DuckAlive == true) {
			if (BulletSpawner.BulletCount == 0) {
				OnScreen = false;
				Destroy (gameObject);
			}
			upSpeed = -upSpeed;
		} else if (collider.name == "Sky") {
			if (BulletSpawner.BulletCount == 0) {
				OnScreen = false;
				Destroy (gameObject);
			}
			upSpeed = -upSpeed;
		} else if (collider.name == "Ground" && DuckAlive == false) {
			OnScreen = false;
			Destroy (gameObject);
		}
	}
}
