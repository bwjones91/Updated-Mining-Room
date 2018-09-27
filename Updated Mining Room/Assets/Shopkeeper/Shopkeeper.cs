using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour {

    public OresRequired oresRequired;

    private TrollController trollController;
    private int waveCount = 0;

	void Start () {
        oresRequired = GameObject.Find("Shopkeeper").GetComponent<OresRequired>();
        trollController = GameObject.Find("Troll").GetComponent<TrollController>();
        InitiateWave();
	}
	
	void Update () {
        
	}

    public void InitiateWave()
    {
        oresRequired.ClearRequiredOres();
        oresRequired.ClearImageSprite();
        waveCount++;
        oresRequired.RequiredOres(waveCount);
        oresRequired.DisplayOresRequired();
        if(waveCount == 2)
        {
            trollController.MoveTroll();
        }
    }

}
