using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04NewWhaleScript : MonoBehaviour
    {
        public GameObject Whale1;
        public GameObject Warning1;
        public GameObject Whale2;
        public GameObject Warning2;
        public GameObject Whale3;
        public GameObject Warning3;
        public GameObject Whale4;
        public GameObject Warning4;

        public GameObject CurrentWhale;
        public GameObject CurrentWarning;

        public int countdown;
        public int wait;
        public int pickWhale;
        public int whaleSpeed;
        public Vector3 returnSpawn;
        // Start is called before the first frame update
        void Start()
        {
            countdown = 120;
            PickWhale();
            wait = -1;
        }

        // Update is called once per frame
        void Update()
        {
            countdown--;
            wait--;


            if (countdown == 0)
            {
                CurrentWarning.GetComponent<SpriteRenderer>().enabled = true;
                wait = 260;
            }
            if (wait == 120)
            {
                whaleSpeed = 20;
                CurrentWarning.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (wait == 0)
            {
                whaleSpeed = 0;
                CurrentWhale.GetComponent<Rigidbody2D>().velocity = CurrentWhale.transform.right * whaleSpeed;
                CurrentWhale.transform.position = returnSpawn;
                PickWhale();
                countdown = Random.Range(600, 1200);
            }

            if (pickWhale == 1 || pickWhale == 2)
            {
                CurrentWhale.GetComponent<Rigidbody2D>().velocity = CurrentWhale.transform.right * whaleSpeed;
            }
            else if (pickWhale == 3 || pickWhale == 4)
            {
                CurrentWhale.GetComponent<Rigidbody2D>().velocity = -CurrentWhale.transform.right * whaleSpeed;
            }
        }
        void PickWhale()
        {
            pickWhale = Random.Range(1, 5);


            if (pickWhale == 1)
            {
                CurrentWhale = Whale1;
                CurrentWarning = Warning1;
            }
            if (pickWhale == 2)
            {
                CurrentWhale = Whale2;
                CurrentWarning = Warning2;
            }
            if (pickWhale == 3)
            {
                CurrentWhale = Whale3;
                CurrentWarning = Warning3;
            }
            if (pickWhale == 4)
            {
                CurrentWhale = Whale4;
                CurrentWarning = Warning4;
            }

            returnSpawn = CurrentWhale.transform.position;
        }
    }
}