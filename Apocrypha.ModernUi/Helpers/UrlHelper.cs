using System.Diagnostics;
using System.Runtime.InteropServices;

// ReSharper disable RedundantIfElseBlock

namespace Apocrypha.ModernUi.Helpers;

public static class UrlHelper
{
    public static Process OpenUrl(string url)
    {
        try
        {
            return Process.Start(url);
        }
        catch
        {
            // hack because of this: https://github.com/dotnet/corefx/issues/10361
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");

                return Process.Start(new ProcessStartInfo(url) {UseShellExecute = true});
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Process.Start("open", url);
            }
            else
            {
                throw;
            }
        }
    }
}