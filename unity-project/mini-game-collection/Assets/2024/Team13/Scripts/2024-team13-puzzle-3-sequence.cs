using UnityEngine;
namespace MiniGameCollection.Games2024.Team13
{
    public class Puzzle3Sequence : MonoBehaviour
    {
        public int tileIndex; // (0 for Left, 1 for Up, 2 for Right)
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player2")) // Assuming Player 2 has a tag "Player2"
            {
                // Notify the LaserController of the tile stepped on
                FindObjectOfType<LazerControl>().TileSteppedOn(tileIndex);
            }
        }
    }
}