using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSwitcher : MonoBehaviour {

    private ArduinoCommunicator AC;
    private string test;

    public GameObject mithrilController;
    public GameObject adamantiteController;
    public GameObject goldController;
    public GameObject pyroniumController;
    public GameObject silverController;


    void Start () {
        AC = GameObject.Find("Piezo Arduino Communication").GetComponent<ArduinoCommunicator>();
	}
	
	void Update () {
        print(AC.GetMessageIN());
        test = AC.messageIN;

        switch (AC.messageIN)
        {
            case "0":
                mithrilController.SetActive(true);
                Invoke("DeactivateMithril", 2f);
                break;
            case "1":
                adamantiteController.SetActive(true);
                Invoke("DeactivateAdamantite", 2f);
                break;
            case "2":
                goldController.SetActive(true);
                Invoke("DeactivateGold", 2f);
                break;
            case "3":
                pyroniumController.SetActive(true);
                Invoke("DeactivatePyronium", 2f);
                break;
            case "4":
                silverController.SetActive(true);
                Invoke("DeactivateSilver", 2f);
                break;
        }

    }

    
    public void DeactivateMithril()
    {
        mithrilController.SetActive(false);
    }

    public void DeactivateAdamantite()
    {
        adamantiteController.SetActive(false);
    }

    public void DeactivateGold()
    {
        goldController.SetActive(false);
    }

    public void DeactivatePyronium()
    {
        pyroniumController.SetActive(false);
    }

    public void DeactivateSilver()
    {
        silverController.SetActive(false);
    }

}
