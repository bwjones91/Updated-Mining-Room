﻿using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour {

    public Vector3 direction;
	
	// Update is called once per frame
	void Update ()
	{
        transform.Rotate( direction * Time.deltaTime );
	}
}
