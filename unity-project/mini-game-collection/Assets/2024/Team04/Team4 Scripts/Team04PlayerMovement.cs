using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MiniGameCollection.ArcadeInput;

namespace MiniGameCollection.Games2024.Team04
{
    public class Team04PlayerMovement : MonoBehaviour
    {
        public GameObject Player1;
        public GameObject Player2;

        public int stickCurrent;
        public int stickLast;
        public int rotateCurrent;
        public float rotateSpeed;
        public float speedCurrent;

        public int stickCurrentP2;
        public int stickLastP2;
        public int rotateCurrentP2;
        public float rotateSpeedP2;
        public float speedCurrentP2;

        public float speedMax = 10;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            stickLast = stickCurrent; //stores the input from the previous frame
            stickLastP2 = stickCurrentP2;


            //Player 1 
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    stickCurrent = 8;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    stickCurrent = 2;
                }
                else
                {
                    stickCurrent = 1;
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    stickCurrent = 4;
                }
                else
                {
                    stickCurrent = 3;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    stickCurrent = 6;
                }
                else
                {
                    stickCurrent = 5;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                stickCurrent = 7;
            }
            else stickCurrent = 0;

            //Player 2
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    stickCurrentP2 = 8;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    stickCurrentP2 = 2;
                }
                else
                {
                    stickCurrentP2 = 1;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    stickCurrentP2 = 4;
                }
                else
                {
                    stickCurrentP2 = 3;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    stickCurrentP2 = 6;
                }
                else
                {
                    stickCurrentP2 = 5;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                stickCurrentP2 = 7;
            }
            else stickCurrentP2 = 0;



            //handle rotating
            //Player1
            if (stickCurrent == stickLast + 1 || stickCurrent == stickLast + 2 || stickCurrent == 1 && stickLast == 8)
            {
                if (rotateSpeed < 0)
                {
                    rotateSpeed = rotateSpeed - 3;
                }
                else
                {
                    rotateSpeed = rotateSpeed - 5;
                }
            }
            if (stickCurrent == stickLast - 1 || stickCurrent == stickLast - 2 || stickCurrent == 8 && stickLast == 1)
            {
                if (rotateSpeed > 0)
                {
                    rotateSpeed = rotateSpeed + 3;
                }
                else
                {
                    rotateSpeed = rotateSpeed + 5;
                }
            }
            Player1.transform.eulerAngles = new Vector3(0, 0, Player1.transform.eulerAngles.z + rotateSpeed);

            //Player2
            if (stickCurrentP2 == stickLastP2 + 1 || stickCurrentP2 == stickLastP2 - 2 || stickCurrentP2 == 1 && stickLastP2 == 8)
            {
                if (rotateSpeedP2 < 0)
                {
                    rotateSpeedP2 = rotateSpeedP2 - 3;
                }
                else
                {
                    rotateSpeedP2 = rotateSpeedP2 - 5;
                }
            }
            if (stickCurrentP2 == stickLastP2 - 1 || stickCurrentP2 == stickLastP2 - 2 || stickCurrentP2 == 8 && stickLastP2 == 1)
            {
                if (rotateSpeedP2 > 0)
                {
                    rotateSpeedP2 = rotateSpeedP2 + 3;
                }
                else
                {
                    rotateSpeedP2 = rotateSpeedP2 + 5;
                }
            }
            Player2.transform.eulerAngles = new Vector3(0, 0, Player2.transform.eulerAngles.z + rotateSpeedP2);


            //Move forward
            //Player 1
            if (Input.GetKeyDown(KeyCode.Q))
            {
                speedCurrent += (float)0.05;
                if (speedCurrent <= speedMax)
                {
                    speedCurrent = speedMax;
                }
                Player1.GetComponent<Rigidbody2D>().velocity = Player1.transform.up * speedCurrent;

            }

            //Player 2
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                speedCurrentP2 += (float)0.05;
                if (speedCurrentP2 <= speedMax)
                {
                    speedCurrentP2 = speedMax;
                }
                Player2.GetComponent<Rigidbody2D>().velocity = Player2.transform.up * speedCurrentP2;
            }


            //make rotation slowly stop if no input happening
            if (rotateSpeed > 0)
            {
                rotateSpeed -= 1;
            }
            if (rotateSpeed < 0)
            {
                rotateSpeed += 1;
            }
            if (rotateSpeedP2 > 0)
            {
                rotateSpeedP2 -= 1;
            }
            if (rotateSpeedP2 < 0)
            {
                rotateSpeedP2 += 1;
            }

            // decrease speed variable (doesnt decrease actual player speed, decreases the speed added to the player object)
            if (speedCurrent > 0)
            {
                speedCurrent -= (float)0.3; // drag
            }
            else if (speedCurrent < 0)
            {
                speedCurrent = 0;
            }

            if (speedCurrentP2 > 0)
            {
                speedCurrentP2 -= (float)0.3; // drag
            }
            else if (speedCurrentP2 < 0)
            {
                speedCurrentP2 = 0;
            }


            //DEBUG ROTATION CODE
            if (Input.GetKey(KeyCode.Z))
            {
                Player1.transform.eulerAngles = new Vector3(0, 0, Player1.transform.eulerAngles.z + 2);
            }
            if (Input.GetKey(KeyCode.X))
            {
                Player1.transform.eulerAngles = new Vector3(0, 0, Player1.transform.eulerAngles.z - 2);
            }




            if (Input.GetKey(KeyCode.C))
            {
                Player2.transform.eulerAngles = new Vector3(0, 0, Player2.transform.eulerAngles.z + 2);
            }
            if (Input.GetKey(KeyCode.V))
            {
                Player2.transform.eulerAngles = new Vector3(0, 0, Player2.transform.eulerAngles.z - 2);
            }
        }
    }
}
