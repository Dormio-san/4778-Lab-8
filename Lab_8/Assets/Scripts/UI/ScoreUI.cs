using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour, IObserver
{
    // Assign the scoreText variable to the TextMeshProUGUI component on the same GameObject.
    private TextMeshProUGUI scoreText => GetComponent<TextMeshProUGUI>();
    private Player player;

    public void Initialize(Player player)
    {
        this.player = player;
        player.Attach(this);
        UpdateScoreText();
    }

    public void OnNotify()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + player.playerScore.Score;
    }

    private void OnDestroy()
    {
        player.Detach(this);
    }
}