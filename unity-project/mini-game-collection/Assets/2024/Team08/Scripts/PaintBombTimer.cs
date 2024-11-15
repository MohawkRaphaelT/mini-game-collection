using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team08
{
    public class PaintBombTimer : MiniGameBehaviour
    {

        public PaintBombSpawner paintBombSpawner;

        public float Time1;

        public float Time2;

        public bool Time1NotSpawned;

        public bool Time2NotSpawned;

        public float PaintGameTime = 30f;
        // Start is called before the first frame update
        void Start()
        {
            //Time1 = TimeRemaining / 3f;
            //Time2 = TimeRemaining / 2f;

            Time1 = PaintGameTime;
            Time2 = PaintGameTime;

            Time1NotSpawned = true;
            Time2NotSpawned = true;
        }

        // Update is called once per frame
        void Update()
        {
            Time1 -= Time.deltaTime;
            Time2 -= Time.deltaTime;

            if (Time1 <= 20f && Time1NotSpawned == true)
            {
                Debug.Log("Works on the timer's end");
                paintBombSpawner.PaintBombSpawn1();
                Time1NotSpawned = false;
            }
            else if (Time2 <= 10f && Time2NotSpawned == true)
            {
                paintBombSpawner.PaintBombSpawn2();
                Time2NotSpawned = false;
            }
        }
    }
}

