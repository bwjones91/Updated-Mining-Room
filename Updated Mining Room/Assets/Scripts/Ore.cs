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
    public SerialController serialController;

    private string stringMessage;

    void Start () {
        serialController = GameObject.Find("Piezo Serial Controller").GetComponent<SerialController>();
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            int oreNumber = (int)oreType;
            stringMessage = "8";
            stringMessage += oreNumber;
            print(stringMessage);
            serialController.SendSerialMessage(stringMessage);
        }
        if (collider.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

}
