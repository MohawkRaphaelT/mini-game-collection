using UnityEngine;
namespace MiniGameCollection.Games2024.Team13
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target; // Character to follow
        public Vector3 offset; // Offset from the character
        public float smoothSpeed = 0.125f; // Smoothness of the camera movement
        void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}