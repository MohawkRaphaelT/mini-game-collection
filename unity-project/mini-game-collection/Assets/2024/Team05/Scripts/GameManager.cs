using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MiniGameCollection.Games2024.Team05
{
    public class GameManager : MonoBehaviour
    {
        // MiniGameManager reference
        public MiniGameManager mGM;

        // Player references
        public GameObject p1;
        private Tagged p1Tag;

        public GameObject p2;
        private Tagged p2Tag;

        //Variables
        public GameObject p1Text;
        public GameObject p2Text;

        // Start is called before the first frame update
        // MiniGameKicker start
        private void Start()
        {
            mGM.StartGame();
            p1Tag = p1.GetComponent<Tagged>();

            p2Tag = p2.GetComponent<Tagged>();

        }

        // Update is called once per frame
        void Update()
        {
            if(p1Tag.isTagged == true)
            {
                p1Text.SetActive(true);

                p2Text.SetActive(false);
            }

            if(p2Tag.isTagged == true)
            {
                p2Text.SetActive(true);

                p1Text.SetActive(false);
            }
        }
    }
}
