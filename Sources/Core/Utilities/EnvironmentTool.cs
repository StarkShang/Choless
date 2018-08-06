using System;

namespace Choless.Core.Tools
{
    public enum Environments
    {
        Development,
        Test,
        Release
    }
    
    public static class EnvironmentTool
    {
        private const string EnvironmentVariable = "ASPNETCORE_ENVIRONMENT";

        public static Environments CurrentEnvironment { get {
            return (Environments)Enum.Parse(typeof(Environments), Environment.GetEnvironmentVariable(EnvironmentVariable));
        }}

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
