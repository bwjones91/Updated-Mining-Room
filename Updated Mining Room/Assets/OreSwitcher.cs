using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSwitcher : MonoBehaviour {
    [SerializeField] float hitThreshold;

    private float hitAmount = 10;
    private ArduinoCommunicator AC;

    void Start () {
        AC = GameObject.Find("Arduino Communication").GetComponent<ArduinoCommunicator>();
	}
	
	void Update () {
        print(AC.GetMessageIN());
        hitAmount = AC.GetMessageIN();

        if(hitAmount > hitThreshold)
        {
            print("SUCCESS!");
        }

	}




}
