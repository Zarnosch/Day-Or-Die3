using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{

    public GameObject target;

    public void activate(GameObject player)
    {
        use(player);
    }

    void use(GameObject player)
    {
        target.GetComponent<Activation>().activate(player);
    }
}
