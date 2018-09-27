using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSwitcher : MonoBehaviour {

    public List<Ore> oresNeeded = new List<Ore>();

    public GameObject mithrilController;     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
    public GameObject adamantiteController;     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
    public GameObject goldController;     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
    public GameObject pyroniumController;     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
    public GameObject silverController;     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.

    public GameObject mithrilOre;
    public GameObject adamantiteOre;
    public GameObject goldOre;
    public GameObject pyroniumOre;
    public GameObject silverOre;

    public GameObject activeOre;
    public string oreCheck;
    public Ore.OreType oreActive;
    public Ore currentOre;
    public SerialController serialController;
    public string stringMessage;

    private float startTime;
    private float timer;
    private float timeToRestart = 4;

    int mithrilNeeded;
    int adamantiteNeeded;
    int goldNeeded;
    int pyroniumNeeded;
    int silverNeeded;

    void Start () {
        //OresNeeded();
        //Invoke("ActiveOre", 1f);
        serialController = GameObject.Find("Piezo Serial Controller").GetComponent<SerialController>();
        startTime = Time.time;
    }
	
	void Update () {
        timer += Time.deltaTime;
        /*if(timer - startTime >= timeToRestart)
        {
            DeactivateOre();
            startTime = Time.time;
        }*/
    }

    /*public void OresNeeded()
    {
        mithrilNeeded = Random.Range(3, 5);
        adamantiteNeeded = Random.Range(3, 4);
        goldNeeded = Random.Range(3, 5);
        pyroniumNeeded = Random.Range(3, 5);
        silverNeeded = 20 - (mithrilNeeded + adamantiteNeeded + goldNeeded + pyroniumNeeded);
        for (int i = 0; i < mithrilNeeded; i++)
        {
            oresNeeded.Add(mithrilOre.GetComponent<Ore>());
        }
        for (int i = 0; i < adamantiteNeeded; i++)
        {
            oresNeeded.Add(adamantiteOre.GetComponent<Ore>());
        }
        for (int i = 0; i < goldNeeded; i++)
        {
            oresNeeded.Add(goldOre.GetComponent<Ore>());
        }
        for (int i = 0; i < pyroniumNeeded; i++)
        {
            oresNeeded.Add(pyroniumOre.GetComponent<Ore>());
        }
        for (int i = 0; i < silverNeeded; i++)
        {
            oresNeeded.Add(silverOre.GetComponent<Ore>());
        }
    }

    public void ActiveOre()
    {
        oreCheck = "5";
        startTime = Time.time;
        oreActive = oresNeeded[Random.Range(0, oresNeeded.Count)].oreType;
        switch (oreActive)
        {
            case Ore.OreType.Mithril:
                oreCheck = "0";
                activeOre = mithrilOre;
                currentOre = mithrilOre.GetComponent<Ore>();
                //mithrilController.SetActive(true);     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
                break;
            case Ore.OreType.Adamantite:
                oreCheck = "1";
                activeOre = adamantiteOre;
                currentOre = adamantiteOre.GetComponent<Ore>();
                //adamantiteController.SetActive(true);     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
                break;
            case Ore.OreType.Gold:
                oreCheck = "2";
                activeOre = goldOre;
                currentOre = goldOre.GetComponent<Ore>();
                //goldController.SetActive(true);     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
                break;
            case Ore.OreType.Pyronium:
                oreCheck = "3";
                activeOre = pyroniumOre;
                currentOre = pyroniumOre.GetComponent<Ore>();
                //pyroniumController.SetActive(true);     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
                break;
            case Ore.OreType.Silver:
                oreCheck = "4";
                activeOre = silverOre;
                currentOre = silverOre.GetComponent<Ore>();
                //silverController.SetActive(true);     //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
                break;
        }

        stringMessage = "9";
        stringMessage += oreCheck;
        //serialController.SendSerialMessage(stringMessage);
        //print(stringMessage);
        //Invoke("DeactivateOre", 3f);
        
    }*/

    public void DeactivateOre()
    {
        startTime = Time.time;
            //serialController.SendSerialMessage("99");
            oreActive = Ore.OreType.None;            
            activeOre = null;
            /*mithrilController.SetActive(false);       //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
            adamantiteController.SetActive(false);    //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
            goldController.SetActive(false);          //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
            pyroniumController.SetActive(false);      //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
            silverController.SetActive(false);*/        //////// FOR VISUAL ONLY. DELETE ON FINAL BUILD.
            
            Invoke("ActiveOre", 3f);
    }
       
}
