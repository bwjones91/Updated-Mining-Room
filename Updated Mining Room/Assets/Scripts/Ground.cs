using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {



	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ore")
        {
            
        }
    }

}
