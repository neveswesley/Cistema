using Microsoft.AspNetCore.Identity;

namespace Cistema.Models;

public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool IsRevoked { get; set; }
}