using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameCollection.Games2024.Team13
{
    public class MenuController : MonoBehaviour
    {
        // Update method to check for button presses
        private void Update()
        {
            // Check if either Player 1 or Player 2 presses the action button to start the game
            if (ArcadeInput.Player1.Action1.Pressed || ArcadeInput.Player2.Action1.Pressed)
            {
                PlayGame();
            }

            // Check if either Player 1 or Player 2 presses the action button to go to the main menu
            if (ArcadeInput.Player1.Action2.Pressed || ArcadeInput.Player2.Action2.Pressed)
            {
                GoToMainMenu();
            }

            // Check for Player 1's button to start the game
            if (ArcadeInput.Player1.Action1.Pressed)
            {
                Debug.Log("Player 1 Action1 pressed");

            }

            // Check for Player 2's button to go to the main menu
            if (ArcadeInput.Player2.Action1.Pressed)
            {
                Debug.Log("Player 2 Action1 pressed");

            }

            // Log to check if Action2 is detected for troubleshooting
            if (ArcadeInput.Player1.Action2.Pressed)
            {
                Debug.Log("Player 1 Action2 pressed");
            }

            if (ArcadeInput.Player2.Action2.Pressed)
            {
                Debug.Log("Player 2 Action2 pressed");
            }


        }

        public void PlayGame()
        {
            SceneManager.LoadScene("2024-team13-game");
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("2024-team13-start");
        }
    }
}