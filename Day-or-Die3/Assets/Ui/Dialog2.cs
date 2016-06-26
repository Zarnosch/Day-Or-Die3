using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog2 : MonoBehaviour {
	public Button b_weiter;

	void Start () {

		b_weiter = b_weiter.GetComponent<Button>();

	}

	public void click_weiter()
	{
		SceneManager.LoadScene("Dialog3");
	}
}
