
namespace Shared;

public class AppConstant
{
    public record General
    {
        public const int DefaultPage = 1;
        public const int DefaultPerPage = 12;
    }

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

    public record Length
    {
        public const int L1 = 64;
        public const int L2 = 256;
        public const int L3 = 512;
        public const int L4 = 2048;
        public const int L5 = 4096;
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

    public record SortOrder
    {
        public const string Asc = "asc";
        public const string Desc = "desc";

        public record By
        {
            public const string Price = "price";
            public const string Date = "date";
            public const string Name = "name";
        }
    }
}
