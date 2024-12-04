using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiniGameCollection.Games2024.Team13
{
    public class Puzzle1 : MonoBehaviour
    {
        public GameObject player2;       // Assign Player2 in the Inspector
        public Vector3 resetPosition;    // Set the position you want Player2 to reset to
        void OnCollisionEnter(Collision collision)
        {
            // Check if the object that Player2 collides with has the tag "Danger"
            if (collision.gameObject.CompareTag("Danger"))
            {
                ResetPlayer();
            }
        }
        void ResetPlayer()
        {
            // Move Player2 to the reset position
            player2.transform.position = resetPosition;
            // Optional: Reset Player2's velocity if they have a Rigidbody component
            Rigidbody rb = player2.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}