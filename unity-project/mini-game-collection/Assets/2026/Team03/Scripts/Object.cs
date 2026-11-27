using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2026.Team03
{
    public class Object : MonoBehaviour
    {

        [field: SerializeField] public PlayerID PlayerID { get; private set; }
        [field: SerializeField] public Rigidbody2D Player1Rb2d { get; private set; }
        [field: SerializeField] public Rigidbody2D Player2Rb2d { get; private set; }
        [field: SerializeField] public Rigidbody2D rb2d { get; private set; }

        [field: SerializeField] public GameObject Player1 { get; private set; }
        [field: SerializeField] public GameObject Player2 { get; private set; }

        bool Player1Hovering = false;
        bool Player2Hovering = false;

        bool Player1Holding = false;
        bool Player2Holding = false;

        private SpriteRenderer spriteRenderer;
        private Collider2D objectCollider;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            objectCollider = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            CollisionHandling();
            CollisionVisual();
            FollowPlayer();
        }

        void CollisionVisual()
        {
            if (PlayerID == PlayerID.Player1)
            {
                if (Player1Hovering)
                {
                    spriteRenderer.color = new Color(0.588f, 0.588f, 0.871f);
                }
                if (!Player1Hovering)
                {
                    spriteRenderer.color = new Color(0.678f, 0.678f, 0.871f);
                }
            }

            if (PlayerID == PlayerID.Player2)
            {
                if (Player2Hovering)
                {
                    spriteRenderer.color = new Color(0.871f, 0.588f, 0.588f);
                }
                if (!Player2Hovering)
                {
                    spriteRenderer.color = new Color(0.871f, 0.678f, 0.678f);
                }
            }

        }

        void CollisionHandling()
        {
            if (ArcadeInput.Players[(int)PlayerID].Action1.Pressed)
            {
                if (Player1Hovering && PlayerID == PlayerID.Player1)
                {
                    Player1Hovering = false;
                    Player1Holding = true;
                    objectCollider.isTrigger = true;
                }

                if (Player2Hovering && PlayerID == PlayerID.Player2)
                {
                    Player2Hovering = false;
                    Player2Holding = true;
                    objectCollider.isTrigger = true;
                }
            }
            if (ArcadeInput.Players[(int)PlayerID].Action2.Pressed)
            {
                if (Player1Holding && PlayerID == PlayerID.Player1)
                {
                    Player1Holding = false;
                    objectCollider.isTrigger = false;
                }

                if (Player2Holding && PlayerID == PlayerID.Player2)
                {
                    Player2Holding = false;
                    objectCollider.isTrigger = false;
                }
            }
        }

        void FollowPlayer()
        {
            if(Player1Holding && PlayerID == PlayerID.Player1)
            {
                transform.position = Player1.transform.position;
            }
            if (Player2Holding && PlayerID == PlayerID.Player2)
            {
                transform.position = Player2.transform.position;
            }
        }

        //checks if either player is in range of their own cube
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Something entered: " + other.gameObject.name);

            if (PlayerID == PlayerID.Player1)
            {
                if (other.gameObject.name == "2026-team03-player1")
                {
                    Player1Hovering = true;
                    Debug.Log("Player 1 is hovering!");
                }
            }
            if (PlayerID == PlayerID.Player2)
            {
                if (other.gameObject.name == "2026-team03-player2")
                {
                    Player2Hovering = true;
                }
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (PlayerID == PlayerID.Player1)
            {
                if (other.gameObject.name == "2026-team03-player1")
                {
                    Player1Hovering = false;
                }
            }
            if (PlayerID == PlayerID.Player2)
            {
                if (other.gameObject.name == "2026-team03-player2")
                {
                    Player2Hovering = false;
                }
            }
        }
    }
}

