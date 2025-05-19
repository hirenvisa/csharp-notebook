namespace DartGame;

public class DartGameScore
{
    public HashSet<Score> Scores { get; private set; }

    public DartGameScore()
    {
        InitializeScores();
    }

    private void InitializeScores()
    {
        Scores = new HashSet<Score>();
        for (int i = 1; i <= 20; i++)
            Scores.Add(new Score(ScoreMultiplier.Single,i));
        for (int i = 1; i <= 20; i++)
            Scores.Add(new Score(ScoreMultiplier.Double,i));
        for (int i = 1; i <= 20; i++)
            Scores.Add(new Score(ScoreMultiplier.Treble,i));
    }
    
}