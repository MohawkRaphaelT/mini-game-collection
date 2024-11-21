using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameCollection.Games2024.Team05
{
    public class PlayerMovement : MonoBehaviour
    {
        //float variable for movement
        public float moveSpeed;

        //Variable to reference the Rigidbody2D component
        //Variable declared
        private Rigidbody rb2d;

        //Create variable references to the animator 
        private Animator anim;

        //Create a variable reference to the SpriteRenderer
        private SpriteRenderer sr;

        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody>();

            //initalize the Animator
            anim = GetComponent<Animator>();

            //initalize the SpriteRenderer
            sr = GetComponent<SpriteRenderer>();
        }

        // FixedUpdate is called at an average rate per frame
        void FixedUpdate()
        {
            //Gets unity horizontal parameters.
            float h = Input.GetAxis("Horizontal");

            //Vector2 is x and y. unity has vector2 (x and y) and Vector3 (x, y and z)
            //Rigidbody has a built in parameter of velocity (speed in a direction)
            //here we are setting the rb2d.velocity to a new Vector2 where the x value is whatever
            //h is * moveSpeed. The y value does not change.
            //This means that the x value of the rb2d.velocity can be a minimum of -5,0, or a maximum of +5
            rb2d.velocity = new Vector2(h * moveSpeed, rb2d.velocity.y);

            //Animation Town
            //Mathf.Abs is "absolute value" which ignores the sign next to the number. ex -, =, +.
            anim.SetFloat("runSpeed", Mathf.Abs(h));

            //Flip the SpriteRenderer if the player is moving left/ 
            if (h < 0)
            {
                sr.flipX = true;
            }
            else if (h > 0)
            {
                sr.flipX = false;
            }
        }

        //Setting what the player can collide/interact with 
        private void OnTriggerEnter2D(Collider2D collision)
        {

        }
    }
}