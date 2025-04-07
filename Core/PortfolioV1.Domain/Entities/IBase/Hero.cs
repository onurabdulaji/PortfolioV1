namespace PortfolioV1.Domain.Entities.IBase;

public class Hero : BaseEntity
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImageUrl { get; set; }
    public Hero() { }
    public Hero(string? title, string? subTitle, string? backgroundImageUrl)
    {
        Title = title;
        SubTitle = subTitle;
        BackgroundImageUrl = backgroundImageUrl;
    }
}
