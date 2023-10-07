using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Microsoft.Xaml.Behaviors;

namespace Apocrypha.ModernUi.Helpers.Behaviours;

public class ProgressBarAnimationBehaviour : Behavior<ProgressBar>
{
    private bool _isAnimating = false;

    public double AnimationDuration { get; set; }

    protected override void OnAttached()
    {
        base.OnAttached();
        ProgressBar progressBar = this.AssociatedObject;
        progressBar.ValueChanged += ProgressBarOnValueChanged;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        ProgressBar progressBar = this.AssociatedObject;
        progressBar.ValueChanged -= ProgressBarOnValueChanged;
    }

    private void ProgressBarOnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (_isAnimating || sender is not ProgressBar bar)
            return;

        _isAnimating = true;

        DoubleAnimation doubleAnimation =
            new DoubleAnimation(e.OldValue, e.NewValue, new Duration(TimeSpan.FromMilliseconds(AnimationDuration)), FillBehavior.Stop);
        doubleAnimation.Completed += DoubleAnimationOnCompleted;

        bar.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation);
        e.Handled = true;
    }

    private void DoubleAnimationOnCompleted(object sender, EventArgs e)
    {
        _isAnimating = false;
    }
}