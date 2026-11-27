using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGameCollection.Games2026.Team06
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private float speed = 6f;
        [SerializeField] private float bombTime = 0.8f;
        [SerializeField] private int bombRadius = 3;

        private TurfGrid grid;
        private PlayerID owner;

        public void Throw(TurfGrid turfGrid, PlayerID thrower, Vector2 direction)
        {
            grid = turfGrid;
            owner = thrower;
            body.velocity = direction * speed;
            Invoke(nameof(Explode), bombTime);
        }

        private void Explode()
        {
            grid.Paint(transform.position, owner, bombRadius);
            Destroy(gameObject);
        }
    
   }
}

