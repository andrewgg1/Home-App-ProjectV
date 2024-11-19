using System.Collections.Generic;

public class UserService
{
    // In-memory user data storage
    private readonly Dictionary<string, (string Password, string Email)> _users = new();

    // Method to register a new user
    public bool RegisterUser(string username, string password, string email)
    {
        // Check if the user already exists
        if (_users.ContainsKey(username))
        {
            return false; // User already exists
        }

        // Add the user to the in-memory storage
        _users[username] = (password, email);
        return true; // Registration successful
    }

    // Method to authenticate a user
    public bool AuthenticateUser(string username, string password)
    {
        // Check if the username exists and the password matches
        return _users.ContainsKey(username) && _users[username].Password == password;
    }

    // Method to check if a user already exists (optional)
    public bool UserExists(string username)
    {
        return _users.ContainsKey(username);
    }
}
