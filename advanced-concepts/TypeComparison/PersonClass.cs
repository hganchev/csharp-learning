namespace AdvancedConcepts.TypeComparison;

/// <summary>
/// CLASS: Reference type, heap-allocated, supports inheritance
/// </summary>
public class PersonClass
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public PersonClass(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    // Must implement equality manually if needed
    public override bool Equals(object? obj)
    {
        return obj is PersonClass other && 
               Name == other.Name && 
               Age == other.Age;
    }
    
    public override int GetHashCode() => HashCode.Combine(Name, Age);
}
