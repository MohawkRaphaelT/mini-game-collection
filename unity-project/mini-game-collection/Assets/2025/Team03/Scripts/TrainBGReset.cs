using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiniGameCollection.Games2025.Team03
{
    public class TrainBGReset : MonoBehaviour
    {
        //Allister Wylie
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "TrainBGTrigger")
            {
                transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
            }
        }
    }
}
