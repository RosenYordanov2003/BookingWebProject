namespace BookingWebProject.Extensions
{
    using System.Security.Claims;
    public static class CalimsPrincipalExtension
    {
        public static Guid GetId(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public static string GetProfilePicturePath(this ClaimsPrincipal user)
        {
            Claim claim = user.Claims.FirstOrDefault(c => c.Type == "ProfilePicturePath");
            return claim?.Value ?? "";
        }
    }
}
