using Final_Project___Sequence_Game.Data;
using Final_Project___Sequence_Game.Models;

namespace Final_Project___Sequence_Game.Services;

/// <summary>
/// Service for managing player authentication and validation operations.
/// Centralizes all database queries and input validation for efficiency and maintainability.
/// </summary>
public class AuthenticationService : IDisposable
{
    private readonly SequenceGameDbContext _context;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the AuthenticationService with a database context.
    /// </summary>
    public AuthenticationService()
    {
        _context = new SequenceGameDbContext();
    }

    /// <summary>
    /// Attempts to authenticate a player with the provided credentials.
    /// Performs a single database query for efficiency.
    /// </summary>
    /// <param name="username">The player's username.</param>
    /// <param name="password">The player's password hash.</param>
    /// <param name="email">The player's email address.</param>
    /// <returns>The authenticated player if credentials match; otherwise null.</returns>
    public Models.PlayerData? AuthenticatePlayer(string username, string password, string email)
    {
        if (!ValidateInputs(username, password, email))
            return null;

        try
        {
            return _context.PlayerData.FirstOrDefault(p =>
                p.Username == username &&
                p.PasswordHash == password &&
                p.PlayerEmail == email);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Authentication error: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Checks if a username already exists in the database.
    /// Returns true if the username exists.
    /// </summary>
    /// <param name="username">The username to check.</param>
    /// <returns>True if the username exists; otherwise, false.</returns>
    public bool UsernameExists(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;

        try
        {
            return _context.PlayerData.Any(p => p.Username == username);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Username check error: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Checks if an email address already exists in the database.
    /// Returns true if the email exists.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <returns>True if the email exists; otherwise, false.</returns>
    public bool EmailExists(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            return _context.PlayerData.Any(p => p.PlayerEmail == email);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Email check error: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Creates a new player account with the provided credentials.
    /// </summary>
    /// <param name="username">The new player's username.</param>
    /// <param name="password">The new player's password hash.</param>
    /// <param name="email">The new player's email address.</param>
    /// <returns>The created player if successful; otherwise null.</returns>
    public Models.PlayerData? CreatePlayer(string username, string password, string email)
    {
        if (!ValidateInputs(username, password, email))
            return null;

        if (UsernameExists(username) || EmailExists(email))
            return null;

        try
        {
            var player = new Models.PlayerData
            {
                Username = username,
                PasswordHash = password,
                PlayerEmail = email
            };

            _context.PlayerData.Add(player);
            _context.SaveChanges();
            return player;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Player creation error: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Validates that none of the input strings are null, empty, or whitespace.
    /// </summary>
    /// <param name="inputs">The strings to validate.</param>
    /// <returns>True if all inputs are valid; otherwise, false.</returns>
    private static bool ValidateInputs(params string[] inputs)
    {
        return inputs.All(input => !string.IsNullOrWhiteSpace(input));
    }

    /// <summary>
    /// Disposes the database context and releases all resources.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
            return;

        _context?.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Finalizer ensures resource cleanup if Dispose is not called.
    /// </summary>
    ~AuthenticationService()
    {
        Dispose();
    }
}
