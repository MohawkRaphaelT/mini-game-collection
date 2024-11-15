using MiniGameCollection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team08
{
    public class PlayerController : MonoBehaviour
    {
        public int playerID;



        public float speed = 10f;
        private void Update()
        {
            
            var playerInput = ArcadeInput.Players[playerID];

            
            float horizontalMovement = playerInput.AxisX * speed;
            float verticalMovement = playerInput.AxisY * speed;

            
            Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
            transform.Translate(movement * Time.deltaTime);


            if (playerInput.Action1.Pressed)
            {
                Debug.Log($"Action1 Pressed");
                
            }

            if (playerInput.Action1.Down)
            {
              
               
            }
        }
    }
}
