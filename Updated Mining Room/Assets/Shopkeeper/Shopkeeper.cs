using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour {

    public OresRequired oresNeeded;

    private TrollController trollController;
    private int waveCount = 0;

	void Start () {
        oresNeeded = GameObject.Find("Shopkeeper").GetComponent<OresRequired>();
        trollController = GameObject.Find("Troll").GetComponent<TrollController>();
        InitiateWave();
	}
	
	void Update () {
        
	}

    public void InitiateWave()
    {
        waveCount++;
        oresNeeded.RequiredOres(waveCount);
        if(waveCount == 2)
        {
            trollController.MoveTroll();
        }
    }

}
