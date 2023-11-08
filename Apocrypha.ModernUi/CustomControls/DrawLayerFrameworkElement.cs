using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Apocrypha.CommonObject.Models.Simulation.Layers;
using Apocrypha.ModernUi.Services.UserInformationService;
using Mars.Interfaces.Layers;

namespace Apocrypha.ModernUi.CustomControls;

public abstract class DrawLayerFrameworkElement : AbstractVisualCollectionRenderer
{
    internal readonly double OuterXMin;
    internal readonly double OuterXMax;
    internal readonly double OuterYMin;
    internal readonly double OuterYMax;
    internal readonly Func<IVectorFeature, bool> VectorSkipPredicate;
    internal readonly Func<IVectorFeature, Brush> VectorFillColourPredicate;
    internal readonly Func<IVectorFeature, Pen> VectorPenPredicate;

    private readonly IUserInformationMessageService _userInformationMessageService;

    public DrawLayerFrameworkElement(double outerXMin, double outerXMax, double outerYMin, double outerYMax, Func<IVectorFeature, bool> vectorSkipPredicate,
        Func<IVectorFeature, Brush> vectorFillColourPredicate, Func<IVectorFeature, Pen> vectorPenPredicate,
        IUserInformationMessageService userInformationMessageService)
        : this(vectorSkipPredicate, vectorFillColourPredicate, vectorPenPredicate, userInformationMessageService)
    {
        OuterXMin = outerXMin;
        OuterXMax = outerXMax;
        OuterYMin = outerYMin;
        OuterYMax = outerYMax;
    }

    public DrawLayerFrameworkElement(Func<IVectorFeature, bool> vectorSkipPredicate, Func<IVectorFeature, Brush> vectorFillColourPredicate,
        Func<IVectorFeature, Pen> vectorPenPredicate, IUserInformationMessageService userInformationMessageService)
    {
        VectorSkipPredicate = vectorSkipPredicate;
        VectorFillColourPredicate = vectorFillColourPredicate;
        VectorPenPredicate = vectorPenPredicate;
        _userInformationMessageService = userInformationMessageService;

        MouseUp += OnMouseUp;
        MouseWheel += OnMouseWheel;
        Loaded += OnLoaded;
    }

    protected async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await RenderGisLayerAsync();
    }

    protected void OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
    }

    protected void OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (sender is UIElement element)
        {
            var point = e.GetPosition(element);
            VisualTreeHelper.HitTest(this, null, HitTestResultCallback, new PointHitTestParameters(point));
        }
    }

    protected HitTestResultBehavior HitTestResultCallback(HitTestResult result)
    {
        // TODO: Add useful content in here
        if (result is PointHitTestResult
            {
                VisualHit: VectorFeatureDrawingVisual
                {
                    Parent: DrawVectorLayerFrameworkElement<GisRoutesLayer>
                } vectorFeatureDrawingVisual
            } pointHit)
        {
            _userInformationMessageService.AddDisplayMessage("Vectore Feature:", InformationType.Information,
                messageDetails: $"vectorFeatureDrawingVisual: {vectorFeatureDrawingVisual}");

            // using (var visualContext = vectorFeatureDrawingVisual.RenderOpen())
            // {
            //     var text = "lol";
            //     var formattedText = new FormattedText(text,
            //         CultureInfo.InvariantCulture,
            //         FlowDirection.LeftToRight,
            //         new Typeface("ComicSans"),
            //         20,
            //         Brushes.Black, 
            //         1); 
            //     visualContext.DrawText(formattedText, pointHit.PointHit);
            // }
        }

        return HitTestResultBehavior.Stop;
    }

    protected abstract Task RenderGisLayerAsync();

    /// <inheritdoc />
    protected override Visual GetVisualChild(int index)
    {
        if (index < 0 || index >= _visualCollection.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return _visualCollection[index];
    }

    protected override int VisualChildrenCount =>
        _visualCollection.Count;
}