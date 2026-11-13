using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] trackSegments;

    public float startingSpeed = 5f;
    public float acceleration = 0.5f;

    private float speed;

    public float maxSpeed = 15f;

    public float segmentWidth = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Min(speed + acceleration * Time.deltaTime, maxSpeed);

        foreach (GameObject TrackSegment in trackSegments)
        {
            TrackSegment.transform.position +=
                Vector3.left * speed * Time.deltaTime;

            // Check if segment has left the screen
            if (TrackSegment.transform.position.x < -17)
            {
                // Find the rightmost segment
                float rightmost = GetRightmostSegment();

                // Reposition the segment
                TrackSegment.transform.position = new Vector3(
                    rightmost + segmentWidth,
                    TrackSegment.transform.position.y,
                    TrackSegment.transform.position.z
                );
            }
        }
    }
    float GetRightmostSegment()
    {
        float rightmost =
            trackSegments[0].transform.position.x;

        foreach (GameObject segment in trackSegments)
        {
            if (segment.transform.position.x > rightmost)
            {
                rightmost = segment.transform.position.x;
            }
        }


        return rightmost;
    }
    public void ResetSpeed()
    {
        speed = startingSpeed;
    }
}
