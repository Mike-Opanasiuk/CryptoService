
namespace Shared;

public class AppConstant
{
    public record Claims
    {
        public const string Id = "id";
        public const string Roles = "roles";
    }

    public record Roles
    {
        public const string User = "User";
        public const string Admin = "Admin";
    }

    /// <summary>
    /// jwt token lifetimes
    /// </summary>
    public record JwtTokenLifetimes
    {
        /// <summary>
        /// 12 hours
        /// </summary>
        public static readonly TimeSpan Default = TimeSpan.FromHours(12);
        /// <summary>
        /// 7 days
        /// </summary>
        public static readonly TimeSpan Longer = TimeSpan.FromDays(7);
    }
}
