using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OresRequired : MonoBehaviour {

    public List<Ore> oresRequired = new List<Ore>();

    public GameObject mithrilOre;
    public GameObject adamantiteOre;
    public GameObject goldOre;
    public GameObject pyroniumOre;
    public GameObject silverOre;

    int mithrilRequired;
    int adamantiteRequired;
    int goldRequired;
    int pyroniumRequired;
    int silverRequired;
    int imageNumber = 0;

    public Sprite mithrilSprite;
    public Sprite adamantiteSprite;
    public Sprite goldSprite;
    public Sprite pyroniumSprite;
    public Sprite silverSprite;
    public Image[] images;
    public GameObject canvas;

    void Start () {
        images = canvas.GetComponentsInChildren<Image>();
    }
	
	void Update () {

    }

    public void RequiredOres(int wave)
    {
        mithrilRequired = Random.Range(0, 2) * wave;
        adamantiteRequired = Random.Range(1, 2) * wave;
        goldRequired = Random.Range(1, 3) * wave;
        pyroniumRequired = Random.Range(1, 2) * wave;
        silverRequired = Random.Range(0,2) * wave;
        for (int i = 0; i < mithrilRequired; i++)
        {
            oresRequired.Add(mithrilOre.GetComponent<Ore>());
        }
        for (int i = 0; i < adamantiteRequired; i++)
        {
            oresRequired.Add(adamantiteOre.GetComponent<Ore>());
        }
        for (int i = 0; i < goldRequired; i++)
        {
            oresRequired.Add(goldOre.GetComponent<Ore>());
        }
        for (int i = 0; i < pyroniumRequired; i++)
        {
            oresRequired.Add(pyroniumOre.GetComponent<Ore>());
        }
        for (int i = 0; i < silverRequired; i++)
        {
            oresRequired.Add(silverOre.GetComponent<Ore>());
        }
        print(oresRequired.Count);
    }

    public void ClearRequiredOres()
    {
        oresRequired.Clear();
    }

    public void DisplayOresRequired()
    {
        for (int i = 0; i < oresRequired.Count; i++)
        {
            switch (oresRequired[i].oreType)
            {
                case Ore.OreType.Mithril:
                    images[i].sprite = mithrilSprite;
                    var activeColor = images[i].color;
                    activeColor.a = 1f;
                    images[i].color = activeColor;
                    break;
                case Ore.OreType.Adamantite:
                    images[i].sprite = adamantiteSprite;
                    activeColor = images[i].color;
                    activeColor.a = 1f;
                    images[i].color = activeColor;
                    break;
                case Ore.OreType.Gold:
                    images[i].sprite = goldSprite;
                    activeColor = images[i].color;
                    activeColor.a = 1f;
                    images[i].color = activeColor;
                    break;
                case Ore.OreType.Pyronium:
                    images[i].sprite = pyroniumSprite;
                    activeColor = images[i].color;
                    activeColor.a = 1f;
                    images[i].color = activeColor;
                    break;
                case Ore.OreType.Silver:
                    images[i].sprite = silverSprite;
                    activeColor = images[i].color;
                    activeColor.a = 1f;
                    images[i].color = activeColor;
                    break;
            }
        }
    }

    public void ClearImageSprite()
    {
        for (int i = 0; i < imageNumber; i++)
        {
            images[i].sprite = null;
            var activeColor = images[i].color;
            activeColor.a = 0f;
            images[i].color = activeColor;
        }
    }

}
