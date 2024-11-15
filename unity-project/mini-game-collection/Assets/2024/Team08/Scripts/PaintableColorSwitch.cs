using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team08
{
    public class PaintableColorSwitch : MiniGameBehaviour
    {
        //[SerializeField] public Color switchColor = Color.white;

        [SerializeField] public bool IsNeutral;
        [SerializeField] public bool IsRed;
        [SerializeField] public bool IsBlue;
        [SerializeField] public Material[] Material;
        public PointKeeper PointKeeper;
        //public PointBoxSpawner pointBoxSpawner;
        Renderer rend;
        // Start is called before the first frame update
        void Start()
        {
            IsNeutral = true;
            IsRed = false;
            IsBlue = false;
            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = Material[0];
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            bool redCollor = other.GetComponentInChildren<RedPlayer>() != null;
            bool blueCollor = other.GetComponentInChildren<BluePlayer>() != null;
            //Debug.Log("Is it colliding");
            if (redCollor && IsNeutral == true)
            {
                IsRed = true;
                IsNeutral = false;
                rend.sharedMaterial = Material[1];
                //pointBoxSpawner.OnPlayer1Score();
                PointKeeper.AddScoreP1();
            }
            else if (blueCollor && IsNeutral == true)
            {
                IsBlue = true;
                IsNeutral = false;
                rend.sharedMaterial = Material[2];
                //pointBoxSpawner.OnPlayer2Score();
                PointKeeper.AddScoreP2();
            }
            else if (redCollor && IsBlue == true) 
            {
                //Debug.Log("Blue to Red");
                IsBlue = false;
                IsRed = true;
                rend.sharedMaterial = Material[1];
                PointKeeper.SubtractScoreP1();
            }
            else if (blueCollor && IsRed == true)
            {
                //Debug.Log("Red to Blue");
                IsRed = false;
                IsBlue = true;
                rend.sharedMaterial = Material[2];
                PointKeeper.SubtractScoreP2();
            }
        }
    }
}

