using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartCatcher : MonoBehaviour {

    public List<Ore> oresCaught = new List<Ore>();

    private string stringMessage;
    private OreSwitcher oreSwitcher;
    private Ore instance;

    public SerialController serialController;
    public bool hasBeenHit = false;
    public Ore oreThrown;
    
    void Start () {
        oreSwitcher = GameObject.Find("Ore Controller").GetComponent<OreSwitcher>();
        serialController = GameObject.Find("Piezo Serial Controller").GetComponent<SerialController>();
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Ore")
        {
            oresCaught.Add(oreSwitcher.currentOre);
            oreSwitcher.oresNeeded.Remove(oreSwitcher.currentOre);

            stringMessage = "8";
            stringMessage += oreSwitcher.oreCheck;
            serialController.SendSerialMessage(stringMessage);
        }
        else if(collider.gameObject.tag == "Enemy")
        {
            ThrowOre();
        }
    }

    public void ThrowOre()
    {
        if(oresCaught.Count > 0)
        {
            int amountOreThrown = Random.Range(2, 4);
            for(int i = 0; i < amountOreThrown; i++)
            {
                oreThrown = oresCaught[Random.Range(0, oresCaught.Count)];
                instance = Instantiate(oreThrown.GetComponent<Ore>(), transform.position + new Vector3(0f, 7f, 0f), Quaternion.identity);
                instance.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-500f, 500f), 500f, 0f));
                oreSwitcher.oresNeeded.Add(oreThrown.GetComponent<Ore>());
                oresCaught.Remove(oreThrown.GetComponent<Ore>());

            }
        }
    }

}
