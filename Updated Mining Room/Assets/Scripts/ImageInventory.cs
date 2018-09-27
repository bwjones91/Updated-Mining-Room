using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageInventory : MonoBehaviour {

    //Image myImage;
    //public Sprite mySprite;

    public Image[] images;

    void Start () {
        //myImage = GetComponent<Image>();
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            //myImage.sprite = mySprite;
            //var activeColor = myImage.color;
            //activeColor.a = 1f;
            //myImage.color = activeColor;
        }
	}
}
