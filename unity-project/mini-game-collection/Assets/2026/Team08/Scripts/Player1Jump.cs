using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player1Jump : MonoBehaviour
{   
    float position;
    public float airTime = 175;
    float timer;

    bool hasJumped;

    GameObject Shadow1;

    // Reference to the PlayerAnimations script
    public PlayerAnimations playAnims;

    // Start is called before the first frame update
    void Start()
    {
        timer = airTime;
        position = transform.position.y;

        // Get the PlayerAnimations component from the Player1 GameObject
        playAnims = GameObject.Find("Player1").GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (hasJumped == false)
            {
                hasJumped = true;
                position += 2; //Moves their y position up
                playAnims.anim.SetBool("isJumping", true); // Sets the animation to jumping
            }


        }
        else if (hasJumped == true) 
        {
            if (timer < 0)
            {
                position -= 2;
                hasJumped = false;
                timer = airTime;
                playAnims.anim.SetBool("isJumping", false); // Sets the animation back to running / idle
            }
            else if (timer >= 0) { timer = timer - 1; } //Counts down how long they can stay in the air
        }

        transform.position = new Vector3(transform.position.x, position, transform.position.z);
    }
}
