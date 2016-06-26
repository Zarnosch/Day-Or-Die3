using UnityEngine;
using System.Collections;

public class AcitvateSwitches : MonoBehaviour {


    public GameObject targets;
    int count;
    float minDistance = 5f;
    Transform switches = null;

    void Start()
    {
        count = targets.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < count; i++)
        {
            switches = targets.transform.GetChild(i);
            float distance = (transform.localPosition - switches.position).magnitude;
            if (distance < minDistance && Input.GetKeyDown(KeyCode.E))
            {
                switches.GetComponent<OneTimeSwitch>().activate(gameObject);
            }         
        }
    }
}
