using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OresNeeded : MonoBehaviour {

    public List<Ore> oresRequired = new List<Ore>();

    public OreSwitcher oreSwitcher;

    int mithrilRequired;
    int adamantiteRequired;
    int goldRequired;
    int pyroniumRequired;
    int silverRequired;

	void Start () {
		oreSwitcher = GameObject.Find("Ore Controller").GetComponent<OreSwitcher>();
        OresRequired(1);
    }
	
	void Update () {
		
	}

    public void OresRequired(int wave)
    {
        mithrilRequired = Random.Range(0, 2) * wave;
        adamantiteRequired = Random.Range(1, 2) * wave;
        goldRequired = Random.Range(1, 3) * wave;
        pyroniumRequired = Random.Range(1, 2) * wave;
        silverRequired = Random.Range(0,2) * wave;
        print(mithrilRequired);
        print(adamantiteRequired);
        print(goldRequired);
        print(pyroniumRequired);
        print(silverRequired);
        for (int i = 0; i < mithrilRequired; i++)
        {
            oresRequired.Add(oreSwitcher.mithrilOre.GetComponent<Ore>());
        }
        for (int i = 0; i < adamantiteRequired; i++)
        {
            oresRequired.Add(oreSwitcher.adamantiteOre.GetComponent<Ore>());
        }
        for (int i = 0; i < goldRequired; i++)
        {
            oresRequired.Add(oreSwitcher.goldOre.GetComponent<Ore>());
        }
        for (int i = 0; i < pyroniumRequired; i++)
        {
            oresRequired.Add(oreSwitcher.pyroniumOre.GetComponent<Ore>());
        }
        for (int i = 0; i < silverRequired; i++)
        {
            oresRequired.Add(oreSwitcher.silverOre.GetComponent<Ore>());
        }
    }

}
