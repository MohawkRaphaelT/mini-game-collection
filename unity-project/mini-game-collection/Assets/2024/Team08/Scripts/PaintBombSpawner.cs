using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team08
{
    public class PaintBombSpawner : MiniGameBehaviour
    {
        [field: SerializeField] public GameObject PaintBomb { get; private set; }
        [field: SerializeField] public Transform[] Point1 { get; private set; }
        [field: SerializeField] public Transform[] Point2 { get; private set; }

        [field: SerializeField] public float MinSpeedUnitsPerSecond { get; private set; } = 1;
        [field: SerializeField] public float MaxSpeedUnitsPerSecond { get; private set; } = 3;
        public float MaxGameTime { get; private set; }
        public float FirstBomb { get; private set; }
        public float SecondBomb { get; private set; }
        public float TimeRemaining { get; private set; }



        protected override void OnTimerInitialized(int maxGameTime)
        {
            MaxGameTime = maxGameTime;
        }

        protected override void OnTimerUpdate(float timeRemaining)
        {
            TimeRemaining = timeRemaining;
        }

        public void PaintBombSpawn1()
        {
            Debug.Log("Works on the spawmer's end");
            Vector3 direction = transform.forward;
            float distanceZ = transform.position.z;
            float speed = ComputeSpeed(MinSpeedUnitsPerSecond, MaxSpeedUnitsPerSecond);

            for (int i = 0; i < Point1.Length; i++)
            {
                Transform spawnPoint = Point1[i];
                Vector3 position = spawnPoint.position;
                Quaternion rotation = transform.rotation;
                GameObject instance = Instantiate(PaintBomb, position, rotation);
                instance.SetActive(true);
                instance.transform.parent = spawnPoint.transform;
                //Obstacle obstacle = instance.GetComponent<Obstacle>();
                Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
                // Create force towards players where obstacle reaches in 1s (normalized
                //Vector3 force = direction * rigidbody.mass * distanceZ * speed;
                //rigidbody.AddForce(force, ForceMode.Impulse);
            }
        }
        public void PaintBombSpawn2()
        {
            Vector3 direction = transform.forward;
            float distanceZ = transform.position.z;
            float speed = ComputeSpeed(MinSpeedUnitsPerSecond, MaxSpeedUnitsPerSecond);

            for (int i = 0; i < Point2.Length; i++)
            {
                Transform spawnPoint = Point2[i];
                Vector3 position = spawnPoint.position;
                Quaternion rotation = transform.rotation;
                GameObject instance = Instantiate(PaintBomb, position, rotation);
                instance.SetActive(true);
                instance.transform.parent = spawnPoint.transform;
                //Obstacle obstacle = instance.GetComponent<Obstacle>();
                Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
                // Create force towards players where obstacle reaches in 1s (normalized
                //Vector3 force = direction * rigidbody.mass * distanceZ * speed;
                //rigidbody.AddForce(force, ForceMode.Impulse);
            }
        }

        //public void OnPlayer2Score()
        //{
            //Vector3 direction = transform.forward;
            //float distanceZ = transform.position.z;
            //float speed = ComputeSpeed(MinSpeedUnitsPerSecond, MaxSpeedUnitsPerSecond);

            //for (int i = 0; i < Point2.Length; i++)
            //{
                //Transform spawnPoint = Point2[i];
                //Vector3 position = spawnPoint.position;
                //Quaternion rotation = transform.rotation;
                //GameObject instance = Instantiate(PaintBomb, position, rotation);
                //instance.SetActive(true);
                //instance.transform.parent = spawnPoint.transform;
                ////Obstacle obstacle = instance.GetComponent<Obstacle>();
                //Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
                //// Create force towards players where obstacle reaches in 1s (normalized
                //Vector3 force = direction * rigidbody.mass * distanceZ * speed;
                //rigidbody.AddForce(force, ForceMode.Impulse);
            //}
        //}

        //protected override void OnTimerUpdateInt(int timeRemaining)
        //{
        //Vector3 direction = transform.forward;
        //float distanceZ = transform.position.z;
        //float speed = ComputeSpeed(MinSpeedUnitsPerSecond, MaxSpeedUnitsPerSecond);

        //for (int i = 0; i < SpawnPoints.Length; i++)
        //{
        //Transform spawnPoint = SpawnPoints[i];
        //Vector3 position = spawnPoint.position;
        //Quaternion rotation = transform.rotation;
        //GameObject instance = Instantiate(Obstacle, position, rotation);
        //instance.SetActive(true);
        //instance.transform.parent = spawnPoint.transform;
        ////Obstacle obstacle = instance.GetComponent<Obstacle>();
        //Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
        //// Create force towards players where obstacle reaches in 1s (normalized
        //Vector3 force = direction * rigidbody.mass * distanceZ * speed;
        //rigidbody.AddForce(force, ForceMode.Impulse);
        //}
        //}

        private float ComputeSpeed(float min, float max)
        {
            float delta = max - min;
            float speed = delta - (delta * TimeRemaining / MaxGameTime) + min;
            return speed;
        }

    }
}
