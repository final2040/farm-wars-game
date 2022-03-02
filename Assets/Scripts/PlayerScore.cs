public class PlayerScore
{
    public PlayerScore(string name, int maxWave, int score)
    {
        Name = name;
        MaxWave = maxWave;
        Score = score;
    }

    public PlayerScore()
    {
        
    }

    public string Name { get; private set; }
    public int MaxWave { get; private set; }
    public int Score { get; private set; }
}