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
}