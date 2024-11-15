using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team08
{
    public class PaintBombLogic : MonoBehaviour
    {
        public GameObject Bomb;
        public GameObject RedBomb;
        public GameObject BlueBomb;
        // Start is called before the first frame update
        void Start()
        {
            //RedBomb = RedBomb;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            bool redCollor = other.GetComponentInChildren<RedPlayer>() != null;
            bool blueCollor = other.GetComponentInChildren<BluePlayer>() != null;
            if (redCollor)
            {
                Instantiate(RedBomb, transform.position, transform.rotation);
                Destroy(Bomb);
            }
            else if (blueCollor)
            {
                Instantiate(BlueBomb, transform.position, transform.rotation);
                Destroy(Bomb);
            }
        }
    }

}

