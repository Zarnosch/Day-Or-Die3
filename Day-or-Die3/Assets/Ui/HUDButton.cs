using UnityEngine;
using System.Collections;

public class HUDButton : MonoBehaviour {

	public Texture2D e_txt;
	public Texture2D wasd_txt;
	public Texture2D f_txt;
	public Texture2D shift_txt;
	public Texture2D leer_txt;
	public Texture2D foto_txt;
	public Texture2D esc_txt;
	public Texture2D tex;

	public bool is_e  = false;
	public bool is_wasd  = false;
	public bool is_f  = false;
	public bool is_shift  = false;
	public bool is_leer  = false;
	public bool is_foto  = false;
	public bool is_esc  = false;

	void OnGUI()
	{

		if (is_foto) {
			tex = foto_txt;
			GUI.DrawTexture (new Rect (Screen.width/2 - tex.width/2, Screen.height/2 - tex.height / 2, tex.width, tex.height), tex);
			StartCoroutine (hideFoto (10f));
		} else {

			if (is_e) {
				tex = e_txt;
			GUI.DrawTexture (new Rect (Screen.width - tex.width, Screen.height - tex.height, tex.width, tex.height), tex);
			} else {

				if (is_wasd) {
					tex = wasd_txt;
				GUI.DrawTexture (new Rect (Screen.width - tex.width, Screen.height - tex.height, tex.width, tex.height), tex);				} else {

					if (is_f) {
						tex = f_txt;
					GUI.DrawTexture (new Rect (Screen.width - tex.width, Screen.height - tex.height, tex.width, tex.height), tex);					} else {

						if (is_shift) {
							tex = shift_txt;
						GUI.DrawTexture (new Rect (Screen.width - tex.width, Screen.height - tex.height, tex.width, tex.height), tex);						} else {

							if (is_leer) {
								tex = leer_txt;
							GUI.DrawTexture (new Rect (Screen.width - tex.width, Screen.height - tex.height, tex.width, tex.height), tex);
								} else {

								if (is_esc) {
									tex = esc_txt;
									GUI.DrawTexture (new Rect (Screen.width - tex.width, Screen.height - tex.height, tex.width, tex.height), tex);								} 
							}

						}

					}

				}

			}

		}

		if(Input.GetKeyDown (KeyCode.Escape)){
			is_esc = false;
		}
		if(Input.GetKeyDown (KeyCode.E)){
			is_e = false;
		}
		if(Input.GetKeyDown (KeyCode.F)){
			is_f = false;
		}
		if(Input.GetKeyDown (KeyCode.Space)){
			is_leer = false;
		}
		if(Input.GetKeyDown (KeyCode.W)|| Input.GetKeyDown (KeyCode.A)||Input.GetKeyDown (KeyCode.S)||Input.GetKeyDown (KeyCode.D)){
			is_wasd = false;
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			is_shift = false; 
		}


	}

	private IEnumerator hideFoto(float time)
	{
		yield return new WaitForSeconds(time);
	}

}
