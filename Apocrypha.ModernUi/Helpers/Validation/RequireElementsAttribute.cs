using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Apocrypha.ModernUi.Resources.Localization;

namespace Apocrypha.ModernUi.Helpers.Validation;

public class RequireElementsAttribute : ValidationAttribute
{
    private readonly int _count;

    public RequireElementsAttribute(int count = 1)
    {
        _count = count;
    }

    public override bool IsValid(object value)
    {
        if (value is not IEnumerable<object> enumerable)
            return false;

        if (value is IEnumerable<INotifyDataErrorInfo> viewModels)
            return enumerable.Count() >= _count && viewModels.All(x => !x.HasErrors);

        return enumerable.Count() >= _count;
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(Localization.ValidationMessageListMustContainMinimumNumberOfElements, name, _count);
    }
}