namespace AdvancedConcepts.TypeComparison;

/// <summary>
/// RECORD with inheritance
/// </summary>
public record Manager(string Name, string Department, int TeamSize) 
    : EmployeeRecord(Name, Department);
