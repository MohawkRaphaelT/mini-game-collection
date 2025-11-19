using MiniGameCollection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2025.Team03
{
    public class CarMovement : MonoBehaviour
    {
        //Allister Wylie

        public bool isB1Pressed = false;
        public bool isB2Pressed = true;
        public GameObject leftHandle;
        public GameObject rightHandle;
        public GameObject bg1;
        public GameObject bg2;
        public int carScoreCount = 0;
        public GameObject button1;
        public GameObject button2;
        public GameObject button1Pressed;
        public GameObject button2Pressed;

        [field: SerializeField]
        public MiniGameManager MiniGameManager { get; private set; }

        public MiniGameScoreUI scoreUI;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (ArcadeInput.Player1.Action1.Pressed && isB1Pressed == false)
            {
                //locks B1 and unlocks B2
                isB1Pressed = true;
                isB2Pressed = false;
                //Faux handle animation
                leftHandle.SetActive(true);
                rightHandle.SetActive(false);

                button1Pressed.SetActive(false);
                button1.SetActive(true);
                button2.SetActive(false);
                button2Pressed.SetActive(true);
                //Increases score and updates UI
                carScoreCount++;
                scoreUI.IncrementPlayerScore(1);

                //Moves background
                bg1.transform.position = new Vector3(bg1.transform.position.x, bg1.transform.position.y + 0.5f, bg1.transform.position.z);
                bg2.transform.position = new Vector3(bg2.transform.position.x, bg2.transform.position.y + 0.5f, bg2.transform.position.z);
            }

            if (ArcadeInput.Player1.Action2.Pressed && isB2Pressed == false)
            {
                isB2Pressed = true;
                isB1Pressed = false;
                leftHandle.SetActive(false);
                rightHandle.SetActive(true);

                button1Pressed.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(true);
                button2Pressed.SetActive(false);
                carScoreCount++;
                scoreUI.IncrementPlayerScore(1);

                bg1.transform.position = new Vector3(bg1.transform.position.x, bg1.transform.position.y + 0.5f, bg1.transform.position.z);
                bg2.transform.position = new Vector3(bg2.transform.position.x, bg2.transform.position.y + 0.5f, bg2.transform.position.z);
            }

            if (carScoreCount >= 200)
            {
                //if score is 200, set player 1 as winner and stop the game
                MiniGameManager.Winner = MiniGameWinner.Player1;
                MiniGameManager.StopGame();
            }
        }

    }
}

