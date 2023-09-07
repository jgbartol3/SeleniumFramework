
using Driver;
using Pages.Objects;

namespace Pages;

public class BasePage : DriverCommands
{
    protected string

        UserNameTextBox = "//****][",

        PasswordTextBox = "//****][",

        LogInButton = "";


    public void SetLogIn(User user)
    {
        SetText(UserNameTextBox, user.UserName);

        SetText(PasswordTextBox, user.Password);

        Click(LogInButton);
    }

}
