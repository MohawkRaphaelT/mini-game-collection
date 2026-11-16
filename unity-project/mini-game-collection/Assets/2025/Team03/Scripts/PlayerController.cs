using UnityEngine;

namespace MiniGameCollection.Games2026.Team03
{
    public class Player : MiniGameBehaviour
    {
        [field: SerializeField] public PlayerID PlayerID { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set; } = 10f;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            // -1 to 1
            float axisX = ArcadeInput.Players[(int)PlayerID].AxisX;
            float axisY = ArcadeInput.Players[(int)PlayerID].AxisY;

            float movementX = axisX * Time.deltaTime * PlayerSpeed;
            float movementY = axisY * Time.deltaTime * PlayerSpeed;
            Vector3 newPosition = transform.position + new Vector3(movementX, movementY, 0);
            Rigidbody2D.MovePosition(newPosition);

            //check input of players
            if (ArcadeInput.Players[(int)PlayerID].Action1.Pressed)
            {
                Interact();
            }
        }


        void Interact()
        {
            if (PlayerID == PlayerID.Player1)
            {
            

            }
            if (PlayerID == PlayerID.Player2)
            {

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (PlayerID == PlayerID.Player1)
            {
                if (other.CompareName("2026-team03-player1-object"))
                {
                    Player1Hovering = true;
                }

            }
            if (PlayerID == PlayerID.Player2)
            {
                if (other.CompareName("2026-team03-player2-object"))
                {
                    Player2Hovering = true;
                }
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (PlayerID == PlayerID.Player1)
            {
                if (other.CompareName("2026-team03-player1-object"))
                {
                    Player1Hovering = false;
                }

            }
            if (PlayerID == PlayerID.Player2)
            {
                if (other.CompareName("2026-team03-player2-object"))
                {
                    Player2Hovering = false;
                }
            }
        }
    }
}