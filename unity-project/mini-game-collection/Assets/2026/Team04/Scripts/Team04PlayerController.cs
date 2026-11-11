using UnityEngine;

namespace MiniGameCollection.Games2026.Team04
{
    public class Team04PlayerController : MiniGameBehaviour
    {
        public Team04PlayerID PlayerID;
        public Rigidbody2D rb;
        public float playerSpeed;
        public float jumpSpeed;
        private float groundCheckLength = 0.65f;
        public LayerMask groundLayer;

        void Update()
        {
            float axisX = ArcadeInput.Players[(int)PlayerID].AxisX;

            rb.velocity = new Vector2(axisX * playerSpeed, rb.velocity.y);

            if (ArcadeInput.Players[(int)PlayerID].Action1.Pressed && GroundCheck())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }

        private void OnValidate()
        {
        }

        bool GroundCheck()
        {
            bool check = Physics2D.Raycast(transform.position, Vector2.down,
                groundCheckLength, groundLayer);

            return check;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckLength);
        }
    }
}
