using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour {

    public GameObject oreHit;

    private ArduinoCommunicator AC;
    private OreSwitcher oreSwitcher;

    void Start () {
        AC = GameObject.Find("Piezo Arduino Communication").GetComponent<ArduinoCommunicator>();
        oreSwitcher = GameObject.Find("Ore Controller").GetComponent<OreSwitcher>();
    }
	

	void Update () {
        switch (AC.messageIN)
        {
            case "0":
                oreHit = oreSwitcher.mithrilOre;
                break;
            case "1":
                oreHit = oreSwitcher.adamantiteOre;
                break;
            case "2":
                oreHit = oreSwitcher.goldOre;
                break;
            case "3":
                oreHit = oreSwitcher.pyroniumOre;
                break;
            case "4":
                oreHit = oreSwitcher.silverOre;                
                break;
        }

    }

}
