using UnityEngine;
using System.Collections;

public class Statisti : MonoBehaviour {

	// Update is called once per frame
	void OnGUI() {
		if (gameObject.GetComponent<PauseMenu>().isStatistics) {
			GUI.Box (new Rect (((Screen.width/2)+210), Screen.height/2-250, 500, 500), "Statistics");
		}
	}
}
