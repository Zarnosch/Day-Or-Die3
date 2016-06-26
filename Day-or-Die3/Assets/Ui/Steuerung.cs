using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class Steuerung : MonoBehaviour {

	// Update is called once per frame
	void OnGUI() {
		if (gameObject.GetComponent<PauseMenu>().isSteuerung) {
			GUI.Box (new Rect (((Screen.width/4)-290), Screen.height/2-250, 500, 500), "Steuerung");
		}
	}
}