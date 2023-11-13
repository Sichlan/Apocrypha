using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Apocrypha.ModernUi.Themes.CustomControls;

public static class MapResourceFetcher
{
    private static SolidColorBrush _mapLandHeightMapBrush1;
    private static SolidColorBrush _mapLandHeightMapBrush2;
    private static SolidColorBrush _mapLandHeightMapBrush3;
    private static SolidColorBrush _mapLandHeightMapBrush4;
    private static SolidColorBrush _mapLandHeightMapBrush5;
    private static SolidColorBrush _mapLandHeightMapBrush6;
    private static SolidColorBrush _mapLandHeightMapBrush7;
    private static SolidColorBrush _mapLandHeightMapBrush8;
    private static SolidColorBrush _mapLandHeightMapBrush9;
    private static SolidColorBrush _mapLandHeightMapBrush10;
    private static SolidColorBrush _mapLandHeightMapBrush11;
    private static SolidColorBrush _mapLandHeightMapBrush12;
    private static SolidColorBrush _mapLandHeightMapBrush13;
    private static SolidColorBrush _mapLandHeightMapBrush14;
    private static SolidColorBrush _mapWaterFillBrush;
    private static SolidColorBrush _mapSeaRoutesBrush;
    private static SolidColorBrush _mapRoutesBrush;
    private static SolidColorBrush _mapTrailsBrush;
    private static SolidColorBrush _mapMarkerBrush;
    private static SolidColorBrush _mapSettlementBrush;

    public static SolidColorBrush MapLandHeightMapBrush1 => _mapLandHeightMapBrush1 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush2 => _mapLandHeightMapBrush2 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush3 => _mapLandHeightMapBrush3 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush4 => _mapLandHeightMapBrush4 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush5 => _mapLandHeightMapBrush5 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush6 => _mapLandHeightMapBrush6 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush7 => _mapLandHeightMapBrush7 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush8 => _mapLandHeightMapBrush8 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush9 => _mapLandHeightMapBrush9 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush10 => _mapLandHeightMapBrush10 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush11 => _mapLandHeightMapBrush11 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush12 => _mapLandHeightMapBrush12 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush13 => _mapLandHeightMapBrush13 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapLandHeightMapBrush14 => _mapLandHeightMapBrush14 ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapWaterFillBrush => _mapWaterFillBrush ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapSeaRoutesBrush => _mapSeaRoutesBrush ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapRoutesBrush => _mapRoutesBrush ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapTrailsBrush => _mapTrailsBrush ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapMarkerBrush => _mapMarkerBrush ??= FetchResource<SolidColorBrush>();
    public static SolidColorBrush MapSettlementBrush => _mapSettlementBrush ??= FetchResource<SolidColorBrush>();

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