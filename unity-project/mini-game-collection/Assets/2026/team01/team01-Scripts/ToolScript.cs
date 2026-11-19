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
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if parent is not a Player
            if (!transform.parent.GetComponent<TagPlayer>())
            {
                // Check if collider is a Player
                if (collision.GetComponent<TagPlayer>())
                {
                    // Check that the cooldown isn't active
                    if (CooldownTimer <= 0)
                    {
                        // Check to make sure the player isn't holding any other tools
                        if (!collision.GetComponentInChildren<ToolScript>())
                        {
                            // Set parent to that Player
                            transform.SetParent(collision.transform);
                        }
                    }
                }
            }

        }
        public void Drop()
        {
            transform.parent = OriginalParent.transform;
            CooldownTimer = CooldownTime;
        }
    }
}
