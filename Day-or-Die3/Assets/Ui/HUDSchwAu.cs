using UnityEngine;
using System.Collections;

public class HUDSchwAu : MonoBehaviour {

	public GameObject player;
	int maxau;
	int maxwa;

	void Start()
	{
		maxau = gameObject.GetComponent<Stats>().getAusdauerMay();
		maxwa = gameObject.GetComponent<Stats>().getWasserMax();
	}


	void OnGUI()
	{
		int currau = gameObject.GetComponent<Stats> ().ausdauer;
		int currwa = gameObject.GetComponent<Stats> ().wasser;

		float prowa = currwa / maxwa;
		float proau = currau / maxau;


		GUI.Label (new Rect(Screen.height-200, 50,50,50), "Ausdauer left: ");

		GUI.Box (new Rect (Screen.height - 175,50,200*proau,50), maxau-currau);

		GUI.Label (new Rect(Screen.height-100, 50, 50,50), "Schweiß left: ");

		GUI.Box (new Rect (Screen.height - 75,50,200*prowa,50),maxwa-currwa);


	}

}