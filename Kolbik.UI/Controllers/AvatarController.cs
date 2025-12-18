using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Kolbik.UI.Data;

namespace Kolbik.UI.Controllers
{
    public class AvatarController : Controller
    {
        UserManager<AppUser> _userManager;
        IWebHostEnvironment _env;
        public AvatarController(UserManager<AppUser>
       userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Avatar.Length > 0)
                return File(user.Avatar, "image/...");
            else
            {
                var avatarPath = "/Images/anonava.jpg";

                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)
               .CreateReadStream(), "image/...");
            }
        }
    }
}
