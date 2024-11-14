using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGameCollection.Games2024.Team08
{
    public class PlayerID : MonoBehaviour
    {

        public GameObject player;

        [SerializeField] public bool RedPlayer;
        [SerializeField] public bool BluePlayer;
        // Start is called before the first frame update
        void Start()
        {
            if (player.name == "Red")
            {
                RedPlayer = true;
            }
            else if (player.name == "Blue")
            {
                BluePlayer = true;
            }
            else
            {
                Debug.Log("The names are wrong");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

