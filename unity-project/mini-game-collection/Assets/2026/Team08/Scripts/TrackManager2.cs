
using UnityEngine;


public class TrackManager2 : MonoBehaviour
{
    public GameObject[] trackSegments;

    public GameObject[] obstacles;

    public float score2;

    public float startingSpeed = 5f;
    public float acceleration = 0.5f;

    private float speed;

    public float maxSpeed = 15f;

    public float segmentWidth = 1f;

    //Limits how fast the player can go
    public float speedCap = 7f;

    // Reference to the PlayerAnimations script
    public PlayerAnimations playAnims;

    //Rubberband to give player an advantage
    public bool dropItem = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the PlayerAnimations component from the Player1 GameObject
        playAnims = GameObject.Find("Player2").GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObjects();
        if (Input.GetKey(KeyCode.D))
        {
            speed = Mathf.Min(speed + acceleration * Time.deltaTime, speedCap);

            foreach (GameObject TrackSegment in trackSegments)
            {
                TrackSegment.transform.position += Vector3.left * speed * Time.deltaTime;
                score2 = score2 + (speed * 1);

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
            // Set the "isMoving" parameter in the Animator to 1 when the player is moving
            playAnims.anim.SetFloat("isMoving", 1);

        }
        else
        {
            speed = 0;
            playAnims.anim.SetFloat("isMoving", 0);
        }

        if (Input.GetKey(KeyCode.A)){
            if (dropItem == true){
                Debug.Log("PLAyer 2 activated their special");
          
                    dropItem = false;
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
        speed = 0f;
    }

    public float GetSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Spawns objects as player travels
    /// </summary>
    public void SpawnObjects()
    {
        
        if (score2 > 1) //Will not generate object when player is first starting
        {
            int randomNumber = 0;
            if (speed < 2) { randomNumber = Random.Range(1, 3000); }
            else if ((speed >= 2) && (speed < 4)) { randomNumber = Random.Range(1, 2000); }
            else if ((speed >= 4) && (speed < 7)) { randomNumber = Random.Range(1, 1000); }
            else if ((speed >= 7) && (speed < 10)) { randomNumber = Random.Range(1, 500); }
            else if ((speed >= 10)) { randomNumber = Random.Range(1, 300); }
            if (randomNumber == 1)
            {
                int randomObstacle = Random.Range(0, 3);
                Instantiate(obstacles[randomObstacle], new Vector3(transform.position.x + 10, transform.position.y - 2, transform.position.z), Quaternion.identity);
            }
        }

    }
}
