using Apocrypha.WPF.ViewModels.Popup;

namespace Apocrypha.WPF.State.PopupService;

public interface IShowGlobalPopupService : IStateChanger
{
    public bool IsVisible { get; set; }
    public IPopupViewModel PopupViewModel { get; set; }

    /// <summary>
    /// Shows a popup containing a view model that implements <see cref="IPopupViewModel"/>.
    /// </summary>
    /// <param name="popupViewModel">The view model that should be displayed</param>
    public Task ShowPopup(IPopupViewModel popupViewModel);

    /// <summary>
    /// Closes the popup.
    /// </summary>
    public Task ClosePopup();
}