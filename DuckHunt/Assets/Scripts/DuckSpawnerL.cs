using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawnerL : MonoBehaviour {

	public GameObject Duck;
	public Transform spawnPoint;

	void FixedUpdate ()
	{
		if (DuckMovement.OnScreen == false && DuckMovement.SpawnedFromR == true ) {
			BulletSpawner.BulletCount = 3;
			DuckMovement.DuckAlive = true;
			DuckMovement.OnScreen = true;
			DuckMovement.MovingRight = true;
			DuckMovement.SpawnedFromR = false;
			Instantiate (Duck, new Vector3(spawnPoint.position.x, Random.Range( -3f , 4f), -2), spawnPoint.rotation);
		}
	}
}
