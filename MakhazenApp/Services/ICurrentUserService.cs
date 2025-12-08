using Makhazen.Models;

namespace MakhazenApp.Services;

public interface ICurrentUserService
{
    int? UserId { get; }
    string? Username { get; }
    string? FullName { get; }
    Task<User?> GetUserAsync();
}
