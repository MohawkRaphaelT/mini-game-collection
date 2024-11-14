using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team08
{
    public class PaintableColorSwitch : MonoBehaviour
    {
        //[SerializeField] public Color switchColor = Color.white;

        [SerializeField] public bool IsNeutral;
        [SerializeField] public bool IsRed;
        [SerializeField] public bool IsBlue;
        [SerializeField] public Material[] Material;
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
            }
            else if (blueCollor && IsNeutral == true)
            {
                IsBlue = false;
                rend.sharedMaterial = Material[2];
            }
            else if (redCollor && IsBlue == true) 
            {
                IsBlue = false;
                IsRed = true;
                rend.sharedMaterial = Material[1];
            }
            else if (blueCollor && IsRed == true)
            {
                IsRed = false;
                IsBlue = true;
                rend.sharedMaterial = Material[2];
            }
        }
    }
}

