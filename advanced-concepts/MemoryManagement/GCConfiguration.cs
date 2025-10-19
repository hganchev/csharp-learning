using System.Runtime;

namespace AdvancedConcepts.MemoryManagement;

/// <summary>
/// GC configuration and tuning
/// </summary>
public static class GCConfiguration
{
    public static void ConfigureGC()
    {
        // Server GC vs Workstation GC
        // Set in .csproj or runtimeconfig.json
        Console.WriteLine("GC Mode Configuration:");
        Console.WriteLine("  - Workstation GC: Lower latency, better for client apps");
        Console.WriteLine("  - Server GC: Higher throughput, better for server apps");
        Console.WriteLine($"  Current: {(GCSettings.IsServerGC ? "Server" : "Workstation")}");
        
        // GC Latency Mode
        Console.WriteLine($"\nGC Latency Mode: {GCSettings.LatencyMode}");
        Console.WriteLine("  - Interactive: Default, balanced");
        Console.WriteLine("  - LowLatency: Minimize pause times");
        Console.WriteLine("  - Batch: Maximize throughput");
        Console.WriteLine("  - SustainedLowLatency: Consistent low latency");
        
        // Large Object Heap compaction
        Console.WriteLine("\nLarge Object Heap (LOH):");
        Console.WriteLine("  - Objects > 85KB go to LOH");
        Console.WriteLine("  - LOH is not compacted by default");
        Console.WriteLine("  - Can enable with GCSettings.LargeObjectHeapCompactionMode");
    }
}
