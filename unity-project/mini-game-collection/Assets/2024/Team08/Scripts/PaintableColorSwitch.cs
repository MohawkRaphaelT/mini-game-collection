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
        Renderer rend;
        public MiniGameScoreUI scoreUI;
        //[SerializeField] public int RedScore;
        //[SerializeField] public int BlueScore;
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
            bool redColor = other.GetComponentInChildren<RedPlayer>() != null;
            bool blueColor = other.GetComponentInChildren<BluePlayer>() != null;
            //Debug.Log("Is it colliding");
            if (redColor && IsNeutral == true)
            {
                IsRed = true;
                IsNeutral = false;
                rend.sharedMaterial = Material[1];
                //RedScore = RedScore + 1;
                scoreUI.IncrementPlayerScore(1);
            }
            else if (blueColor && IsNeutral == true)
            {
                IsBlue = true;
                IsNeutral = false;
                rend.sharedMaterial = Material[2];
                //BlueScore = BlueScore + 1;
                scoreUI.IncrementPlayerScore(2);
            }
            else if (redColor && IsBlue == true) 
            {
                IsBlue = false;
                IsRed = true;
                rend.sharedMaterial = Material[1];
                //RedScore = RedScore + 1;
                //BlueScore = BlueScore - 1;

            }
            else if (blueColor && IsRed == true)
            {
                IsRed = false;
                IsBlue = true;
                rend.sharedMaterial = Material[2];
                //BlueScore = BlueScore + 1;
                //RedScore = RedScore - 1;
            }
        }
    }
}

