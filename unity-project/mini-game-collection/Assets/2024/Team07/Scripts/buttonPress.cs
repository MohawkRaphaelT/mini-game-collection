using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public static float pressDistance = 2f;
    public static KeyCode interactKey = KeyCode.E;

    private Transform player1;
    public static bool inRange = false;

    public void PressButton()
    {
        Debug.Log("Pressed");
    }

    private void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        
            player1 = playerObject.transform;
            Debug.Log("Player found: " + playerObject.name);

        // player1 = GameObject.FindGameObjectsWithTag("Player").transform;

    }


    // Update is called once per frame
    private void Update()
    {
        if (player1 == null) return;
        float distance = Vector3.Distance(player1.position, transform.position);
        inRange = distance <= pressDistance;

        if(inRange && Input.GetKeyDown(interactKey))
        {
            PressButton();
        }
    }
}
