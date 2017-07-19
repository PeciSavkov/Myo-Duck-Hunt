using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {
	public static bool Eng = false;
	public void ChangeLanguage(int number)	{
		if (number == 1) {
			Eng = false;
		} else {
			Eng = true;
		}
	}
	public void LoadByIndex(int sceneIndex)	{
		SceneManager.LoadScene (sceneIndex);
	}
}
