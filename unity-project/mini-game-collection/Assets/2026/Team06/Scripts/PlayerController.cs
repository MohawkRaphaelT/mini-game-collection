using UnityEngine;

namespace MiniGameCollection.Games2026.Team06
{
    public class PlayerController : MiniGameBehaviour
    {
        [field: SerializeField] public PlayerID PlayerID { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public bool CanPlay { get; private set; } = false;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
        
        [SerializeField] private TurfGrid grid;
        [SerializeField] private Bomb bombPrefab;
        [SerializeField] private float bombCooldown = 5f;

        private Vector2 facing = Vector2.right;
        private float nextBombTime = 0f;

        private void Start()
        {
            if (PlayerID == PlayerID.Player2)
                facing = Vector2.left;
        }

        void Update()
        {
            if (!CanPlay) return;

           ArcadeInput.Player input = ArcadeInput.Player1;
            if (PlayerID == PlayerID.Player2)
                input = ArcadeInput.Player2;

            Vector2 stick = input.Joystick8Way;
            Rigidbody2D.velocity = stick * MoveSpeed;

            if (stick != Vector2.zero)
                facing = stick.normalized;

            grid.Paint(transform.position, PlayerID);


            if (input.Action2.Pressed && Time.time >= nextBombTime)
            {
                nextBombTime = Time.time + bombCooldown;

                Vector3 spawnPosition = transform.position + (Vector3)(facing * 0.6f);
                Bomb bomb = Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
                bomb.Throw(grid, PlayerID, facing);
            }
        }


        private void OnValidate()
        {
            if (Rigidbody2D == null)
                Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected override void OnGameStart()
        {
            CanPlay = true;
        }

        protected override void OnGameEnd()
        {
            CanPlay = false;
            Rigidbody2D.velocity = Vector2.zero;
        }
    }
}
