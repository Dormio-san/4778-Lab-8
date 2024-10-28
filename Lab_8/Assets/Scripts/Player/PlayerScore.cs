public class PlayerScore
{
    private static int score = 0;

    public int Score
    {
        get => score;
        set => score = value;
    }

    public void ChangeScore(int scoreChange)
    {
        score += scoreChange;
    }

    // Used when game begins to reset the score to zero.
    public void ResetScore()
    {
        score = 0;
    }
}