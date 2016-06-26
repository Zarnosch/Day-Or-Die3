using UnityEngine;
using System.Collections;

public class HUDSchwAu : MonoBehaviour {

	public GameObject player;
	float maxau;
	float maxwa;
	float currau;
	float currwa;
	float prowa;
	float proau;

	void Start()
	{
		maxwa = player.gameObject.GetComponent<Stats>().getWasserMax();
	}

	void OnGUI()
	{
		currau = player.gameObject.GetComponent<Stats>().ausdauer;
		currwa = player.gameObject.GetComponent<Stats>().wasser;
		maxau = player.gameObject.GetComponent<Stats>().getAusdauerMay();

		prowa = currwa / maxwa;
		proau = currau / maxau;


		GUI.Label (new Rect(50,Screen.height-200,200,50), "Ausdauer left: ");
		GUI.Box (new Rect (50,Screen.height - 175,200*proau,25), "");
		GUI.Box (new Rect (50,Screen.height - 150,200,25), currau + "/" + maxau);
		GUI.Label (new Rect(50,Screen.height-100, 200,50), "Schweiß left: ");
		GUI.Box (new Rect (50,Screen.height - 75,200*prowa,25),"");
		GUI.Box (new Rect (50,Screen.height - 50,200,25),currwa + "/" + maxwa);


	}

}