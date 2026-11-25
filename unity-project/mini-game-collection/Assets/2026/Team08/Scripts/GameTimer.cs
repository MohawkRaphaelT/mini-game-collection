using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TrackManager1 player1;
    public TrackManager2 player2;

    //Text of timer to display on screen. Will also show winner
    private TextMeshProUGUI WinnerText;

    float timeRemaining = 45;

    //Used to determine winner once
    bool finished = false;

    //Used to determine start
     bool started = true;

    string winner;

    // Start is called before the first frame update
    void Start()
    {
        player1 = FindObjectOfType<TrackManager1>();
        player2 = FindObjectOfType<TrackManager2>();
        WinnerText = transform.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (started == true)
        {
            if (finished == false)
            {
                if (timeRemaining <= 0)
                {
                    if (player1.score1 > player2.score2)
                    {
                        winner = "Player 1 wins!";
                    }
                    else if (player1.score1 < player2.score2)
                    {
                        winner = "Player 2 wins!";
                    }
                    else if (player1.score1 == player2.score2)
                    {
                        winner = "Tie!";
                    }
                    finished = true;
                }
                timeRemaining -= Time.deltaTime;

                RubberBand();

                WinnerText.text = Mathf.CeilToInt(timeRemaining).ToString();
            }
            else if (finished == true) { WinnerText.text = winner; }
        }
    }

    /// <summary>
    /// After 15 seconds, the player in last place will get a free power up
    /// </summary>
    void RubberBand() {
        if (Mathf.CeilToInt(timeRemaining) == 15)
        {
            if (player1.score1 > player2.score2)
            {
                Debug.Log("player 2 can activate special");
                player2.dropItem = true;
            }
            else if (player1.score1 < player2.score2)
            {
                Debug.Log("player 1 can activate special");

            }
        }
    }
}
