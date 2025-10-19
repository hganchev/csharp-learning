namespace AdvancedConcepts.MemoryManagement;

public readonly struct PointStruct
{
    public int X { get; init; }
    public int Y { get; init; }
    public PointStruct(int x, int y) { X = x; Y = y; }
    public override string ToString() => $"({X}, {Y})";
}
