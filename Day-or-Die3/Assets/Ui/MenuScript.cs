using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
	// Variablen
	public Canvas m_exit;
	public Canvas m_credits;
	public Canvas m_level;
	public Canvas m_scene;
	public Canvas m_steu;
	public Canvas m_stat;

	public Button b_start;
	public Button b_exit;
	public Button b_credits;
	public Button b_stat;
	public Button b_steu;
	public Button b_scene;

	public Image i_rat;



	// Use this for initialization
	void Start () {

		m_exit = m_exit.GetComponent<Canvas>();
		m_credits = m_credits.GetComponent<Canvas>();
		m_level = m_level.GetComponent<Canvas>();
		m_steu = m_steu.GetComponent<Canvas>();
		m_stat = m_stat.GetComponent<Canvas>();
		m_scene = m_scene.GetComponent<Canvas>();

		b_start = b_start.GetComponent<Button>();
		b_exit = b_exit.GetComponent<Button>(); 
		b_credits = b_credits.GetComponent<Button>();
		b_stat = b_stat.GetComponent<Button>();
		b_steu = b_steu.GetComponent<Button>(); 
		b_scene = b_scene.GetComponent<Button>();

		i_rat = i_rat.GetComponent<Image> ();

		m_exit.enabled = false;
		m_credits.enabled = false;
		m_level.enabled = false;
		m_stat.enabled = false;
		m_steu.enabled = false;
		m_scene.enabled = false;
	}

	public void click_exit()
	{
		m_exit.enabled = true;
		m_credits.enabled = false;
		m_level.enabled = false;
		m_stat.enabled = false;
		m_steu.enabled = false;
		m_scene.enabled = false;

		b_stat.enabled = false;
		b_steu.enabled = false;
		b_scene.enabled = false;
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
		m_stat.enabled = false;
		m_steu.enabled = false;
		m_scene.enabled = false;

		b_stat.enabled = false;
		b_steu.enabled = false;
		b_scene.enabled = false;
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
		m_stat.enabled = false;
		m_steu.enabled = false;
		m_scene.enabled = false;

		b_stat.enabled = false;
		b_steu.enabled = false;
		b_scene.enabled = false;
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
		m_stat.enabled = false;
		m_steu.enabled = false;
		m_scene.enabled = false;

		b_stat.enabled = true;
		b_steu.enabled = true;
		b_scene.enabled = true;
		b_start.enabled = true;
		b_exit.enabled = true;
		b_credits.enabled = true;

		i_rat.enabled = true;
	}

	public void click_steu()
	{
		m_exit.enabled = false;
		m_credits.enabled = false;
		m_level.enabled = false;
		m_stat.enabled = false;
		m_steu.enabled = true;
		m_scene.enabled = false;

		b_stat.enabled = false;
		b_steu.enabled = false;
		b_scene.enabled = false;
		b_start.enabled = false;
		b_exit.enabled = false;
		b_credits.enabled = false;

		i_rat.enabled = false;
	}

	public void click_stat()
	{
		m_exit.enabled = false;
		m_credits.enabled = false;
		m_level.enabled = false;
		m_stat.enabled = true;
		m_steu.enabled = false;
		m_scene.enabled = false;

		b_stat.enabled = false;
		b_steu.enabled = false;
		b_scene.enabled = false;
		b_start.enabled = false;
		b_exit.enabled = false;
		b_credits.enabled = false;

		i_rat.enabled = false;
	}

	public void click_scene()
	{
		m_exit.enabled = false;
		m_credits.enabled = false;
		m_level.enabled = false;
		m_stat.enabled = false;
		m_steu.enabled = false;
		m_scene.enabled = true;

		b_stat.enabled = false;
		b_steu.enabled = false;
		b_scene.enabled = false;
		b_start.enabled = false;
		b_exit.enabled = false;
		b_credits.enabled = false;

		i_rat.enabled = false;
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

	public void load_fourth_level()
	{
		SceneManager.LoadScene("ThirdScene");
	}

	public void load_fifth_level()
	{
		SceneManager.LoadScene("ThirdScene");
	}


	public void load_first_scene()
	{
		SceneManager.LoadScene("Scene1");
	}

	public void load_second_scene()
	{
		SceneManager.LoadScene("Scene2");
	}

	public void load_third_scene()
	{
		SceneManager.LoadScene("Scene3");
	}

	public void load_fourth_scene()
	{
		SceneManager.LoadScene("Scene4");
	}

	public void load_fifth_scene()
	{
		SceneManager.LoadScene("Scene5");
	}

	public void exit_game()
	{
		Application.Quit ();
	}

}
