using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public OreSwitcher oreSwitcher;
    public float hitAmount;
    public GameObject thisOre;

    [SerializeField] float hitThreshold = 3;
    [SerializeField] Ore.OreType thisType;

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
    }
	
	void Update () {

	}

    void OreHit(Ore.OreType type)
    {
        if(type == thisType && thisType == oreSwitcher.oreActive)
        {
            hitAmount++;
            if(hitAmount >= hitThreshold)
            {
                Instantiate(thisOre);
                hitAmount = 0;
            }
        }
    }

}
