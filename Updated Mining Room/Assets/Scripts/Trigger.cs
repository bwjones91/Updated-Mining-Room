using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public GameObject rightWall;
    public Transform myCamera;

    //private TrollController trollController;
    private OreSwitcher oreSwitcher;

	void Start () {
        //trollController = GameObject.Find("Troll").GetComponent<TrollController>();
        //oreSwitcher = GameObject.Find("Ore Controller").GetComponent<OreSwitcher>();
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            myCamera.parent = null;
            rightWall.SetActive(true);
            //trollController.MoveTroll();
            //oreSwitcher.GetComponent<OreSwitcher>().enabled = true;
            Destroy(this.gameObject);
        }
    }

}
