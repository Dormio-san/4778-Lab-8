public class PlayerHealth
{
    private static int health = 3;

    public int Health
    {
        get => health;
        set => health = value;
    }

    public void ChangeHealth(int healthChange)
    {
        health += healthChange;

        // Cap the health at 0 so it can't go negative.
        if (health < 0)
        {
            health = 0;
        }
    }

    // Used when game begins to reset the health to 3.
    public void ResetHealth()
    {
        health = 3;
    }
}