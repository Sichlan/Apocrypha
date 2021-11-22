using System;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.State.Navigators.Navigators
{
    public interface INavigator : IStateChanger
    {
        BaseViewModel CurrentViewModel { get; set; }
    }
}