using ModernWpf;

namespace Apocrypha.ModernUi.Services.Configuration;

public interface IDesignConfiguration
{
    string ColorPreset { get; set; }
    ApplicationTheme? ApplicationTheme { get; set; }
}