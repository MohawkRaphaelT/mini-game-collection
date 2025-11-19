using MiniGameCollection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace MiniGameCollection.Games2025.Team03
{
    public class TrainMovement : MonoBehaviour
    {
        //Allister Wylie

        public bool isLeftPulled = false;
        public bool isRightPulled = true;
        public GameObject smoke;
        public int trainScoreCount = 0;
        public GameObject bg1;
        public GameObject bg2;
        public GameObject joystickLeft;
        public GameObject joystickRight;

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
            //see car script for function notes
            if (ArcadeInput.Player2.Left.Pressed && isLeftPulled == false)
            {
                //locks left input, unlocks right
                isLeftPulled = true;
                isRightPulled = false;
                smoke.SetActive(true);
                joystickLeft.SetActive(false);
                joystickRight.SetActive(true);
                trainScoreCount++;
                scoreUI.IncrementPlayerScore(2);

                bg1.transform.position = new Vector3(bg1.transform.position.x, bg1.transform.position.y - 0.5f, bg1.transform.position.z);
                bg2.transform.position = new Vector3(bg2.transform.position.x, bg2.transform.position.y - 0.5f, bg2.transform.position.z);
            }

            if (ArcadeInput.Player2.Right.Pressed && isRightPulled == false)
            {
                isLeftPulled = false;
                isRightPulled = true;
                smoke.SetActive(false);
                joystickLeft.SetActive(true);
                joystickRight.SetActive(false);
                trainScoreCount++;
                scoreUI.IncrementPlayerScore(2);

                bg1.transform.position = new Vector3(bg1.transform.position.x, bg1.transform.position.y - 0.5f, bg1.transform.position.z);
                bg2.transform.position = new Vector3(bg2.transform.position.x, bg2.transform.position.y - 0.5f, bg2.transform.position.z);
            }

            if (trainScoreCount >= 200)
            {
                MiniGameManager.Winner = MiniGameWinner.Player2;
                MiniGameManager.StopGame();
            }
        }
    }
}
