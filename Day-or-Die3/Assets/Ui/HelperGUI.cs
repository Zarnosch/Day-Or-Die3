using UnityEngine;
using System.Collections;

public class HelperGUI : MonoBehaviour {

	void onGUI()
	{
		GUI.Button (new Rect (10, 10, 100, 25), "Fuck ME!");
	}
}
