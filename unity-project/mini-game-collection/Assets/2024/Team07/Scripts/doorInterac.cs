using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject DoorC;
    public static int doorTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        //countdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPress.inRange == true && Input.GetKeyDown(buttonPress.interactKey))
        {
            this.gameObject.GetComponent<Renderer>().enabled = false; // disables the renderer 
            DoorC.GetComponent<BoxCollider>().enabled = false; //disable collider

            //countdown();
            InvokeRepeating("countdown", 0.0f, 5f);


        }

    }

    void countdown()
    {
        //while (doorTimer == 5 ^ doorTimer > 0)
        //{

        doorTimer--;

        Debug.Log("doorTimer -1");


        if (doorTimer == 0 || Input.GetKeyUp(buttonPress.interactKey))
        {
            //doorTimer--;
            // Debug.Log("doorTimer -1");

            Debug.Log("=0");
            this.gameObject.GetComponent<Renderer>().enabled = true;
            DoorC.GetComponent<BoxCollider>().enabled = true;
            doorTimer = 5;
        }
        //}
    }
}
