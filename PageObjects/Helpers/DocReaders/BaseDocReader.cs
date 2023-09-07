using System.IO.Compression;


namespace PageObjects.PageHelpers.DocReaders;

public abstract class BaseDocReader
{

    private int

        COUNTER = 10,
        SLEEP = 3000;

    private string

        FILEPATH = @"";

    protected void DeleteFile(string documentTitle)
    {
        File.Delete(GetFullFilePath(documentTitle));
    }

    protected void WaitForFile(string fileName)
    {
        do
        {
            Thread.Sleep(SLEEP);

            if (COUNTER.Equals(0))
            {
                throw new TimeoutException(FileNotExistsExceptionMessage(fileName));
            }

            COUNTER--;

        } while (!IsFileReady());

        bool IsFileReady()
        {
            try
            {
                using (FileStream inputStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return inputStream.Length > 0;
                }
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }
    }

    private string FileNotExistsExceptionMessage(string fileName)
    {
        return $"Couldn't Find File: { fileName } After { SLEEP * COUNTER } Milleseconds";
    }

    private string GetFullFilePath(string documentTitle)
    {
        return FILEPATH + documentTitle;
    }

    protected string SetFullFilePathAndWait(string documentTitle)
    {
        string fullPath = GetFullFilePath(documentTitle);

        WaitForFile(fullPath);

        return fullPath;
    }

    public bool IsFileDownloaded(string documentTitle)
    {
        SetFullFilePathAndWait(documentTitle);

        DeleteFile(documentTitle);

        return true;
    }

    public void UnZipFolder(string zipPath)
    {
        string fullPath = SetFullFilePathAndWait(zipPath);

        ZipFile.ExtractToDirectory(fullPath + ".zip", fullPath);
    }


}