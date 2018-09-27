using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollController : MonoBehaviour {
    
    public enum Action
    {
        Move,
        Rotate,
        Attack
    }

    public TrollMove trollMove;
    public TrollRotate trollRotate;

	void Start () {

	}

    void Update() {

    }

    public void MoveTroll()
    {
        trollMove.TrollPositionDecider();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Ore")
        {

        }
    }

}
