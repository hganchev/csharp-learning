namespace AdvancedConcepts.TypeComparison;

/// <summary>
/// RECORD STRUCT: Value type with record features (C# 10+)
/// Combines benefits of struct (stack allocation) and record (value equality, immutability)
/// </summary>
public readonly record struct CoordinateRecordStruct(double Latitude, double Longitude);
