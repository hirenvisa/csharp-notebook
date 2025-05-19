namespace DartGame;

public struct Score: IEquatable<Score>
{
    public int BaseValue { get; private set; }
    public ScoreMultiplier Multiplier { get; private set; }
    
    public Score(ScoreMultiplier multiplier, int baseValue)
    {
        Multiplier = multiplier;
        BaseValue = baseValue;
    }
    
    public int Total => BaseValue * (int)Multiplier;

    public bool Equals(Score other)
    {
        return Multiplier == other.Multiplier && BaseValue == other.BaseValue;
    }

    public override bool Equals(object? obj)
    {
        return obj is Score other && Equals(other);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}