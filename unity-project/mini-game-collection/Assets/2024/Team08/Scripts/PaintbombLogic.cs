using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team08
{
    public class PaintbombLogic : MonoBehaviour
    {
        [SerializeField] public GameObject PaintBomb;
        [SerializeField] public GameObject RedPaintBlast;
        [SerializeField] public GameObject BluePaintBlast;

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
            bool redColor = other.GetComponentInChildren<RedPlayer>() != null;
            bool blueColor = other.GetComponentInChildren<BluePlayer>() != null;
            //Debug.Log("Is it colliding");
            if (redColor && IsNeutral == true)
            {
                IsRed = true;
                IsNeutral = false;
                rend.sharedMaterial = Material[1];
                //RedScore = RedScore + 1;
                Instantiate(RedPaintBlast, transform.position, transform.rotation);
                Destroy(PaintBomb);
            }
            else if (blueColor && IsNeutral == true)
            {
                IsBlue = false;
                rend.sharedMaterial = Material[2];
                //BlueScore = BlueScore + 1;
                Instantiate(BluePaintBlast, transform.position, transform.rotation);
                Destroy(PaintBomb);
            }
        }
    }
}


