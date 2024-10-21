public class PlayerHealth
{
    private int health = 3;

    public int Health
    {
        get => health;
        set => health = value;
    }

    public void ChangeHealth(int healthChange)
    {
        health += healthChange;

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