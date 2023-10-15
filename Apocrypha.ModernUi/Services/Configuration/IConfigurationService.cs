namespace Apocrypha.ModernUi.Services.Configuration;

public interface IConfigurationService
{
    IApocryphaConfiguration ApocryphaConfiguration { get; set; }
    void InitializeConfiguration();
}