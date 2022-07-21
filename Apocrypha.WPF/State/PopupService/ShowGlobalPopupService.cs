using Apocrypha.WPF.ViewModels.Popup;

namespace Apocrypha.WPF.State.PopupService;

public class ShowGlobalPopupService : IShowGlobalPopupService
{
    #region Fields

    private IPopupViewModel _popupViewModel;
    private bool _isVisible;
    public event Action StateChange;

    #endregion

    #region Properties

    /// <inheritdoc/>
    public bool IsVisible
    {
        get
        {
            return _isVisible;
        }
        set
        {
            _isVisible = value;
            StateChange?.Invoke();
        }
    }

    /// <inheritdoc/>
    public IPopupViewModel PopupViewModel
    {
        get
        {
            return _popupViewModel;
        }
        set
        {
            _popupViewModel = value;
            StateChange?.Invoke();
        }
    }

    #endregion

    /// <inheritdoc/>
    public Task ShowPopup(IPopupViewModel popupViewModel)
    {
        PopupViewModel = popupViewModel;
        IsVisible = true;

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task ClosePopup()
    {
        IsVisible = false;
        PopupViewModel = null;

        return Task.CompletedTask;
    }
}