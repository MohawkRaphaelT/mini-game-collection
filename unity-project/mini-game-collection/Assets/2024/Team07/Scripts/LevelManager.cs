using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team07
{
    public class LevelManager : MonoBehaviour
    {
        //acts as gamemanager in mini-game, randomly generates levels and checks win conditions -cc

        //public GameObject[] possibleLevel;
        public P1Controller p1Controller;
        public P2Controller p2Controller;
        public MiniGameManager miniGameManager;
        public GameObject winCondition;
        public GameObject failCondition;
        /// <summary>
        ///private GameObject currentLevel;
        /// </summary>
        //private int randomNum;

        void Start()
        {
            //currentLevel = null;
            miniGameManager.StartGame();
        }
        void Update()
        {            
            if (miniGameManager.IsTimerExpired && !p1Controller.hasFinished)
            {               
                failCondition.SetActive(true);               
                StopMovement();
                
            }
            if(p1Controller.hasFinished)
            {
               winCondition.SetActive(true);
               miniGameManager.StopGame();              
               StopMovement();
            }
            /*
            //wasnt able to implement :( -cc
            if (currentLevel == null){
                //randomly generates level each time the game opens -cc
                randomNum = Random.Range(0, possibleLevel.Length);
                currentLevel = possibleLevel[randomNum];
                currentLevel.SetActive(true);
            }
            */
        }
        void StopMovement()
        {
            p1Controller.gameObject.SetActive(false);
            p2Controller.gameObject.SetActive(false);
        }
    }
}
