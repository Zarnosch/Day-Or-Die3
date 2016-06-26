using UnityEngine;
using System.Collections;

public class LabSense : MonoBehaviour {

    public bool normal = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (normal)
            {
                GetComponent<MeshRenderer>().enabled = true;
                normal = !normal;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = false;
                normal = !normal;
            }
        }

    }
}
