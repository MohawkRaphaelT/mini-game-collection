/* Name: Liam McDougall
 * Date: 2026/11/05
 */
using MiniGameCollection;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class SunMovePlay1 : MonoBehaviour
{

    float position;

    // Reference to the PlayerAnimations script
    public PlayerAnimations playAnims;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position.x;

        // Get the PlayerAnimations component from the Player1 GameObject
        playAnims = GameObject.Find("Player1").GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Pressed Right arrow");
            if (position < -13)
            {
                position = 13;
                transform.position = new Vector3(position, transform.position.y, transform.position.z);
            }
            
            position = position - 0.0001f;
            transform.position = new Vector3(position, transform.position.y, transform.position.z);

            // Set the "isMoving" parameter in the Animator to 1 when the player is moving
            playAnims.anim.SetFloat("isMoving", 1);
        }
        else
        {
            // Set the "isMoving" parameter in the Animator to 0 when the player is not moving
            playAnims.anim.SetFloat("isMoving", 0);
        }
    }
}