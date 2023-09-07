using PageObjects.PageModels;



namespace PageObjects.Pages;

class HomePage : Page
{

    private const string 
        
        PREFIX = "#dismissible ";

    public string

        VideoTitleLabel = $"{ PREFIX }#video-title",

        VideoChannelLabel = $"{PREFIX }#channel-name";


  

}
