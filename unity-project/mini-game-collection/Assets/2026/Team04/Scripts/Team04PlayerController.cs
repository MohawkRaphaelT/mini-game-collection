using UnityEngine;

namespace MiniGameCollection.Games2025.Team00
{
    public class Team04PlayerController : MiniGameBehaviour
    {
        [field: SerializeField] public PlayerID PlayerID { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public float playerSpeed { get; private set; } = 10f; // units per second

        /*
        private BulletOwner Owner => PlayerID switch
        {
            PlayerID.Player1 => BulletOwner.Player1,
            PlayerID.Player2 => BulletOwner.Player2,
            _ => throw new System.Exception(),
        };
        */

        void Update()
        {
            float axisX = ArcadeInput.Players[(int)PlayerID].AxisX;
            float axisY = ArcadeInput.Players[(int)PlayerID].AxisY;

            float movementX = axisX * Time.deltaTime * playerSpeed;
            float movementY = axisY * Time.deltaTime * playerSpeed;

            Vector3 newPosition = transform.position + new Vector3(movementX, movementY, 0);
            Rigidbody2D.MovePosition(newPosition);

            /*
            if (!CanShoot)
                return;
            if (ArcadeInput.Players[(int)PlayerID].Action1.Pressed)
                ShootBullet();
            */
        }
        /*
        void ShootBullet()
        {
            Vector3 position = transform.position + transform.up;
            GameObject prefab = Instantiate(BulletPrefab, position, transform.rotation);
            Bullet bullet = prefab.GetComponent<Bullet>();
            bullet.Shoot(Owner, transform.up, BulletSpeed, ScoreKeeper, MiniGameManager);
        }
        */
        private void OnValidate()
        {
            if (Rigidbody2D == null)
                Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
