using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static MiniGameCollection.ArcadeInput;

public class Player2Score : MonoBehaviour
{
    //Text of player score to display on screen
    private TextMeshProUGUI Play2Score; 

    //Player script to recieve the public float score of the first player. 
    public TrackManager2 player;

    // Start is called before the first frame update
    void Start()
    {
        Play2Score = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //The player score is converted to a string and displayed
        int tempScore = Mathf.RoundToInt(player.score2) / 1000 ;
        Play2Score.text = "Score: " + tempScore.ToString() + " km";
    }
}
