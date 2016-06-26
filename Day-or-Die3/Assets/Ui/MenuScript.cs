using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
	// Variablen
	public Canvas m_exit;
	public Canvas m_credits;
	public Canvas m_level;

	public Button b_start;
	public Button b_exit;
	public Button b_credits;

	public Image i_rat;



	// Use this for initialization
	void Start () {

		m_exit = m_exit.GetComponent<Canvas>();
		m_credits = m_credits.GetComponent<Canvas>();
		m_level = m_level.GetComponent<Canvas>();

		b_start = b_start.GetComponent<Button>();
		b_exit = b_exit.GetComponent<Button>(); 
		b_credits = b_credits.GetComponent<Button>();

		i_rat = i_rat.GetComponent<Image> ();

		m_exit.enabled = false;
		m_credits.enabled = false;
		m_level.enabled = false;
	}

	public void click_exit()
	{
		m_exit.enabled = true;
		m_credits.enabled = false;
		m_level.enabled = false;

		b_start.enabled = false;
		b_exit.enabled = false;
		b_credits.enabled = false;

		i_rat.enabled = false;
	}

	public void click_credits()
	{
		m_exit.enabled = false;
		m_credits.enabled = true;
		m_level.enabled = false;

		b_start.enabled = false;
		b_exit.enabled = false;
		b_credits.enabled = false;

		i_rat.enabled = false;
	}

	public void click_play()
	{
		m_exit.enabled = false;
		m_credits.enabled = false;
		m_level.enabled = true;

		b_start.enabled = false;
		b_exit.enabled = false;
		b_credits.enabled = false;

		i_rat.enabled = false;
	}

	public void click_back_to_start()
	{
		m_exit.enabled = false;
		m_credits.enabled = false;
		m_level.enabled = false;

		b_start.enabled = true;
		b_exit.enabled = true;
		b_credits.enabled = true;

		i_rat.enabled = true;
	}

	public  void load_first_level()
	{
		SceneManager.LoadScene("FirstScene");
	}

	public void load_second_level()
	{
		SceneManager.LoadScene("SecondScene");
	}

	public void load_third_level()
	{
		SceneManager.LoadScene("ThirdScene");
	}

	public void exit_game()
	{
		Application.Quit ();
	}

}
