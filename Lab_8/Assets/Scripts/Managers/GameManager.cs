using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

   
    private void Update()
    {
        InputCheck();
    }

    // Checks for player inputs.
    private void InputCheck()
    {
        if (InputManager.instance.restartInput)
        {
            Restart();
        }

        if (InputManager.instance.quitInput)
        {
            Quit();
        }
        if (Input.GetKeyDown(KeyCode.S)) // Check for the save input
        {
            SavingService.SaveGame("player_save.json"); // Save the game
            Debug.Log("Game saved.");
        }

        if (Input.GetKeyDown(KeyCode.L)) // Check for the load input
        {
            if (SavingService.LoadGame("player_save.json")) // Load the game
            {
                Debug.Log("Game loaded.");
            }
        }


    }

    // Reloads the current scene that the player is in.
    private void Restart()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        //Debug.Log($"Restarted {currentScene} scene.");
    }

    // Quits the game.
    private void Quit()
    {
        // Quit in the unity editor if in the unity editor.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        // Quit in the unity player if not in unity editor.
        Application.Quit();
    }
}