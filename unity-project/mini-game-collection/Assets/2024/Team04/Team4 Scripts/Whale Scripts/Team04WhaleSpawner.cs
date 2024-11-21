using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04WhaleSpawner : MonoBehaviour
    {
        public GameObject whale; //Variable to get the whale game object

        public float timeUntilSpawn = 10f; //Amount of time until whale spawns

        private bool isActivated = true; //Check if the spawn manager is activated

        [SerializeField]
        private float timeUntilDespawn = 20f; //The time it will take until the whale despawns


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(isActivated)
            {
                SpawnObject();
            }
            if (!isActivated)
            {
                timeUntilDespawn -= Time.deltaTime;

                if (timeUntilDespawn <= 0)
                {
                    timeUntilDespawn = 20.0f;
                    isActivated = true;
                }
            }

        }

        public void SpawnObject()
        {
            timeUntilSpawn -= Time.deltaTime;

            if (timeUntilSpawn <= 0)
            {                
                Instantiate(whale, transform.position, Quaternion.Euler(0, 0, 180));
                isActivated = false;
                timeUntilSpawn = 10;
            }            
        }
        
    }
}


