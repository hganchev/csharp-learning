namespace AdvancedConcepts.TypeComparison;

/// <summary>
/// STRUCT: Value type, stack-allocated, no inheritance
/// Best for small, immutable data with value semantics
/// </summary>
public readonly struct PointStruct
{
    public int X { get; init; }
    public int Y { get; init; }
    
    public PointStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    // Structs get value equality by default (but can be slow)
    // Better to implement explicitly for performance
    public override string ToString() => $"({X}, {Y})";
}
