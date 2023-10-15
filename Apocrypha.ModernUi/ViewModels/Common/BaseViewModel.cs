using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Apocrypha.ModernUi.ViewModels.Common;

public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : BaseViewModel;

public class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
{
    protected BaseViewModel()
    {
        ValidateAll();
    }

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion


    #region INotifyDataErrorInfo

    private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
    private bool _validationEnabled = true;

    /// <summary>
    /// if set to true, validates all properties immediately
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

    public IEnumerable GetErrors(string propertyName = null)
    {
        if (propertyName != null)
            return _propertyErrors.TryGetValue(propertyName, out var errors) ? errors.SelectMany(x => x).ToList() : new List<string>();

        return _propertyErrors.SelectMany(e => e.Value).ToList();
    }

    public List<string> GetAllErrors()
    {
        return _propertyErrors.SelectMany(x => x.Value).ToList();
    }

    protected void AddError(string errorMessage, [CallerMemberName] string propertyName = "")
    {
        if (!_propertyErrors.ContainsKey(propertyName))
            _propertyErrors.Add(propertyName, new List<string>());

        _propertyErrors[propertyName].Add(errorMessage);
        OnErrorsChanged(propertyName);
    }

    protected void OnErrorsChanged(string propertyName = null)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    public bool HasErrors => _propertyErrors.Values.Any(l => l.Count > 0);
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    #endregion
}