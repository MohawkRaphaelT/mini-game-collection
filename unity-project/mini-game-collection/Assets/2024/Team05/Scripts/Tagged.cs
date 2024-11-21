using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team05
{

    public class Tagged : MonoBehaviour
    {
        // Variables
        //Renderer rended;

        // Calling
        //public Player1 player1;
        //public Player2 player2;

        // I want variable to change but I still want
        // to see it visually
        [SerializeField]

        //string stringTagged;
        public bool isTagged;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isTagged = !isTagged;

                Debug.Log("isTagged is now: " + isTagged);
            }

            if (!collision.gameObject.CompareTag("Player"))
            {
                return;
            }

        }

            /* if(rended.sharedMaterial == player1.color[0] && isTagged)
             {
                 rended.sharedMaterial = player1.color[1];
                 isTagged = false;
             }

             else if(rended.sharedMaterial == player1.color[1] && !isTagged)
             {
                 rended.sharedMaterial = player1.color[0];
                 isTagged = true;
             }
         }*/


            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }
        }
    }
