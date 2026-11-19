using UnityEngine;

namespace MiniGameCollection.Games2026.Team07
{
    public class Bullet : MiniGameBehaviour
    {
        [field: SerializeField] public BulletOwner Owner { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public float SelfDestructTime { get; private set; } = 10; // 10 seconds
        [field: SerializeField] public int PointPenalty { get; set; } = -100;

        [field: ReadOnlyGUI]
        [field: SerializeField] public ScoreKeeper ScoreKeeper { get; private set; }

        // Abomination of a function...
        public void Shoot(BulletOwner owner, Vector2 direction, float speed, ScoreKeeper scoreKeeper, MiniGameManager miniGameManager)
        {
            // Assign references
            ScoreKeeper = scoreKeeper;
            MiniGameManager = miniGameManager;
            // Set up who shot this bullet
            this.Owner = owner;
            // Assign movement direction
            Rigidbody2D.velocity = direction * speed;

            // Self-destruct this bullet after time
            Destroy(this.gameObject, SelfDestructTime);
        }

        private PlayerID OwnerToPlayerID(BulletOwner owner)
        {
            return (owner) switch
            {
                BulletOwner.Player1 => PlayerID.Player1,
                BulletOwner.Player2 => PlayerID.Player2,
                _ => throw new System.NotImplementedException(),
            };
        }

        private void DestroyBullet()
        {
            Destroy(this.gameObject);
        }

        protected override void OnGameEnd()
        {
            DestroyBullet();
        }

        private void OnTriggerEnter2D(Collider2D collider2d)
        {
            var enemy = collider2d.GetComponent<Enemy>();

            switch (Owner)
            {
                case BulletOwner.Player1:
                case BulletOwner.Player2:
                    if (enemy != null)
                    {
                        // Add to bullet owner's score
                        

                        // Destroy enemy and bullet
                        enemy.DestroyEnemy();
                        DestroyBullet();
                    }
                    break;

                case BulletOwner.Enemy:
                    break;
            }
        }

        private void OnValidate()
        {
            if (Rigidbody2D == null)
                Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
