using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        string aim = col.gameObject.name;
        if(aim == "Player")
        {
            SceneManager.LoadScene(gameObject.GetComponent<Aim>().getScene());
        }
    }
}
