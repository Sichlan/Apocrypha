using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Apocrypha.ModernUi.ViewModels.Navigation;

namespace Apocrypha.ModernUi.Services.State.Navigation;

public class NavigationService : INavigationService
{
    private NavigableViewModel _activeViewModel;
    private Stack<NavigableViewModel> _backHistory = new();
    private Stack<NavigableViewModel> _forwardHistory = new();

    public NavigableViewModel ActiveViewModel
    {
        get
        {
            return _activeViewModel;
        }
        private set
        {
            _activeViewModel = value;
            OnPropertyChanged();
        }
    }

    public bool CanGoBack => _backHistory.Count > 0;
    public bool CanGoForward => _forwardHistory.Count > 0;

    public void Navigate(NavigableViewModel target)
    {
        Navigate(target, false, true);
    }

    private void Navigate(NavigableViewModel target, bool moveBack, bool clearForwardHistory)
    {
        if (clearForwardHistory)
            _forwardHistory.Clear();

        if (ActiveViewModel != null)
            if (moveBack)
                _forwardHistory.Push(ActiveViewModel);
            else
                _backHistory.Push(ActiveViewModel);

        ActiveViewModel = target;

        OnPropertyChanged(nameof(CanGoBack));
        OnPropertyChanged(nameof(CanGoForward));
    }

    public async Task NavigateAsync(NavigableViewModel target)
    {
        await Task.Run(() => Navigate(target));
    }

    private async Task NavigateAsync(NavigableViewModel target, bool moveBack, bool cleanForwardHistory)
    {
        await Task.Run(() => Navigate(target, moveBack, cleanForwardHistory));
    }

    #region Move Back

    public void GoBack()
    {
        if (!CanGoBack)
            throw new Exception($"{nameof(_backHistory)} does not contain any items to go back to!");

        // remove newest item from back history and set it as current item
        Navigate(_backHistory.Pop(), true, false);
    }

    public bool TryGoBack()
    {
        try
        {
            GoBack();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task GoBackAsync()
    {
        if (!CanGoBack)
            throw new Exception($"{nameof(_backHistory)} does not contain any items to go back to!");

        // remove newest item from back history and set it as current item
        await NavigateAsync(_backHistory.Pop(), true, false);
    }

    public async Task<bool> TryGoBackAsync()
    {
        try
        {
            await GoBackAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    #endregion

    #region Move Forward

    public void GoForward()
    {
        if (!CanGoForward)
            throw new Exception($"{nameof(_forwardHistory)} does not contain any items to go forward to!");

        Navigate(_forwardHistory.Pop());
    }

    public bool TryGoForward()
    {
        try
        {
            GoForward();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task GoForwardAsync()
    {
        if (!CanGoForward)
            throw new Exception($"{nameof(_forwardHistory)} does not contain any items to go forward to!");

        await NavigateAsync(_forwardHistory.Pop());
    }

    public async Task<bool> TryGoForwardAsync()
    {
        try
        {
            await GoForwardAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    #endregion

    #region OnPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);

        return true;
    }

    #endregion
}