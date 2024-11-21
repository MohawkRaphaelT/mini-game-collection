using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team05
{

    public class PlayerJump : MonoBehaviour
    {

        // Jump variables.
        //Learning about headers for name organizing.
        [Header("Jumping functions")]
        public float jumpHeight = 12; // setting player jump height
        public float lowJumpMultiplier = 2f; //speed up your fall if you tap the jump button as opposed to holding it
        public float fallMultiplier = 2.5f; // Fall will get faster the longer you fall.

        //Boolean function to check if the player is planted on the ground or not.
        [SerializeField]
        private bool isGrounded;

        //Special variable called LayerMask that can "Mask Layers"
        public LayerMask groundLayer;

        //Variable to access Rigidbody2D
        private Rigidbody2D rb2d;

        //coyote time variables.
        public float coyoteTime;
        public float coyoteTimeMax = 0.2f;

        //setting transform on "feet"
        public Transform feet;

        //variable to access the Animator
        private Animator anim;

        void Start()
        {
            //initalize Rigidbody2D variable
            rb2d = GetComponent<Rigidbody2D>();

            //Setting the time of coyoteTime as the set max.
            coyoteTime = coyoteTimeMax;

            anim = GetComponent<Animator>();
        }

        void Update()
        {
            //check every frame for a collison with the ground using raycast
            //raycast is a "line of collision" with the following parameters
            //(origin point, direction, size) and then several optional parameters from there. we are also using a fourth
            //parameter of "layermask" which will tell it which specifically layer to collide with
            isGrounded = Physics2D.Raycast(feet.position, Vector2.down, 0.5f, groundLayer);

            //Set the isJumping Animator bool to the opposite isGrounded
            //This saves time
            anim.SetBool("isJumping", !isGrounded);
            //keypresses
            if (Input.GetKeyDown(KeyCode.Space) && coyoteTime > 0)
            {
                //Player can jump
                //Modify the Rigidbody velocity
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);

                //Alternate
                //rb2d.AddForce(new Vector2(rb2d.velocity.x, rb2d.velocity.y * jumpHeight), ForceMode2D.Impulse);
            }

            //Gravity modification
            //if the y velocity of the rb2d is less than 0, the player is falling
            if (rb2d.velocity.y < 0)
            {
                //increase gravity
                //this modifies gravity
                rb2d.velocity += (Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
            }
            //if the rb2d velocity is greater than 0 and the player us not pressing the spacebar anymore
            else if (rb2d.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.velocity += (Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
            }
            //Coyote time stuff
            //if the player is on the ground, reset the coyote timer
            //if they are not on the ground, start counting down
            if (isGrounded)
            {
                coyoteTime = coyoteTimeMax;
            }
            else
            {
                //Countdown using Time.deltaTime
                //-= is the same as saying = coyoteTime - 1;
                coyoteTime -= Time.deltaTime;
            }

        }
    }
}
