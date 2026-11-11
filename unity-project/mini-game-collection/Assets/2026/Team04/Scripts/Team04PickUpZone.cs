using MiniGameCollection;
using MiniGameCollection.Games2026.Team04;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team04PickUpZone : MiniGameBehaviour
{
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
}
