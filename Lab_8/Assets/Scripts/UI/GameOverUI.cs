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
        gameOverDisplay.SetActive(true);
        InputManager.playerInput.SwitchCurrentActionMap("UI");
    }

    private void OnDestroy()
    {
        player.Detach(this);
    }
}