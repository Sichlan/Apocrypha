using System;
using System.ComponentModel.DataAnnotations;
using Apocrypha.ModernUi.Resources.Localization;

namespace Apocrypha.ModernUi.Helpers.Validation;

public class GreaterThanAttribute : ValidationAttribute
{
    private readonly decimal _minimum;
    private readonly bool _minimumAllowed;

    public GreaterThanAttribute(double minimum, bool minimumAllowed = false)
    {
        _minimum = (decimal)minimum;
        _minimumAllowed = minimumAllowed;
    }

    public override bool IsValid(object value)
    {
        if (value == null) return false;

        if (_minimumAllowed)
            return Convert.ToDecimal(value) >= _minimum;

        return Convert.ToDecimal(value) > _minimum;
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(_minimumAllowed ? Localization.ValidationValueMustBeGraterThanOrEqual : Localization.ValidationValueMustBeGraterThan, name,
            _minimum);
    }
}