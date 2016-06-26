using UnityEngine;
using System.Collections;

public class TestCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Not Colision with player");
        if (col.gameObject.name != "Plane")
        {
            Debug.Log("Colision with player");
            Vector3 force = (gameObject.transform.position - col.gameObject.transform.position);
            force.Set(force.x,0, force.z);
            col.gameObject.GetComponent<Rigidbody>().AddForce(100*force, ForceMode.Force);
        }
        Debug.Log(col.gameObject.name);
    }

    // Update is called once per frame
    void Update () {
	}
}
