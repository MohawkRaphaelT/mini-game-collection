using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2026.Team01
{
    
    public class ToolScript : MiniGameBehaviour
    {
        [SerializeField] private GameObject OriginalParent;
        private float CooldownTime = 2f;
        private float CooldownTimer;

        private void Update()
        {
            // Update cooldown timer
            if (CooldownTimer > 0)
            {
                CooldownTimer -= Time.deltaTime;
            }

            // Check flip on sprite
        }
        // NOTE: .parent is always the handle
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if parent is not a Player
            if (!transform.parent.parent.parent.GetComponent<TagPlayer>())
            {
                // Check if collider is a Player
                if (collision.GetComponent<TagPlayer>())
                {
                    // Check that the cooldown isn't active
                    if (CooldownTimer <= 0)
                    {
                        Transform hand = collision.transform.Find("Hand");
                        // Check to make sure the player isn't holding any other tools
                        if (!hand.GetComponentInChildren<ToolScript>())
                        {
                            // Set parent to that Player
                            transform.parent.SetParent(hand);
                            transform.position = hand.transform.position;
                        }
                    }
                }
            }

        }
        public void Drop()
        {
            transform.parent.parent = OriginalParent.transform;
            CooldownTimer = CooldownTime;
        }
    }
}
