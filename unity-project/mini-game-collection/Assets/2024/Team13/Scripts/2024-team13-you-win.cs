using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace MiniGameCollection.Games2024.Team13
{
    public class WinTrigger : MonoBehaviour
    {
        public string winSceneName = "2024-team13-winner";
        private bool player1Passed = false;
        private bool player2Passed = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player1"))
            {
                player1Passed = true;
                CheckWinCondition();
            }
            if (other.CompareTag("Player2"))
            {
                player2Passed = true;
                CheckWinCondition();
            }
        }
        private void CheckWinCondition()
        {
            if (player1Passed && player2Passed)
            {
                LoadWinScreen();
            }
        }
        private void LoadWinScreen()
        {
            SceneManager.LoadScene("2024-team13-winner");
        }
    }
}