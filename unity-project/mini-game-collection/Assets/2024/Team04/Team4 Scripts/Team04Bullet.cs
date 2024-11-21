using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MiniGameCollection.ArcadeInput;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04Bullet : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "2024-team04-player1" || collision.gameObject.name == "2024-team04-player2")
            {
                //health?
            }
            else if (collision.gameObject.name == "2024-team04-wall1" || collision.gameObject.name == "2024-team04-wall2"|| collision.gameObject.name == "2024-team04-wall3"|| collision.gameObject.name == "2024-team04-wall4" 
                || collision.gameObject.name == "2024-team04-whale-1" || collision.gameObject.name == "2024-team04-whale-2" || collision.gameObject.name == "2024-team04-whale-3" || collision.gameObject.name == "2024-team04-whale-4")
            {
                //just dont do anythin
            }
            else
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
            
        }
    }
}
