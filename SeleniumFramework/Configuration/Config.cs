using Newtonsoft.Json;


namespace Driver.Configuration;

class Config
{//C:\Users\johnn\source\repos\SeleniumFramework\SeleniumFramework\Configuration\Config.cs
  //  private static readonly string CONFIG_FILE_PATH =  /*GetSolutionRootPath() + */ @"C:\Users\johnn\source\repos\SeleniumFramework\SeleniumFramework\Configuration\Config.cs";

    /*
    public static ConfigSettings GetConfigSettings()
    {
       // using (StreamReader file = File.OpenText(CONFIG_FILE_PATH))
     //   {
      //      JsonSerializer serializer = new();
      //      return (ConfigSettings)serializer.Deserialize(file, typeof(ConfigSettings));
     //   }
    }

   */

    public static string GetSolutionRootPath()
    {
        return GetSolutionDirectoryInfo(Directory.GetCurrentDirectory()).FullName;
    }


    private static DirectoryInfo GetSolutionDirectoryInfo(string currentPath = null)
    {
        DirectoryInfo directory = new DirectoryInfo
        (
            currentPath ?? Directory.GetCurrentDirectory()
        );

        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }

        return directory;
    }

}


    
