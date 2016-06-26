using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	bool isPaused = false;
	public bool isSteuerung = false;
	public bool isStatistics = false;

	private Rect b_fort;
	private Rect b_haupt;
	private Rect b_enden;
	private Rect b_steu;
	private Rect b_stat;

	private float ctrl_width = 160;
	private float ctrl_height = 30;

	void switchTime()
	{
		if (!isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		isPaused = !isPaused;

	}

	void switchSteuerung()
	{
		isSteuerung = !isSteuerung;

	}

	void switchStatistics()
	{
		isStatistics = !isStatistics;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			switchTime ();
		}


	}

	void Awake(){
		b_fort = new Rect ((Screen.width - ctrl_width) / 2, 0, ctrl_width, ctrl_height);
		b_haupt = new Rect ((Screen.width - ctrl_width) / 2, 0 , ctrl_width, ctrl_height);
		b_enden = new Rect ((Screen.width - ctrl_width) / 2, 0, ctrl_width, ctrl_height);
		b_steu = new Rect ((Screen.width - ctrl_width) / 2, 0, ctrl_width, ctrl_height);
		b_stat = new Rect ((Screen.width - ctrl_width) / 2, 0, ctrl_width, ctrl_height);
	}

	void OnGUI()
	{
		if (isPaused) { 


				b_fort.y =	(Screen.height - ctrl_height) / 2 - 100;
				b_steu.y =	((Screen.height - ctrl_height) / 2) - 50;
				b_stat.y =	((Screen.height - ctrl_height) / 2);
				b_haupt.y =	((Screen.height - ctrl_height) / 2) + 50;
				b_enden.y =	((Screen.height - ctrl_height) / 2) + 100;
				if (GUI.Button (b_fort, "Spiel fortsetzen")) { 
					switchTime ();
					isStatistics = false;
					isSteuerung = false;
				}
				if (GUI.Button (b_haupt, "Zum Hauptmenü")) { 
					switchTime (); 
					isStatistics = false;
					isSteuerung = false;
					SceneManager.LoadScene ("Hauptmenu");
				}
				if (GUI.Button (b_enden, "Spiel Beenden")) { 
					switchTime (); 
					isSteuerung = false;
					isStatistics = false;
					Application.Quit ();
				}
				if (GUI.Button (b_steu, "Steuerung")) { 
					switchSteuerung ();
					GUI.Box (new Rect (((Screen.width/4)-290), Screen.height/2-250, 500, 500), "Steuerung");
				}
				if (GUI.Button (b_stat, "Statistik")) { 
					switchStatistics ();
					GUI.Box (new Rect (((Screen.width/2)+210), Screen.height/2-250, 500, 500), "Statistics");
				}
			}

	}


}