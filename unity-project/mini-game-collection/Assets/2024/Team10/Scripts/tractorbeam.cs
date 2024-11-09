using MiniGameCollection.Games2024.Team10;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tractorbeam : MonoBehaviour
{

    public GameObject holdLocation;
    public GameObject itemInBeam;
    public Rigidbody itemInBeamRB;
    private bool beamActivated;
    public Transform playerTransform;
    public bool isHolding;
    public int beamCooldown = 5;
    public int puckLaunchForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;

    }

    // Update is called once per frame
    void Update()
    {
        beamActivated = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown (KeyCode.Period);
        TractorBeam();

        if (beamCooldown != 0f)
        {
            beamCooldown--;
        }


    }

    public void TractorBeam()
    {
        //Debug.DrawRay(playerTransform.position, -playerTransform.right * 5, Color.red, 2f);
        if (isHolding == false && beamActivated == true)

        {           
            if (itemInBeam != null && itemInBeam != CompareTag("World"))
            {
                itemInBeam.gameObject.transform.position = holdLocation.transform.position;
                isHolding = true;
            }
        }
        else if (isHolding == true && beamActivated == false)
        {
            if (itemInBeamRB != null && itemInBeam != CompareTag("World"))
            itemInBeam.gameObject.transform.position = holdLocation.transform.position;
        }
        else if (isHolding == true && beamActivated == true)
        {
            Vector3 launchDirection = -playerTransform.right;
            itemInBeamRB.AddForce(launchDirection * puckLaunchForce, ForceMode.Impulse);
            isHolding = false;
            beamCooldown = 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puck"))
        {
            if (beamCooldown == 0)
            {
                itemInBeam = other.gameObject;
                itemInBeamRB = other.GetComponent<Rigidbody>();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Puck"))
        {
            itemInBeam = other.gameObject;
            itemInBeamRB = other.GetComponent<Rigidbody>();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (isHolding == false)
        {
            itemInBeam = null;
            itemInBeamRB = null;


        }
    }
}
