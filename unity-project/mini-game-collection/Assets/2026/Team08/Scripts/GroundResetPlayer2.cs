/* Name: Liam McDougall
 * Date: 2026/11/05
 */
using UnityEngine;

public class GroundReset2 : MonoBehaviour
{    float position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position.x;
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed D Key");
            if (position < -10)
            {
                position = 11;
                transform.position = new Vector3(position, transform.position.y, transform.position.z);
            }
                position = position - 0.01f;
                transform.position = new Vector3(position, transform.position.y, transform.position.z);
            
        }
    }
}
