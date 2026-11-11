using MiniGameCollection;
using MiniGameCollection.Games2026.Team04;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Team04PickUpZone : MiniGameBehaviour
{
    private BoxCollider2D boxCollider;

    private void OnValidate()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (transform.parent.GetComponent<Team04PlayerController>().direction == "left")
        {
            transform.localPosition -= transform.localPosition;
            transform.localPosition += Vector3.left * 1.3f;
        }
        else if (transform.parent.GetComponent<Team04PlayerController>().direction == "right")
        {
            transform.localPosition -= transform.localPosition;
            transform.localPosition += Vector3.right * 1.3f;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Team04RedBox>() != null &&
            transform.parent.GetComponent<Team04PlayerController>().PlayerID == Team04PlayerID.Player1 &&
            ArcadeInput.Player1.Action2.Pressed)
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }

        if (collision.gameObject.GetComponent<Team04BlueBox>() != null &&
            transform.parent.GetComponent<Team04PlayerController>().PlayerID == Team04PlayerID.Player2 &&
            ArcadeInput.Player2.Action2.Pressed)
        {
            transform.parent = collision.gameObject.transform;
        }
    }


    //public bool BoxCheck() { }
}
