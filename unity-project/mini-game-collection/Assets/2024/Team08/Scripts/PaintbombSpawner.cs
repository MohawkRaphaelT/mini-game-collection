using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGameCollection.Games2024.Team00 
{
    public class PaintbombSpawner : MonoBehaviour
    {
        [field: SerializeField] public GameObject MiniGameManager {  get; private set; }
        [field: SerializeField] public GameObject Obstacle { get; private set; }
        [field: SerializeField] public Transform[] SpawnPoints { get; private set; }
        public float MaxGameTime { get; private set; }
        public float TimeRemaining { get; private set; }

        public void OnTimerInitialized(int maxGameTime)
        {
            MaxGameTime = maxGameTime;
        }

        public void OnTimerUpdate(float timeRemaining)
        {
            TimeRemaining = timeRemaining;
        }

        public void OnTimerUpdateInt(int timeRemaining)
        {
            Vector3 direction = transform.forward;
            float distanceZ = transform.position.z;

            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                Transform spawnPoint = SpawnPoints[i];
                Vector3 position = spawnPoint.position;
                Quaternion rotation = transform.rotation;
                GameObject instance = Instantiate(Obstacle, position, rotation);
                instance.SetActive(true);
                instance.transform.parent = spawnPoint.transform;
                //Obstacle obstacle = instance.GetComponent<Obstacle>();
                Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
                // Create force towards players where obstacle reaches in 1s (normalized
            }
        }

        private float ComputeSpeed(float min, float max)
        {
            float delta = max - min;
            float speed = delta - (delta * TimeRemaining / MaxGameTime) + min;
            return speed;
        }
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

