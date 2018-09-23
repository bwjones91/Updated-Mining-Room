using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecraftMovement : MonoBehaviour {

    public float minecartSpeed;
    public float thrustVariable;
    public float localSpeed;
    public float maxSpeed;
    
    private ArduinoCommunicator AC;
    private float thrustDirection;
    private float leverMovement;
    private float thrust;
    private Rigidbody rb;
    private bool speedLimiterLeft;

    void Start () {
        rb = this.GetComponent<Rigidbody>();
        AC = GameObject.Find("Potentiometer Arduino Communication").GetComponent<ArduinoCommunicator>();
        thrustDirection = -1f;
        speedLimiterLeft = true;
    }
	
	void Update () {
        leverMovement = Mathf.Abs(AC.GetMessageIN());
        print(leverMovement);

        minecartSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        var localSpeed = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);

        if (localSpeed.x < maxSpeed && speedLimiterLeft == false)
        {
            thrustDirection = 1f;
        }

        if (localSpeed.x > -maxSpeed && speedLimiterLeft == true)
        {
            thrustDirection = -1f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speedLimiterLeft = true;
            if (localSpeed.x > -maxSpeed)
            {
                thrustDirection = -1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && localSpeed.x < maxSpeed)
        {
            speedLimiterLeft = false;
            if (localSpeed.x < maxSpeed)
            {
                thrustDirection = 1f;
            }
        }

        if (localSpeed.x >= maxSpeed && speedLimiterLeft == false)
        {
            thrustDirection = 0f;
        }

        if (localSpeed.x <= -maxSpeed && speedLimiterLeft == true)
        {
            thrustDirection = 0f;
        }
    }

    private void FixedUpdate()
    {
        thrust = (leverMovement) * thrustVariable;
        rb.AddForce(new Vector3(thrustDirection, 0f, 0f) * thrust);
    }

}