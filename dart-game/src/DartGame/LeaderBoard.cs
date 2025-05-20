namespace DartGame;

public class LeaderBoard
{
    public static List<Player> GetTopKPlayers(List<Player> players, int k)
    {
        var minHeap = new PriorityQueue<Player, int>();

        foreach (var player in players)
        {
            minHeap.Enqueue(player, player.Score);
            
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        var topPlayers = new List<Player>();
        while (minHeap.Count > 0)
        {
            topPlayers.Add(minHeap.Dequeue());
        }

        topPlayers.Reverse();
        return topPlayers;
    }
}