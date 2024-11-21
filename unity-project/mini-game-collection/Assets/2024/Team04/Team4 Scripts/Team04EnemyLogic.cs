using MiniGameCollection.Games2024.Team04;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04EnemyLogic : MonoBehaviour
    {
        public GameObject player1;
        public GameObject player2;

        [SerializeField] private float enemySpeed = (float)0.1;
        [SerializeField] private int PlayerID;

        // Start is called before the first frame update
        void Start()
        {
            int randomNum = Random.Range(1, 3);
            PlayerID = randomNum;
            player1 = GameObject.Find("2024-team04-player1");
            player2 = GameObject.Find("2024-team04-player2");
        }

        // Update is called once per frame
        void Update()
        {

            if (PlayerID == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, player1.transform.position, 0.01f);
            }

            if (PlayerID == 2)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, player2.transform.position, 0.01f);
            }
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}

