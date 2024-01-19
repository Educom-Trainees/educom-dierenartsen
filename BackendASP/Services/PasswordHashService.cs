using BackendASP.Models;
using Microsoft.AspNetCore.Identity;

public interface IPasswordHasherService
{
    string HashPassword(string password);
}

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    {
        // Use the PasswordHasher<User> internally
        return new PasswordHasher<User>().HashPassword(null, password);
    }
}