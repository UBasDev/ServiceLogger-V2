namespace ServiceLogger
{
    internal static class Configuration
    {
        static private ConfigurationManager ConfigurationManager
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Directory.GetCurrentDirectory());
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager;
            }
        }
        static public string ConnectionString
        {
            get
            {                
                return ConfigurationManager.GetConnectionString("SqlServer");
            }
        }
        static public string ApiUrl
        {
            get
            {                
                return ConfigurationManager.GetSection("ApiUrl").Value;
            }
        }
        static public string HotmailHost
        {
            get
            {                
                return ConfigurationManager.GetSection("HotmailHost").Value;
            }
        }
        static public string HotmailPort
        {
            get
            {
                return ConfigurationManager.GetSection("HotmailPort").Value;
            }
        }
        static public string EmailUsername
        {
            get
            {
                return ConfigurationManager.GetSection("EmailUsername").Value;
            }
        }
        static public string EmailPassword
        {
            get
            {
                return ConfigurationManager.GetSection("EmailPassword").Value;
            }
        }
        static public string EmailUsernameToSend
        {
            get
            {
                return ConfigurationManager.GetSection("EmailUsernameToSend").Value;
            }
        }
    }
}
