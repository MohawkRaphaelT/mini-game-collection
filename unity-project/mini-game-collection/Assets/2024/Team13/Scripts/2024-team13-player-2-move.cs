using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team13
{
    public class Player2Move : MonoBehaviour
    {
        // Movement variables
        public float moveSpeed = 5f;
        // A Vector3 to store the player's location
        private Vector3 movement;
        // Component variable for the Rigidbody
        private Rigidbody rb;
        // Jump variables
        public float jumpHeight = 8f;
        private bool isGrounded;
        public LayerMask groundLayer;

        // Start is called before the first frame update
        void Start()
        {
            // Initialize the Rigidbody variable
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }

        private void Update()
        {
            // Ground check using raycast
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f, groundLayer);
            // Jump input using the ArcadeInput system for Player 2
            if (ArcadeInput.Player2.Action1.Pressed && isGrounded)
            {
                rb.AddForce(new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z), ForceMode.Impulse);
            }
        }

        void FixedUpdate()
        {
            // Get horizontal and vertical movement from the ArcadeInput system for Player 2
            float h = ArcadeInput.Player2.AxisX;
            float v = ArcadeInput.Player2.AxisY;
            // Move the player
            Move(h, v);
        }

        void Move(float hSpeed, float vSpeed)
        {
            // Calculate movement vector
            movement = (transform.forward * vSpeed) + (transform.right * hSpeed);
            // Normalize movement and apply speed and deltaTime
            movement = movement.normalized * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }
    }
}