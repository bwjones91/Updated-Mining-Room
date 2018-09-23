using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartCatcher : MonoBehaviour {

    public List<Ore> oresCaught = new List<Ore>();
    
    private OreSwitcher oreSwitcher;


    void Start () {
        oreSwitcher = GameObject.Find("Ore Controller").GetComponent<OreSwitcher>();
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Ore")
        {
            oresCaught.Add(oreSwitcher.currentOre);
            oreSwitcher.oresNeeded.Remove(oreSwitcher.currentOre);
        }
    }

}
