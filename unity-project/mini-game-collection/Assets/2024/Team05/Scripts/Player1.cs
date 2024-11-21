using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team05
{

    public class Player1 : MonoBehaviour
    {
        // Variables
        float x;
        float y;
        public float speed = 5f;

        // Material Renderer
        public Material[] color;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            x = ArcadeInput.Player1.AxisX;
            y = ArcadeInput.Player1.AxisY;
        }

        private void FixedUpdate()
        {
            Vector3 move = new Vector3(x, y, 0);
            // Direction and distance
            transform.Translate(move * speed * Time.deltaTime);
        }
    }
}
