using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Apocrypha.ModernUi.Themes.CustomControls;

public static class MapResourceFetcher
{
    public static SolidColorBrush MapLandFillBrush => FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapWaterFillBrush => FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapSeaRoutesBrush => FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapRoutesBrush => FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapTrailsBrush => FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapMarkerBrush => FetchResource<SolidColorBrush>();

    private static T FetchResource<T>([CallerMemberName] string resourceName = "") where T : class
    {
        try
        {
            object resource = Application.Current.FindResource(resourceName);

            return resource as T;
        }
        catch (ResourceReferenceKeyNotFoundException e)
        {
            Console.WriteLine(e);
        }
        catch (Exception e)
        {
        }

        return default;
    }
}