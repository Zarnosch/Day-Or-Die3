using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public int wasserMax = 100000;
    public int AusdauerMax = 100000;
    int frameBoost = 20;

    public int wasser = 100000;
    public int ausdauer = 100000;
    bool regging = false;

    public bool active = true;

    int ausdauerReg = 500;
    int ausdauerReggingPower = 1000;
    public int ausdauerRegTimer = 500;
    
	// Use this for initialization
	void Start () {
	
	}

    public int getWasserMax()
    {
        return wasserMax;
    }

    public int getAusdauerMay()
    {
        return AusdauerMax;
    }

    public void setRegTimer(int time)
    {
        if(ausdauerRegTimer < time)
        {
            ausdauerRegTimer = time;
        }     
    }

    public void reduceWasser(int value)
    {
        if (wasser - (int)(value * Time.deltaTime * frameBoost) >= wasserMax)
        {
            wasser = wasserMax;
        }
        else if (wasser - (int)(value * Time.deltaTime * frameBoost) < 0)
        {
            wasser = 0;
            gameObject.GetComponent<FirstPersonController>().enabled = false;
            Camera.main.GetComponent<SwapSkybox>().nextDay();
            Camera.main.GetComponent<Activation>().activate(gameObject);
        }
        else
        {
            wasser -= (int)(value * Time.deltaTime * frameBoost);
        }
    }

    public void reduceAusdauer(int value)
    {
        if (ausdauer - (int)(value * Time.deltaTime * frameBoost) >= AusdauerMax)
        {
            ausdauer = AusdauerMax;
        }
        else if(ausdauer - (int)(value * Time.deltaTime * frameBoost) < 0)
        {
            ausdauer = 0;
            reduceWasser(value/2 );
            setReg();
        }
        else
        {
            ausdauer -= (int)(value * Time.deltaTime * frameBoost);
            reduceWasser(value/2 );
        }   
    }

    public void upAusdauer(int value)
    {
        if (ausdauer + (int)(value * Time.deltaTime * frameBoost) >= AusdauerMax)
        {
            ausdauer = AusdauerMax;
            regging = false;
            gameObject.GetComponent<FirstPersonController>().switchSpeed(1);
        }        
        else
            ausdauer += (int)(value * Time.deltaTime * frameBoost);
    }

    public void maxAll()
    {
        wasser = wasserMax;
        AusdauerMax = wasserMax;
        ausdauer = AusdauerMax;
    }

    public void upWasser(int value)
    {
        if (wasser + (int)(value * Time.deltaTime * frameBoost) >= wasserMax)
        {
            wasser = wasserMax;
        }
        else
            wasser +=(int) (value*Time.deltaTime* frameBoost);
    }

    public void setReg()
    {
        regging = true;
        gameObject.GetComponent<FirstPersonController>().switchSpeed(0);
    }

    void updateSight()
    {
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>().setVignetting((float) wasser / (float) wasserMax);
    }

    // Update is called once per frame
    void Update () {

        if(active)
            AusdauerMax = wasser;
        if (regging)
        {
            upAusdauer((int)(ausdauerReggingPower* Time.deltaTime * frameBoost));
        }
        else
        {          
            if(ausdauerRegTimer > 0)
                ausdauerRegTimer--;
            else
            {
                upAusdauer((int)(ausdauerReg * Time.deltaTime * frameBoost));
            }
        }
        if (!active)
        {
            ausdauer = AusdauerMax;
            wasser = wasserMax;
        }
        updateSight();

    }
}
