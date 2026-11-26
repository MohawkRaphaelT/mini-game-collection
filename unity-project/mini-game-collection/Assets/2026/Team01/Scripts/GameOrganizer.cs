using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MiniGameCollection.Games2026.Team01
{
    public class GameOrganizer : MiniGameBehaviour
    {
        [field: SerializeField] public GameObject TreeParent { get; private set; }
        [field: SerializeField] public GameObject RockParent { get; private set; }
        [field: SerializeField] public GameObject MushroomParent { get; private set; }
        [field: SerializeField] public GameObject WeedParent { get; private set; }
        [field: SerializeField] public PlayerController Player1 { get; private set; }
        [field: SerializeField] public PlayerController Player2 { get; private set; }
        [field: SerializeField] public TMP_Text Player1ScoreText { get; private set; }
        [field: SerializeField] public TMP_Text Player2ScoreText { get; private set; }
        [field: SerializeField] public TMP_Text Player1TaskText { get; private set; }
        [field: SerializeField] public TMP_Text Player2TaskText { get; private set; }
        [field: SerializeField] public float TaskRespawnTimer { get; private set; }
        public List<GameObject> treeList;
        public List<GameObject> rockList;
        public List<GameObject> mushroomList;
        public List<GameObject> weedList;
        private Dictionary<int, bool> TaskStates;

        private void Awake()
        {
            TaskStates = new Dictionary<int, bool>
            {
                {1, true }, // Tree
                {2, true }, // Rock
                {3, true }, // Mushroom
                {4, true }  // Weed
            };
        }
        private void Start()
        {
            foreach (Transform child in TreeParent.transform)
            {
                treeList.Add(child.gameObject);
            }
            foreach (Transform child in RockParent.transform)
            {
                rockList.Add(child.gameObject);
            }
            foreach (Transform child in MushroomParent.transform)
            {
                mushroomList.Add(child.gameObject);
            }
            foreach (Transform child in WeedParent.transform)
            {
                weedList.Add(child.gameObject);
            }

            SetTask(Player1);
            SetTask(Player2);
        }

        private void Update()
        {
            // Check Scoring
            Player1ScoreText.text = $"Score: {Player1.Score.ToString()}";
            Player2ScoreText.text = $"Score: {Player2.Score.ToString()}";
        }
        protected override void OnGameEnd()
        { 
            // Learned that I don't need {}'s after all this time !?? crazy
            if (Player1.Score == Player2.Score)
                MiniGameManager.Winner = MiniGameWinner.Draw;
            else if (Player1.Score > Player2.Score)
                MiniGameManager.Winner = MiniGameWinner.Player1;
            else if (Player1.Score < Player2.Score)
                MiniGameManager.Winner = MiniGameWinner.Player2;
            else
                throw new NotImplementedException();
        }
        // Call this when a player breaks an object
        public bool CheckList(List<GameObject> list)
        {
            foreach (GameObject i in list)
            {
                if (i.activeInHierarchy)
                {
                    return true;
                }
            }
            // Assign whoever's task this was a point, and set their task to none, last task to this one, and give them a new task
            PlayerController.TaskType completedType = 0;
            if (list == treeList)
            {
                completedType = PlayerController.TaskType.Tree;
            }
            else if (list == rockList)
            {
                completedType = PlayerController.TaskType.Rock;
            }
            else if (list == mushroomList)
            {
                completedType = PlayerController.TaskType.Mushroom;
            }
            else if (list == weedList)
            {
                completedType = PlayerController.TaskType.Weed;
            }
            else
            {
                completedType = PlayerController.TaskType.None;
            }
            
            if (Player1.currentTask == completedType)
            {
                Player1.Score++;
                Player1.lastTask = completedType;
                Player1.currentTask = PlayerController.TaskType.None;
                SetTask(Player1);
            }
            else if (Player2.currentTask == completedType)
            {
                Player2.Score++;
                Player2.lastTask = completedType;
                Player2.currentTask = PlayerController.TaskType.None;
                SetTask(Player2);
            }
            StartCoroutine(RespawnTask(list));

            return false;
        }
        private IEnumerator RespawnTask(List<GameObject> list)
        {
            yield return new WaitForSeconds(TaskRespawnTimer);
            foreach (GameObject i in list)
            {
                i.SetActive(true);
            }
        }
        private void SetTask(PlayerController Player)
        {
            Debug.Log($"{Player} wants a new task");
            if (Player.currentTask == 0) // None
            {
                PlayerController.TaskType giveTask = 0;
                int thisPlayerID = (int)Player.PlayerID;
                PlayerController otherPlayer;
                if (thisPlayerID == 0)
                {
                    otherPlayer = Player2;
                } else
                {
                    otherPlayer = Player1;
                }
                
                // Check which task to give
                while (giveTask == 0)
                {
                    PlayerController.TaskType random = (PlayerController.TaskType)Random.Range(1, 5);
                    if (Player.lastTask != random &&        // Makes sure the task isn't one the player had before
                        TaskStates[(int)random] == true &&  // Makes sure the task is active
                        otherPlayer.currentTask != random)  // Makes sure the other player doesn't have the task
                    {
                        giveTask = random;
                    }
                }
                Player.currentTask = giveTask;
                if (Player == Player1)
                    Player1TaskText.text = Player.currentTask.ToString();
                else if (Player == Player2)
                    Player2TaskText.text = Player.currentTask.ToString();
                Debug.Log($"{Player} got task {giveTask}");
                
            }
        }
    }
}
