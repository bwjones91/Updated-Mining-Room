using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {

    public enum OreType
    {
        Mithril,
        Adamantite,
        Gold,
        Pyronium,
        Silver,
        None
    }

    public OreType oreType;

    void Start () {

    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

}
