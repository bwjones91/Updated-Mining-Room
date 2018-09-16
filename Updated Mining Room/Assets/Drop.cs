using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public OreSwitcher oreSwitcher;
    public HitChecker hitChecker;
    public float hitAmount;

    private bool oreDrop = false;

    [SerializeField] float hitThreshold = 3;


	void Start () {
        oreSwitcher = GameObject.Find("Ore Controller").GetComponent<OreSwitcher>();
        hitChecker = GameObject.Find("Ore Controller").GetComponent<HitChecker>();
    }
	
	void Update () {
		if(oreSwitcher.activeOre == hitChecker.oreHit)
        {
            hitAmount++;
        }

        if(hitAmount >= hitThreshold)
        {
            oreDrop = true;
        }

        if (oreDrop)
        {
            oreDrop = false;
            Instantiate(oreSwitcher.activeOre);
        }

	}
}
