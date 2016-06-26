using UnityEngine;
using System.Collections;

public class OneTimeSwitch : MonoBehaviour {

    bool on = false;
    public GameObject target;
    public bool cascade;

    public void activate(GameObject player)
    {
        if (!on)
        {
            on = !on;
            use(player, cascade);
        }   
    }

    void use(GameObject player, bool casc)
    {
        target.GetComponent<Activation>().activate(player);
        if (cascade && target.GetComponent<OneTimeSwitch>() != null)
        {
            target.GetComponent<OneTimeSwitch>().activate(player);
        }
    }
}
