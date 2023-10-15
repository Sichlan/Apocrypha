using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Apocrypha.ModernUi.ViewModels.Common;

/// <summary>
/// Generic delegate to register CreateViewModel functions to be used via dependency injection.
/// </summary>
/// <typeparam name="TViewModel"></typeparam>
public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : BaseViewModel;

/// <summary>
/// The baseline of all view models in this project. Implements interfaces needed in all view models. Every other view model must inherit from this.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
{
    /// <summary>
    /// The base constructor.
    /// </summary>
    protected BaseViewModel()
    {
        if (ValidationEnabled)
            ValidateAll();
    }

    #region INotifyPropertyChanged

    /// <inheritdoc />
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// A method to trigger the <see cref="PropertyChanged"/> event. Most of the time called in property setters.
    /// </summary>
    /// <param name="propertyName">
    /// Triggers the <see cref="PropertyChanged"/> event for the given property.
    /// If null and called from a property, automatically takes the calling property's name as parameter.
    /// </param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    #region INotifyDataErrorInfo

    private readonly Dictionary<string, List<string>> _propertyErrors = new();
    private bool _validationEnabled = true;

    /// <summary>
    /// If set to true, validates all properties immediately.
    /// </summary>
    protected bool ValidationEnabled
    {
        get => _validationEnabled;
        set
        {
            _validationEnabled = value;
            if (value)
                ValidateAll();
            else
                ClearAllErrors();
        }
    }

    /// <summary>
    /// Triggers validation for all properties marked for evaluation.
    /// </summary>
    protected void ValidateAll()
    {
        foreach (var errors in _propertyErrors.Values)
        {
            errors.Clear();
        }

        var validationResults = new List<ValidationResult>(1);
        Validator.TryValidateObject(this, new ValidationContext(this, null, null), validationResults, true);

        foreach (var result in validationResults)
        {
            foreach (var propertyName in result.MemberNames)
            {
                if (!_propertyErrors.TryGetValue(propertyName, out List<string> propertyErrors))
                    _propertyErrors.Add(propertyName, propertyErrors = new List<string>());
                propertyErrors.Add(result.ErrorMessage);
                OnErrorsChanged(propertyName);
            }
        }

        OnErrorsChanged();
    }

    /// <summary>
    /// Triggers validation fo a specific property based on the value given.
    /// </summary>
    /// <param name="propertyValue">The value of the property that will be validated.</param>
    /// <param name="propertyName">The name of the property that will be validated.</param>
    protected void Validate(object propertyValue, [CallerMemberName] string propertyName = "")
    {
        if (_propertyErrors.TryGetValue(propertyName, out var error))
            error.Clear();

        var validationResults = new List<ValidationResult>(1);
        Validator.TryValidateProperty(propertyValue, new ValidationContext(this) {MemberName = propertyName}, validationResults);

        foreach (var result in validationResults)
        {
            foreach (var prop in result.MemberNames)
            {
                if (!_propertyErrors.TryGetValue(prop, out List<string> propertyErrors))
                    _propertyErrors.Add(prop, propertyErrors = new List<string>());
                propertyErrors.Add(result.ErrorMessage);
                OnErrorsChanged(prop);
            }
        }

        OnErrorsChanged();
    }

    private void ClearAllErrors()
    {
        var propertyNames = _propertyErrors.Select(e => e.Key).ToList();
        _propertyErrors.Clear();
        propertyNames.ForEach(OnErrorsChanged);
    }

    /// <inheritdoc />
    public IEnumerable GetErrors(string propertyName = null)
    {
        if (propertyName != null)
            return _propertyErrors.TryGetValue(propertyName, out var errors) ? errors.SelectMany(x => x).ToList() : new List<string>();

        return _propertyErrors.SelectMany(e => e.Value).ToList();
    }

    /// <summary>
    /// Returns all errors as a list.
    /// </summary>
    /// <returns>A list of strings.</returns>
    protected List<string> GetAllErrors()
    {
        return _propertyErrors.SelectMany(x => x.Value).ToList();
    }

    /// <summary>
    /// Invokes the <see cref="ErrorsChanged"/> event.
    /// </summary>
    /// <param name="propertyName"></param>
    protected void OnErrorsChanged(string propertyName = null)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    /// <inheritdoc />
    public bool HasErrors => _propertyErrors.Values.Any(l => l.Count > 0);

    /// <inheritdoc />
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    #endregion
}