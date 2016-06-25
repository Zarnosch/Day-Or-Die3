﻿using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public int wasserMax = 100000;
    public int AusdauerMax = 100000;

    public int wasser = 100000;
    public int ausdauer = 100000;
    bool regging = false;

    int ausdauerReg = 50;
    int ausdauerReggingPower = 150;
    public int ausdauerRegTimer = 500;
    
	// Use this for initialization
	void Start () {
	
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
        if (wasser - value >= wasserMax)
        {
            wasser = wasserMax;
        }
        else if (wasser - value < 0)
        {
            wasser = 0;
        }
        else
        {
            wasser -= value;
        }
    }

    public void reduceAusdauer(int value)
    {
        if (ausdauer - value >= AusdauerMax)
        {
            ausdauer = AusdauerMax;
        }
        else if(ausdauer - value < 0)
        {
            ausdauer = 0;
            reduceWasser(value / 10);
            setReg();
        }
        else
        {
            ausdauer -= value;
            reduceWasser(value / 10);
        }   
    }

    public void upAusdauer(int value)
    {
        if (ausdauer + value >= AusdauerMax)
        {
            ausdauer = AusdauerMax;
            regging = false;
            gameObject.GetComponent<FirstPersonController>().switchSpeed(1);
        }        
        else
            ausdauer += value;
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
        if (regging)
        {
            Debug.Log("regged by:" + ausdauerReggingPower);
            upAusdauer(ausdauerReggingPower);
        }
        else
        {          
            if(ausdauerRegTimer > 0)
                ausdauerRegTimer--;
            else
            {
                upAusdauer(ausdauerReg);
            }
        }
        updateSight();

    }
}