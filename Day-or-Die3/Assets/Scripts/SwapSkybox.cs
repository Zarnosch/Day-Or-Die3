using UnityEngine;
using System.Collections;

public class SwapSkybox : MonoBehaviour
{

    public Material night;
    public Material day;

    bool dayTime = false;

    public void nextDay()
    {
        if (dayTime)
        {
            gameObject.GetComponent<Skybox>().material = night;
        }
        else
        {
            gameObject.GetComponent<Skybox>().material = day;
        }
        dayTime = !dayTime;
    }
}
