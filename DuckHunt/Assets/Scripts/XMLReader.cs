using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;
using UnityEngine.SceneManagement;

public class XMLReader : MonoBehaviour {

	public TextAsset dictonary;
	public string languageName;
	public static int currentLanguage;
	public Texture pc1;
	public Texture pc2;
	public Texture bg;


	string scene;
	string button1;
	string button2;
	string button3;
	string button4;
	string button5;
	string str1;
	string str2;
	string str3;



	List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
	Dictionary<string, string> obj;

	void Awake()
	{
		Reader ();
	}

	void Update()
	{
		languages [currentLanguage].TryGetValue ("Name", out languageName);
		languages [currentLanguage].TryGetValue ("button1", out button1);
		languages [currentLanguage].TryGetValue ("button2", out button2);
		languages [currentLanguage].TryGetValue ("button3", out button3);
		languages [currentLanguage].TryGetValue ("button4", out button4);
		languages [currentLanguage].TryGetValue ("button5", out button5);
		languages [currentLanguage].TryGetValue ("label1", out str1);
		languages [currentLanguage].TryGetValue ("label2", out str2);
		languages [currentLanguage].TryGetValue ("label3", out str3);
	}

	void OnGUI()
	{
		if (LoadScene.GetSceneName () == "MainMenu") {
			GUILayout.BeginArea (new Rect ((Screen.width/2)-75, (Screen.height/2)-75, 150, 150));

			if (GUILayout.Button (button1)) {
				LoadScene.LoadByIndex (1);
			}
			GUILayout.Space (10);
			if (GUILayout.Button (button2)) {
				LoadScene.LoadByIndex (2);
			}
			GUILayout.Space (10);
			if (GUILayout.Button (button3)) {
				LoadScene.Quit ();
			}

			GUILayout.EndArea ();
		} else if (LoadScene.GetSceneName () == "Options") {
			GUILayout.BeginArea (new Rect ((Screen.width/2)-75, (Screen.height/2)-75, 150, 150));

			if (GUILayout.Button (button4)) {
				if (currentLanguage == 0)
					currentLanguage++;
				else
					currentLanguage--;
			}
			GUILayout.Space (10);
			if (GUILayout.Button (button5)) {
				LoadScene.LoadByIndex (0);
			}

			GUILayout.EndArea ();
		}   else if (LoadScene.GetSceneName () == "Level") {
			if (Movement.pause) {
				GUIStyle gs = new GUIStyle ();
				gs.alignment = TextAnchor.LowerCenter;
				GUILayout.BeginArea (new Rect ((Screen.width / 2) - 150, (Screen.height / 2) - 150, 300, 300), bg);
				GUI.contentColor = Color.black;
				GUILayout.Label (str1, gs);
				GUILayout.Space (10);
				GUILayout.BeginHorizontal ();
				GUILayout.Label (pc1, GUILayout.Width (50), GUILayout.Height (50));
				GUILayout.Label (str2, gs);
				GUILayout.EndHorizontal ();
				GUILayout.Space (10);
				GUILayout.BeginHorizontal ();
				GUILayout.Label (pc2, GUILayout.Width (50), GUILayout.Height (50));
				GUILayout.Label (str3, gs);
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				if (GUILayout.Button (button5)) {
					LoadScene.LoadByIndex (0);
				}
				if (GUILayout.Button ("Start")) {
					Movement.startGame ();
				}
				GUILayout.EndHorizontal ();
				GUILayout.EndArea ();
			}
		}
	}



	void Reader()
	{
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (dictonary.text);
		XmlNodeList languagesList = xmlDoc.GetElementsByTagName ("language");

		foreach (XmlNode languageValue in languagesList) {
			XmlNodeList languageContent = languageValue.ChildNodes;
			obj = new Dictionary<string, string> ();

			foreach (XmlNode value in languageContent) {
				if (value.Name == "Name")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "button1")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "button2")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "button3")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "button4")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "button5")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "label1")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "label2")
					obj.Add (value.Name, value.InnerText);
				if (value.Name == "label3")
					obj.Add (value.Name, value.InnerText);
			}
			languages.Add (obj);
		}
	}
}