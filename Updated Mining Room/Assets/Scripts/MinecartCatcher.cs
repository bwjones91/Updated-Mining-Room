using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinecartCatcher : MonoBehaviour {

    public List<Ore> oresCaught = new List<Ore>();

    private string stringMessage;
    private Ore instance;
    private int oreCheck;

    public GameObject mithrilOre;
    public GameObject adamantiteOre;
    public GameObject goldOre;
    public GameObject pyroniumOre;
    public GameObject silverOre;

    public Shopkeeper shopkeeper;
    public OresRequired oresRequired;
    public SerialController serialController;
    public bool hasBeenHit = false;
    public Ore oreThrown;

    private Sprite setSprite;
    public Sprite mithrilSprite;
    public Sprite adamantiteSprite;
    public Sprite goldSprite;
    public Sprite pyroniumSprite;
    public Sprite silverSprite;
    public Image[] minecartImages;
    public GameObject canvas;

    int imageNumber = 0;


    void Start () {
        serialController = GameObject.Find("Piezo Serial Controller").GetComponent<SerialController>();
        oresRequired = GameObject.Find("Shopkeeper").GetComponent<OresRequired>();
        shopkeeper = GameObject.Find("Shopkeeper").GetComponent<Shopkeeper>();
        minecartImages = canvas.GetComponentsInChildren<Image>();
    }
	
	void Update () {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Ore")
        {
            switch (collider.GetComponent<Ore>().oreType)
            {
                case Ore.OreType.Mithril:
                    oresCaught.Add(mithrilOre.GetComponent<Ore>());
                    oreCheck = 0;
                    setSprite = mithrilSprite;
                    break;
                case Ore.OreType.Adamantite:
                    oresCaught.Add(adamantiteOre.GetComponent<Ore>());
                    oreCheck = 1;
                    setSprite = adamantiteSprite;
                    break;
                case Ore.OreType.Gold:
                    oresCaught.Add(goldOre.GetComponent<Ore>());
                    oreCheck = 2;
                    setSprite = goldSprite;
                    break;
                case Ore.OreType.Pyronium:
                    oresCaught.Add(pyroniumOre.GetComponent<Ore>());
                    oreCheck = 3;
                    setSprite = pyroniumSprite;
                    break;
                case Ore.OreType.Silver:
                    oresCaught.Add(silverOre.GetComponent<Ore>());
                    oreCheck = 4;
                    setSprite = silverSprite;
                    break;
            }

            AssignImageSprite();

            imageNumber++;
            stringMessage = "8";
            stringMessage += oreCheck;
            serialController.SendSerialMessage(stringMessage);

            if (oresRequired.oresRequired.Count == oresCaught.Count)
            {
                if (CompareLists(oresRequired.oresRequired, oresCaught))
                {
                    print("Equal");
                    shopkeeper.InitiateWave();
                }
                else
                {
                    print("Not equal");
                }
                oresCaught.Clear();
                ClearImageSprite();

            }
        }
        else if(collider.gameObject.tag == "Enemy")
        {
            ThrowOre();
        }
    }

    public static bool CompareLists<T>(List<T> aListA, List<T> aListB)
    {
        if (aListA == null || aListB == null || aListA.Count != aListB.Count)
            return false;
        if (aListA.Count == 0)
            return true;
        Dictionary<T, int> lookUp = new Dictionary<T, int>();
        // create index for the first list
        for (int i = 0; i < aListA.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListA[i], out count))
            {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }
        for (int i = 0; i < aListB.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListB[i], out count))
            {
                // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                return false;
            }
            count--;
            if (count <= 0)
                lookUp.Remove(aListB[i]);
            else
                lookUp[aListB[i]] = count;
        }
        // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
        return lookUp.Count == 0;
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
                oresRequired.oresRequired.Add(oreThrown.GetComponent<Ore>());
                oresCaught.Remove(oreThrown.GetComponent<Ore>());

            }
        }
    }


    public void AssignImageSprite()
    {
        minecartImages[imageNumber].sprite = setSprite;
        var activeColor = minecartImages[imageNumber].color;
        activeColor.a = 1f;
        minecartImages[imageNumber].color = activeColor;
    }

    public void ClearImageSprite()
    {
        for(int i = 0; i < imageNumber; i++)
        {
            minecartImages[i].sprite = null;
            var activeColor = minecartImages[i].color;
            activeColor.a = 0f;
            minecartImages[i].color = activeColor;
        }
    }

}
