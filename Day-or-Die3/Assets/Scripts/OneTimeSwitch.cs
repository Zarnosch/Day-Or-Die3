using UnityEngine;
using System.Collections;

public class OneTimeSwitch : MonoBehaviour {

    bool on = false;
    public GameObject target;

    public void activate(GameObject player)
    {
        if (!on)
        {
            on = !on;
            use(player);
        }   
    }

    void use(GameObject player)
    {
        target.GetComponent<Activation>().activate(player);
    }
}
