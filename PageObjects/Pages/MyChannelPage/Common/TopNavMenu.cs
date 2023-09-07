





namespace PageObjects.Pages;

class TopNavMenu : Page
{
    #region Selectors

    public const string USERNAME = @"ezrawoods754@gmail.com",

                        PASSWORD = @"";

    public string

           SearchTextBox = "input[id='search']",

           SearchButton = "button[id='search-icon-legacy']",

           NextButton = "//button[normalize-space()='Next']",

           EmailTextBox = "[type='email']",

           PasswordTextBox = "[type='password']",

           SignInButton = "a[aria-label='Sign in']",

           CameraIcon = "[aria-label='Create']",

           UploadVideoIcon = "#primary-text-container",

           SelectFilesButton = "#select-files-button",

           FileUpload = "[name='Filedata']",

           TitleTextBox = "[aria-label*='title']",

           DescriptionTextBox = "[aria-label*='Tell']",

           MadeForKidsRadio = "offRadio",

           NotMadeForKidsRadio = "onRadio";






    #endregion


    #region Methods



    public void SignIn(string username, string password)
    {
        Click(SignInButton);

        SetText(EmailTextBox, username);

        Click(NextButton);

        SetText(PasswordTextBox, password);

        Click(NextButton);
    }

    public void CreateVideo(Video video)
    {
        Click(CameraIcon);

        Click(UploadVideoIcon);

        // Click(SelectFilesButton);

        SetFileUpload(FileUpload, video.FilePath);

        SetText(TitleTextBox, video.Title);

        SetText(DescriptionTextBox, video.Description);

        Click(video.IsMadeForKids ? MadeForKidsRadio : NotMadeForKidsRadio);

        Click(video.IsAgeRestricted ? radio


    }



    #endregion

}
