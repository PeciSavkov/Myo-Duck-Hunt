using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class Movement : MonoBehaviour 
{
	public GameObject myo;
	public static bool pause = true;
	private float refX = 0;
	private float refY = 0;
	private float X = 0;
	private float Y = 0;
	private Pose _lastPose = Pose.Unknown;

	void Update ()
	{
		bool updateReference = false;
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		ThalmicHub hub = ThalmicHub.instance;

		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;

			if (thalmicMyo.pose == Pose.FingersSpread) {
				updateReference = true;
				ExtendUnlockAndNotifyUserAction(thalmicMyo);
			}
		}
		if (Input.GetKeyDown ("r")) {
			updateReference = true;
		}
		if (updateReference) {
			refX = normalizeAngle (myo.transform.eulerAngles.y);
			refY = normalizeAngle (360 - myo.transform.eulerAngles.x);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
			PauseGame ();

		X = normalizeAngle (myo.transform.eulerAngles.y);
		Y = normalizeAngle (360 - myo.transform.eulerAngles.x);
		transform.position = new Vector3 (normalizeAngle( X - refX), normalizeAngle( Y - refY));
	}

	float normalizeAngle (float angle)
	{
		if (angle > 180.0f) {
			return angle - 360.0f;
		}
		if (angle < -180.0f) {
			return angle + 360.0f;
		}
		return angle;
	}

	public void PauseGame()
	{
		Time.timeScale = 0f;
		pause = true;
	}
	public static void startGame()
	{
		Time.timeScale = 1f;
		pause = false;
	}


	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;

		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}

		myo.NotifyUserAction ();
	}
}