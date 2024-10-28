using UnityEngine;

public class GameOverUI : MonoBehaviour, IObserver
{
    [SerializeField] private GameObject gameOverDisplay;
    private Player player;

    public void Initialize(Player player)
    {
        this.player = player;
        player.Attach(this);
    }

    public void OnNotify()
    {
        GameOver();
    }

    private void GameOver()
    {
        // Turn on the game over display and switch the input to the UI input map, which disables user's in-game actions.
        gameOverDisplay.SetActive(true);
        InputManager.playerInput.SwitchCurrentActionMap("UI");
    }

    private void OnDestroy()
    {
        player.Detach(this);
    }
}