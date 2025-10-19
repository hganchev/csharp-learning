namespace AdvancedConcepts.DependencyInjection;

// Validator
public interface IValidator<T>
{
    bool Validate(T item);
}

public class UserValidator : IValidator<User>
{
    public bool Validate(User user)
    {
        return !string.IsNullOrEmpty(user.Name);
    }
}
