using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team05
{

    public class PlayerController : MonoBehaviour
    {
        // Variables
        public float speed = 3f;
        public float gravity = -20f;
        public float jumpSpeed = 15;

        CharacterController characterController;

        private Vector3 moveDirection = Vector3.zero;
  

        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (characterController.isGrounded)
            {
                // Player is grounded
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= speed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }
            // Applying gravity
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
