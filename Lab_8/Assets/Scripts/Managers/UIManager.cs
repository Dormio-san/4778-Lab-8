using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private GameOverUI gameOverUI;

    private void Start()
    {
        // Initialize the UI components and set their
        scoreUI.Initialize(player);
        healthUI.Initialize(player);
        gameOverUI.Initialize(player);

        // When the game begins, reset the player's score and health to their default values.
        player.BeginGameReset();
    }

    private void Update()
    {
        // Testing key to decrease the player's health.
        // This will most likely stay in because we don't take damage from anything in the game, but still want to see this function.
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            player.ChangeHealth(-1);
        }
    }
}