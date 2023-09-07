using PageObjects.PageHelpers.DocReaders;
using PageObjects.PageHelpers;
using OpenQA.Selenium;
using Driver.Helpers;

namespace PageObjects.Pages;


class Page : Commands
{
    protected PdfDocReader PdfDocReader = new();

    protected CsvDocReader CsvDocReader = new();

    protected Links Links = new();

    public string GetTextFromTextBox(string by)
    {
        return GetHtmlAttribute(by, "value").Trim();
    }

    public void ClickCheckBox(string by, bool toCheck)
    {
        string att = GetHtmlAttribute(by, "checked");

        if (att == null && toCheck || att != null && !toCheck)
        {
            Click(by);
        }
    }

    public bool IsCheckBoxChecked(string by)
    {
        return GetHtmlAttribute(by, "checked") != null;
    }

    public List<T> GetCheckBoxes<T>(List<T> checkboxes)
    {
        List<T> checkBoxesThatAreChecked = new();

        if (checkboxes != null)
        {
            foreach (T checkbox in checkboxes)
            {
                if (GetHtmlAttribute($"input[type='checkbox'][value='{checkbox}'], " +
                    $"input[type='checkbox'][title='{checkbox}']", "checked") != null)
                {
                    checkBoxesThatAreChecked.Add(checkbox);
                }
            }
        }

        return checkBoxesThatAreChecked;
    }

 

    public void FillOutForm<T>(object obj) where T : new()
    {
        T page = new();

        Type fieldsType = page.GetType();

        FieldInfo[] fields = fieldsType.GetFields
        (
            BindingFlags.Public |
            BindingFlags.Instance
        );
        
        for (int i = 0; i < fields.Length; i++)
        {
            string name = fields[i].Name.ToLower(),
                   selector = fields[i].GetValue(name).ToString();

            if (name.Contains("textbox"))
            {
                string? text = GetType().GetProperties().Where(x => x.Name.Contains(name))
                                             .Select(x => x.GetValue(obj))
                                             .FirstOrDefault().ToString();

                SetText(fields[i].GetValue(name).ToString(), text);
            }
            else if (name.Contains("radio") || name.Contains("checkbox"))
            {
           //     Click()
            }
            else
            {

            }
        }
    }
}






