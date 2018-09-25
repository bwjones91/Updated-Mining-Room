/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;


/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class MessageListener : MonoBehaviour
{

    public SerialController serialController;

    public delegate void HitAction(Ore.OreType type);
    public static event HitAction OnHit;

    void Start()
    {
        serialController = GameObject.Find("Piezo Serial Controller").GetComponent<SerialController>();

        Debug.Log("Press A or Z to execute some actions");
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {

        OnHit(MessageToOretype(msg));
        //print(msg);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Sending A");
            serialController.SendSerialMessage("A");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Sending Z");
            serialController.SendSerialMessage("Z");
        }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }

    private Ore.OreType MessageToOretype(string message)
    {
        switch (message)
        {
            case "0":
                return Ore.OreType.Mithril;
            case "1":
                return Ore.OreType.Adamantite;
            case "2":
                return Ore.OreType.Gold;
            case "3":
                return Ore.OreType.Pyronium;
            case "4":
                return Ore.OreType.Silver;
            default:
                return Ore.OreType.None;
        }
    }



}
