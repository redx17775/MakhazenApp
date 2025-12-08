using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MakhazenApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MakhazenApp.Pages.Account;
public class LogoutModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public LogoutModel(ApplicationDbContext db) { _db = db; }

    public string? Username { get; set; }
    public string? FullName { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        // Sign the user out immediately and redirect to login. This page may also support a POST sign-out.
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Account/Login");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Account/Login");
    }
}
