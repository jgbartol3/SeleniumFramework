

namespace PageObjects.PageModels;

public class Video
{
    public string? Url { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Channel { get; set; }
    public ulong Views { get; set; }
    public string? FilePath { get; set; }
    public bool IsMadeForKids { get; set; }
    public bool IsAgeRestricted { get; set; }
    public List<string>? Tags { get; set; }

}

