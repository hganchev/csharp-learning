namespace AdvancedConcepts.TypeComparison;

/// <summary>
/// RECORD: Reference type with value semantics, immutable by default
/// Best for DTOs, value objects, immutable data
/// Records automatically implement:
/// - Value-based equality
/// - GetHashCode
/// - ToString
/// - Deconstruction
/// - with-expressions for non-destructive mutation
/// </summary>
public record EmployeeRecord(string Name, string Department);
