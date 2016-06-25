using UnityEngine;
using System.Collections;

public class ActivateRatSense : MonoBehaviour
{
    bool bright = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!bright)
            {
                QualitySettings.antiAliasing = 0;
                GetComponent<MKGlowSystem.MKGlow>().enabled = true;
                bright = !bright;
            }
            else
            {
                QualitySettings.antiAliasing = 8;
                GetComponent<MKGlowSystem.MKGlow>().enabled = false;
                bright = !bright;
            }
        }
    }
}
