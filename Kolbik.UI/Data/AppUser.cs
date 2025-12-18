using Microsoft.AspNetCore.Identity;

namespace Kolbik.UI.Data;

public class AppUser: IdentityUser
{
    public byte[]? Avatar { get; set; }
    public string MimeType { get; set; } = string.Empty;
}
