using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04BulletSpawner : MonoBehaviour
    {
        public GameObject Bullet;
        public GameObject Player1;
        public GameObject Player2;

        public int player1Cooldown;
        public int player2Cooldown;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            player1Cooldown--;
            player2Cooldown--;

            if (Input.GetKeyDown(KeyCode.E) && player1Cooldown <= 0)
            {
                SpawnBullet(Player1);
                player1Cooldown = 30;
            }
            if (Input.GetKeyDown(KeyCode.Period) && player2Cooldown <= 0)
            {
                SpawnBullet(Player2);
                player2Cooldown = 30;
            }
        }

        void SpawnBullet(GameObject ParentShrimp)
        {
            GameObject bulletNow = Instantiate(Bullet, ParentShrimp.transform.position + ParentShrimp.transform.up * 3, ParentShrimp.transform.rotation);

            bulletNow.GetComponent<Rigidbody2D>().velocity = bulletNow.transform.up * 8;
            bulletNow.GetComponent<Rigidbody2D>().velocity += ParentShrimp.GetComponent<Rigidbody2D>().velocity;

            bulletNow.GetComponent<SpriteRenderer>().color = ParentShrimp.GetComponent<SpriteRenderer>().color;

            ParentShrimp.GetComponent<Rigidbody2D>().velocity = ParentShrimp.transform.up * -4;
        }
    }
}
