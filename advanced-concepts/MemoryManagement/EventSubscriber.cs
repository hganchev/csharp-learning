namespace AdvancedConcepts.MemoryManagement;

public class EventSubscriber
{
    public void HandleEvent(object? sender, EventArgs e)
    {
        Console.WriteLine("Event handled");
    }
}
