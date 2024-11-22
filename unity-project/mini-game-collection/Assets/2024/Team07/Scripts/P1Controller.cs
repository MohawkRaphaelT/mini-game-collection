using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  MiniGameCollection.Games2024.Team07
{
    public class P1Controller : MonoBehaviour
    {
        //Player one controller code -cc
        //also includes player collision code for win condition -cc
        public float moveSpeed = 5f;
        float y;
        float x;
        public bool hasFinished;
        void Update(){
            x = ArcadeInput.Player1.AxisX;
            y = ArcadeInput.Player1.AxisY;
        }
        void FixedUpdate()
        {
            //.normalized ensures players cant clip through walls when moving diagonally -cc
            Vector3 movement = new Vector3(x, 0, y).normalized;
            transform.Translate (movement * moveSpeed * Time.deltaTime);
        }
        void OnCollisionEnter(Collision collision){
            //if the players collide, end game -cc
            if(collision.gameObject.name == "PlayerTwo"){
                hasFinished = true;
            }
        }
    }
}
