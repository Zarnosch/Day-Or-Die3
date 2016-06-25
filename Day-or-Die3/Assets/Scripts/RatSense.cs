using UnityEngine;
using System.Collections;

public class RatSense : MonoBehaviour {

    public Material standard;
    public Material ratSense;
    public bool normal = true;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (normal)
            {
                GetComponent<Renderer>().sharedMaterial = ratSense;
                normal = !normal;
            }
            else
            {
                GetComponent<Renderer>().sharedMaterial = standard;
                normal = !normal;
            }
        }
        
	}
}
