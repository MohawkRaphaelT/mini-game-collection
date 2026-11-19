using UnityEngine;

namespace MiniGameCollection.Games2026.Team07
{
    public class PlayerController : MiniGameBehaviour
    {
        [field: SerializeField] public PlayerID PlayerID { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public ScoreKeeper ScoreKeeper { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; } = 8f; // units per second
        [field: SerializeField] public float ShipSpeed { get; private set; } = 10f; // units per second
        [field: SerializeField] public float MinMaxY { get; private set; } = 4f; // constraints along Y axis movement
        [field: SerializeField] public bool CanShoot { get; private set; } = false;

        private BulletOwner Owner => PlayerID switch
        {
            PlayerID.Player1 => BulletOwner.Player1,
            PlayerID.Player2 => BulletOwner.Player2,
            _ => throw new System.Exception(),
        };


        void Update()
        {
            float axisX = ArcadeInput.Players[(int)PlayerID].AxisX;
            float axisY = ArcadeInput.Players[(int)PlayerID].AxisY;


            Vector2 movement = new Vector2(axisX, axisY);

            if (movement.magnitude > 0.1f)
            {
                float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f; //https://docs.unity3d.com/2020.2/Documentation/ScriptReference/Mathf.Atan2.html 

                Rigidbody2D.rotation = angle;
            }

            movement = movement.normalized;

            Vector2 newPosition = Rigidbody2D.position + movement * ShipSpeed * Time.deltaTime;

            Rigidbody2D.MovePosition(newPosition);

            if (!CanShoot)
                return;
            if (ArcadeInput.Players[(int)PlayerID].Action1.Pressed)
                ShootBullet();
        }

        void ShootBullet()
        {
            Vector3 position = transform.position + transform.up;
            GameObject prefab = Instantiate(BulletPrefab, position, transform.rotation);
            Bullet bullet = prefab.GetComponent<Bullet>();
            bullet.Shoot(Owner, transform.up, BulletSpeed, ScoreKeeper, MiniGameManager);
        }

        private void OnValidate()
        {
            if (Rigidbody2D == null)
                Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected override void OnGameStart()
        {
            CanShoot = true;
        }

        protected override void OnGameEnd()
        {
            CanShoot = false;
        }
    }
}
