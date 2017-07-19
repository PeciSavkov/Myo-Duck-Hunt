using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class BulletSpawner : MonoBehaviour {
	
	public GameObject myo;
	public GameObject bullet;
	public Transform spawnPoint;
	static public int BulletCount = 3;
	private Pose _lastPose = Pose.Unknown;
	public AudioClip soundShot;
	public AudioClip soundEmpty;

	void FixedUpdate ()
	{
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;

			if (thalmicMyo.pose == Pose.Fist) {
				if (BulletCount > 0) {
					bool shoot = true;

					if (shoot) {
						GetComponent<AudioSource> ().PlayOneShot (soundShot);
						Instantiate (bullet, spawnPoint.position, spawnPoint.rotation);
						BulletCount--;
					}
				} else {
					GetComponent<AudioSource> ().PlayOneShot (soundEmpty);
				}
			}
		}
	}
}
