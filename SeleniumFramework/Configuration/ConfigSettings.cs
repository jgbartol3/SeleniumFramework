

namespace Driver.Configuration;

public class ConfigSettings
{
    public int StaleElementTimeOutIntervalMS { get; set; }
    public int StaleElementTimeOutRetries { get; set; }
    public int FileDownloadWaitIntervalMS { get; set; }
    public int FileDownloadWaitRetries { get; set; }
    public int DriverTimeOutMS { get; set; }
    public int ExplicitWaitPollingIntervalMS { get; set; }
    public string DriverExecutablesFilePath { get; set; }
    public bool ChromeAcceptInsecureCerts { get; set; }
    public string ScreenShotPath { get; set; }
    public string ScreenShotSuffix { get; set; }
    public int StaleElementWaitMS { get; set; }
    public string ExceptionLogPath { get; set; }
    public string FileDownloadPath { get; set; }
    public string DriverDbConnectionString { get; set; }
    public string FullFileDownloadPath
    {
        get => Path.Combine
        (
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            FileDownloadPath
        );
    }

}
