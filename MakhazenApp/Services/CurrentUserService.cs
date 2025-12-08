using Microsoft.AspNetCore.Http;
using Makhazen.Models;
using MakhazenApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MakhazenApp.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _db;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
    {
        _httpContextAccessor = httpContextAccessor;
        _db = db;
    }

    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public int? UserId
    {
        get
        {
            var idClaim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(idClaim, out var id)) return id;
            return null;
        }
    }

    public string? Username => User?.Identity?.Name;

    public string? FullName => User?.FindFirst("FullName")?.Value;

    public async Task<User?> GetUserAsync()
    {
        if (UserId == null) return null;
        return await _db.Users.FirstOrDefaultAsync(u => u.UserID == UserId.Value);
    }
}
