using ModernWpf;

namespace Apocrypha.CommonObject.Services.Configuration;

public interface IDesignConfiguration
{
    string ColorPreset { get; set; }
    ApplicationTheme? ApplicationTheme { get; set; }
}