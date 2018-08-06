
using System.Configuration;

namespace Choless.Server.Commons
{
    public static class Configuration
    {
        public static string DatabaseName { get; set; }
        public static int PageSize { get; set; }
        public static string HostAddress { get; set; }
        public static DatabaseConfiguration Database { get; set; }
        static Configuration()
        {
        }
    }
}