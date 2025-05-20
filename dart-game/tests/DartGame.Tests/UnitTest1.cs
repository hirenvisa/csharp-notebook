namespace DartGame.Tests;

public class UnitTest1
{
    #region "Dart Game tests"

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

    [Fact]
    public void find_possible_ways_to_win_the_game_using_core_domain()
    {
        int target = 2;
        int expectedWays = 3;
        int actualWays = 0;
        int maxDarts = 3;

        var gameScore = new DartGameScore();
        List<Score> validScores = gameScore.Scores.ToList();
        var possibleWays = new List<List<Score>>();
        var currentScore = new List<Score>();

        FindPossibleWaysToWinGame(target, maxDarts, possibleWays, validScores, currentScore);
        actualWays = possibleWays.Count;

        Assert.Equal(expectedWays, actualWays);
    }

    [Fact]
    public void find_possible_ways_to_win_the_game_which_ends_with_double()
    {
        int target = 2;
        int expectedWays = 1;
        int actualWays = 0;
        int maxDarts = 3;

        var gameScore = new DartGameScore();
        List<Score> validScores = gameScore.Scores.ToList();
        var possibleWays = new List<List<Score>>();
        var currentScore = new List<Score>();

        FindPossibleWaysToWinGameAndEndingWithDouble(target, maxDarts, possibleWays, validScores, currentScore);
        actualWays = possibleWays.Count;

        Assert.Equal(expectedWays, actualWays);
    }

    [Fact]
    public void Leaderboard_displays_top_k_players()
    {
        // Arrange
        int k = 3;
        List<Player> players = new List<Player>()
        {
            new Player() { Name = "Sample1", Score = 60 },
            new Player() { Name = "Sample2", Score = 70 },
            new Player() { Name = "Sample3", Score = 80 },
            new Player() { Name = "Sample6", Score = 501 },
        };

        // Act
        var topPlayers = LeaderBoard.GetTopKPlayers(players, k);

        // Assert
        Assert.Equal(3, topPlayers.Count);
        Assert.Equal(501, topPlayers[0].Score);
    }

    #endregion

    #region "Helper methods"

    private void FindPossibleWaysToWinGame<T>(int target, int maxDarts,
        List<List<T>> possibleWays, List<T> validScores, List<T> currentScore)
    {
        if (target == 0 && currentScore.Count <= maxDarts)
        {
            possibleWays.Add(new List<T>(currentScore));
            return;
        }

        if (target < 0 || currentScore.Count >= maxDarts) return;

        foreach (var score in validScores)
        {
            currentScore.Add(score);
            int scoreValue = score is Score s ? s.Total : (int)(object)score;
            FindPossibleWaysToWinGame(target - scoreValue, maxDarts, possibleWays, validScores, currentScore);
            currentScore.RemoveAt(currentScore.Count - 1);
        }
    }


    private void FindPossibleWaysToWinGameAndEndingWithDouble(int target, int maxDarts,
        List<List<Score>> possibleWays, List<Score> validScores, List<Score> currentScore)
    {
        if (target == 0 && currentScore.Count <= maxDarts)
        {
            Score score = currentScore.Last();
            if (score.Multiplier == ScoreMultiplier.Double)
            {
                possibleWays.Add(new List<Score>(currentScore));
            }

            return;
        }

        if (target < 0 || currentScore.Count >= maxDarts) return;

        foreach (var score in validScores)
        {
            currentScore.Add(score);
            FindPossibleWaysToWinGameAndEndingWithDouble(target - score.Total, maxDarts, possibleWays, validScores,
                currentScore);
            currentScore.RemoveAt(currentScore.Count - 1);
        }
    }

    private List<int> GetValidScores()
    {
        var scores = new HashSet<int>();

        for (int i = 1; i <= 20; i++) scores.Add(i);
        for (int i = 1; i <= 20; i++) scores.Add(i * 2);
        for (int i = 1; i <= 20; i++) scores.Add(i * 3);

        return scores.ToList();
    }

    #endregion
}