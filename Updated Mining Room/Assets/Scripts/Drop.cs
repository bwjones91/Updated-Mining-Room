using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public OreSwitcher oreSwitcher;
    public float hitAmount;
    public GameObject thisOre;

    [SerializeField] float hitThreshold = 3;
    [SerializeField] Ore.OreType thisType;
    private string stringMessage;

    public SerialController serialController;

    void OnEnable()
    {
        hitAmount = 0;
    }

    void OnDisable()
    {
        hitAmount = 0;
    }

    void Start () {
        oreSwitcher = GameObject.Find("Ore Controller").GetComponent<OreSwitcher>();
        MessageListener.OnHit += OreHit;
        serialController = GameObject.Find("Piezo Serial Controller").GetComponent<SerialController>();
    }
	
	void Update () {

	}

    void OreHit(Ore.OreType type)
    {
        if(type == thisType/* && thisType == oreSwitcher.oreActive*/)
        {
            hitAmount++;
            if (hitAmount >= hitThreshold)
            {
                Instantiate(thisOre);
                stringMessage = EnumtoChar(type).ToString();
                stringMessage += hitAmount;
                serialController.SendSerialMessage(stringMessage);
                hitAmount = 0;
                //oreSwitcher.DeactivateOre();
                print(stringMessage);
            }
            else
            {
                stringMessage = EnumtoChar(type).ToString();
                stringMessage += hitAmount;
                serialController.SendSerialMessage(stringMessage);
                print(stringMessage);
            }
        }
    }

    

    public string EnumtoChar(Ore.OreType type)
    {
        switch (type)
        {
            case Ore.OreType.Mithril:
                return "0";                
            case Ore.OreType.Adamantite:
                return "1";                
            case Ore.OreType.Gold:
                return "2";
            case Ore.OreType.Pyronium:
                return "3";
            case Ore.OreType.Silver:
                return "4";
            default:
                return "5";
        }
    }

}
