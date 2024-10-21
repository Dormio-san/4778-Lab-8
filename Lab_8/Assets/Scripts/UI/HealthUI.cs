using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour, IObserver
{
    private TextMeshProUGUI healthText => GetComponent<TextMeshProUGUI>();
    private Player player;

    public void Initialize(Player player)
    {
        this.player = player;
        player.Attach(this);
        UpdateHealthText();
    }

    public void OnNotify()
    {
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "Lives: " + player.playerHealth.Health;
    }

    private void OnDestroy()
    {
        player.Detach(this);
    }
}