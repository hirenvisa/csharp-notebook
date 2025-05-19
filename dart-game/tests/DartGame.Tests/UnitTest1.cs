namespace DartGame.Tests;

public class UnitTest1
{
    [Fact]
    public void find_possible_ways_to_win_the_game()
    {
        int target = 2;
        int expectedWays = 2;
        int actualWays = 0;
        int maxDarts = 3;

        var validScores = GetValidScores();
        var possibleWays = new List<List<int>>();
        var currentScore = new List<int>();
        
        FindPossibleWaysToWinGame(target, maxDarts, possibleWays, validScores, currentScore);
        actualWays = possibleWays.Count;

        Assert.Equal(expectedWays, actualWays);
    }

    private void FindPossibleWaysToWinGame(int target, int maxDarts, 
        List<List<int>> possibleWays, List<int> validScores, List<int> currentScore)
    {
        if (target == 0 && currentScore.Count <= maxDarts)
        {
            possibleWays.Add(new List<int>(currentScore));
            return;
        }

        if (target < 0 || currentScore.Count >= maxDarts) return;

        foreach (var score in validScores)
        {
            currentScore.Add(score);
            FindPossibleWaysToWinGame(target - score, maxDarts, possibleWays, validScores, currentScore);
            currentScore.RemoveAt(currentScore.Count - 1);
        }
    }

    private List<int> GetValidScores()
    {
        var scores = new HashSet<int>();

        for (int i = 1; i <= 20; i++) scores.Add(i);
        for (int i = 1; i <= 20; i++) scores.Add(i*2);
        for (int i = 1; i <= 20; i++) scores.Add(i*3);

        return scores.ToList();
    }
}