namespace AdvancedConcepts.DependencyInjection;

// Repository pattern
public interface IUserRepository
{
    User? GetById(int id);
    void Save(User user);
}

public class UserRepository : IUserRepository
{
    public User? GetById(int id) => new User { Id = id, Name = "John" };
    public void Save(User user) => Console.WriteLine($"Saving user {user.Id}");
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
