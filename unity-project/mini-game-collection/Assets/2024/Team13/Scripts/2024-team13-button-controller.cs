using UnityEngine;
namespace MiniGameCollection.Games2024.Team13
{
    public class DoorButtonController : MonoBehaviour
    {
        public GameObject door;
        private void OnTriggerStay(Collider other)
        {
            // Check if Player 2 is on the button
            if (other.CompareTag("Player2")) // Assuming Player 2 has a tag "Player2"
            {
                // Open the door by deactivating it
                door.SetActive(false);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            // When Player 2 leaves the button, close the door
            if (other.CompareTag("Player2"))
            {
                // Closes the door by reactivating it
                door.SetActive(true);
            }
        }
    }
}