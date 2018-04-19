using System;

namespace Choless.Core.Tools
{
    public static class EnvironmentTool
    {
        public static bool IsTestEnvironment
        {
            get
            {
                return Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT") == "Test";
            }
        }

        public static bool IsDevelopmentEnvironment
        {
            get
            {
                return Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT") == "Development";
            }
        }

        public static bool IsReleassEnvironment
        {
            get
            {
                return Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT") == "Release";
            }
        }

        public static void SetEnviroment(string environmentName)
        {
            Environment.SetEnvironmentVariable("DOTNETCORE_ENVIRONMENT", environmentName);
        }
    }
}
