using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2026.Team01
{
    public class PlayerController : MiniGameBehaviour
    {
        [field: SerializeField] public PlayerID PlayerID { get; private set; }
        [field: SerializeField] public GameOrganizer GameOrganizer { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set;  }
        [field: SerializeField] public float Accel { get; private set;  }
        [field: SerializeField] public float Decel { get; private set;  }

        [field: SerializeField] public float SpriteSize { get; private set; }


        private float AxisX;
        private float AxisY;

        private Animator animator;
        private Rigidbody2D rb2d;
        private Transform hand;
        private GameObject currentTouching;
        private GameObject currentTool;

        public enum TaskType
        {
            None,
            Tree,
            Rock,
            Mushroom,
            Weed
        }
        public TaskType currentTask;
        public TaskType lastTask;
        public int Score;
        public float SpeedBoost;
        
        void Awake()
        {
            hand = transform.Find("Hand");
            animator = GetComponentInChildren<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            Debug.Log(animator.ToString() + PlayerID);
            currentTask = TaskType.None;
            lastTask = TaskType.None;
            SpeedBoost = 0;
        }
        void Update()
        {
            // Get Input
            AxisX = ArcadeInput.Players[(int)PlayerID].AxisX;
            AxisY = ArcadeInput.Players[(int)PlayerID].AxisY;
            //Debug.Log($"Player: {PlayerID}\nX: {axisX}\nY: {axisY}");


            // Always scale the player back to (1, 1, 1)
            Vector3 targetMove = new Vector3(SpriteSize, SpriteSize, SpriteSize);
            if (transform.localScale != targetMove) { transform.localScale = Vector3.Lerp(transform.localScale, targetMove, 10f * Time.deltaTime); }

            
        }
        void FixedUpdate()
        {
            // Change Movement
            Vector2 movement = new Vector2(AxisX, AxisY);
            movement.Normalize();

            Vector2 velocity = rb2d.velocity;
            float targetX = movement.x * (PlayerSpeed + SpeedBoost);
            float rateX;
            float targetY = movement.y * (PlayerSpeed + SpeedBoost);
            float rateY;
            // Check if the player is moving at ALL
            if (Mathf.Abs(AxisX) > 0.01f || Mathf.Abs(AxisY) > 0.01f)
            {
                rateX = Accel;
                rateY = Accel;
                if (Mathf.Sign(targetX) != Mathf.Sign(velocity.x) && Mathf.Abs(velocity.x) > 0.01f)
                {
                    rateX = Decel;
                }
                if (Mathf.Sign(targetY) != Mathf.Sign(velocity.y) && Mathf.Abs(velocity.y) > 0.01f)
                {
                    rateY = Decel;
                }
            }
            else
            {
                rateX = Decel;
                rateY = Decel;
            }
            velocity.x = Mathf.MoveTowards(velocity.x, targetX, rateX * Time.fixedDeltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, targetY, rateY * Time.fixedDeltaTime);
            rb2d.velocity = velocity;

            // Check for if player has a tool and wants to drop it
            if (ArcadeInput.Players[(int)PlayerID].Action2.Pressed && hand.GetComponentInChildren<ToolScript>())
            {
                ToolScript toolHeld = GetComponentInChildren<ToolScript>();
                toolHeld.Drop();
            }
            // Check for if player has a tool and wants to swing it
            if (ArcadeInput.Players[(int)PlayerID].Action1.Pressed && hand.GetComponentInChildren<ToolScript>())
            {
                Swing();
            }
            // Update current tool
            if (hand.Find("Handle") != null)
            {
                currentTool = hand.Find("Handle").GetComponentInChildren<ToolScript>().gameObject;
                
            }
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            // Filter out tools and players
            if (!col.gameObject.GetComponent<ToolScript>() && !col.gameObject.GetComponent<PlayerController>())
            {
                currentTouching = col.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D col)
        {
            // Filter out tools and players
            if (!col.gameObject.GetComponent<ToolScript>() && !col.gameObject.GetComponent<PlayerController>())
            {
                if (currentTouching == col.gameObject)
                {
                    currentTouching = null;
                }
            }
        }
        protected override void OnEnable()
        {
            
        }
        public void Swing()
        {
            // Debug.Log($"Swing here for {PlayerID}");

            // Animation
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("Swing");
            }

            if (currentTouching != null)
            {
                string currentTouchingName = currentTouching.name;
                // Swing at Axe
                if (currentTouchingName == "Tree" && ArcadeInput.Players[(int)PlayerID].Action1.Pressed && currentTool.name == "Axe")
                {
                    currentTouching.SetActive(false);
                    GameOrganizer.CheckList(GameOrganizer.treeList);

                }
                // Swing at Weed
                if (currentTouchingName == "Rock" && ArcadeInput.Players[(int)PlayerID].Action1.Pressed && currentTool.name == "Pickaxe")
                {
                    currentTouching.SetActive(false);
                    GameOrganizer.CheckList(GameOrganizer.rockList);

                }
                // Swing at Axe
                if (currentTouchingName == "Dig" && ArcadeInput.Players[(int)PlayerID].Action1.Pressed && currentTool.name == "Shovel")
                {
                    currentTouching.SetActive(false);
                    GameOrganizer.CheckList(GameOrganizer.mushroomList);

                }
                // Swing at Axe
                if (currentTouchingName == "Weed" && ArcadeInput.Players[(int)PlayerID].Action1.Pressed && currentTool.name == "Hoe")
                {
                    currentTouching.SetActive(false);
                    GameOrganizer.CheckList(GameOrganizer.weedList);

                }
            }
            

        }
    }
}
