using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog5 : MonoBehaviour {

	public Button b_weiter;

	void Start () {

		b_weiter = b_weiter.GetComponent<Button>();

	}

	public void click_weiter()
	{
		SceneManager.LoadScene("Dialog1");
	}
}
