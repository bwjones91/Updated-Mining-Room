using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public OresRequired oresNeeded;

	void Start () {
        oresNeeded = GameObject.Find("Shopkeeper").GetComponent<OresRequired>();
        oresNeeded.RequiredOres(1);
	}
	
	void Update () {
		
	}
}
