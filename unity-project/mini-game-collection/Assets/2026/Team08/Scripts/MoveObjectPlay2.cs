using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectPlay2 : MonoBehaviour
{
    //Player script to recieve the public float score of the first player. 
    public TrackManager2 player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<TrackManager2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.left * player.GetSpeed() * Time.deltaTime;
        }
        if (transform.position.x < -10) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if colliding with player 1
        if (collision.gameObject.CompareTag("Player2"))
        {

            //Turns off the collision of the object so player can move past 
            GetComponent<BoxCollider2D>().enabled = false;

            //Resets their speed to 0 if hit an object 
            player.ResetSpeed();
        }
    }
}
