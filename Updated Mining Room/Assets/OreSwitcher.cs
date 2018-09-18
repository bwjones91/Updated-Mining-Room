using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSwitcher : MonoBehaviour {

    public List<Ore> oresNeeded = new List<Ore>();

    public GameObject mithrilController;
    public GameObject adamantiteController;
    public GameObject goldController;
    public GameObject pyroniumController;
    public GameObject silverController;

    public GameObject mithrilOre;
    public GameObject adamantiteOre;
    public GameObject goldOre;
    public GameObject pyroniumOre;
    public GameObject silverOre;

    public GameObject activeOre;
    public string oreCheck;
    public Ore.OreType oreActive;
    public SerialController serialController;
    public string stringMessage;

    private float startTime;
    private float timer;
    private float timeToRestart = 3;

    int mithrilNeeded;
    int adamantiteNeeded;
    int goldNeeded;
    int pyroniumNeeded;
    int silverNeeded;

    void Start () {
        OresNeeded();
        Invoke("ActiveOre", 1f);
        serialController = GameObject.Find("Piezo Serial Controller").GetComponent<SerialController>();
        startTime = Time.time;
    }
	
	void Update () {
        timer += Time.deltaTime;
        if(timer - startTime >= timeToRestart)
        {
            DeactivateOre();
            startTime = Time.time;
        }
    }

    public void OresNeeded()
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
        startTime = Time.time;
        oreActive = oresNeeded[Random.Range(0, oresNeeded.Count)].oreType;
        switch (oreActive)
        {
            case Ore.OreType.Mithril:
                oreCheck = "0";
                activeOre = mithrilOre;
                mithrilController.SetActive(true);
                break;
            case Ore.OreType.Adamantite:
                oreCheck = "1";
                activeOre = adamantiteOre;
                adamantiteController.SetActive(true);
                break;
            case Ore.OreType.Gold:
                oreCheck = "2";
                activeOre = goldOre;
                goldController.SetActive(true);
                break;
            case Ore.OreType.Pyronium:
                oreCheck = "3";
                activeOre = pyroniumOre;
                pyroniumController.SetActive(true);
                break;
            case Ore.OreType.Silver:
                oreCheck = "4";
                activeOre = silverOre;
                silverController.SetActive(true);
                break;
        }

        stringMessage = "9";
        stringMessage += oreCheck;
        serialController.SendSerialMessage(stringMessage);
        //Invoke("DeactivateOre", 3f);
        
    }

    public void DeactivateOre()
    {
        startTime = Time.time;
            serialController.SendSerialMessage("99");
            oreActive = Ore.OreType.None;
            oreCheck = "5";
            activeOre = null;
            mithrilController.SetActive(false);
            adamantiteController.SetActive(false);
            goldController.SetActive(false);
            pyroniumController.SetActive(false);
            silverController.SetActive(false);

            Invoke("ActiveOre", 1f);
    }
       
}
