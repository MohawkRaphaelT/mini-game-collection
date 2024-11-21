using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team04
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemySpawnerPrefab;


        [SerializeField]
        private float enemySpawnerInterval;

        [SerializeField] private float minTimer = 2f;

        [SerializeField] private float maxTimer = 10f;

        // Start is called before the first frame update
        void Start()
        {
            SetSpawnTime();
            //StartCoroutine(spawnEnemy(enemySpawnerInterval, enemySpawnerPrefab));           
        }

        void Update()
        {
            EnemyBehaviour();
        }

        //// Update is called once per frame
        //private IEnumerator spawnEnemy( float interval, GameObject enemy)
        //{
        //    yield return new WaitForSeconds(interval);
        //    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(3f, 1), Random.Range(-3f, 1), 0), Quaternion.identity);
        //    StartCoroutine(spawnEnemy(interval, enemy));
        //}

        void EnemyBehaviour()
        {
            //After 
            enemySpawnerInterval -= Time.deltaTime;

            if(enemySpawnerInterval <= 0)
            {
                Instantiate(enemySpawnerPrefab, transform.position, Quaternion.identity);
                SetSpawnTime();
            }
        }

       void SetSpawnTime()
        {
            enemySpawnerInterval = Random.Range(minTimer, maxTimer); //Randomize the enemy spawn intervals
        } 

        
     }
}
