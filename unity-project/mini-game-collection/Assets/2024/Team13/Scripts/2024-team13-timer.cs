using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace MiniGameCollection.Games2024.Team13
{
    public class Timer : MonoBehaviour
    {
        float currentTime;
        public float startingTime = 10f;
        [SerializeField] TextMeshProUGUI countdownText;
        void Start()
        {
            currentTime = startingTime;
        }
        void Update()
        {
            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
                LoadLoserScreen();
            }
        }
        void LoadLoserScreen()
        {
            SceneManager.LoadScene("2024-team13-loser");
        }
    }
}