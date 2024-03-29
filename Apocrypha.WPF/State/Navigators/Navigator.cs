﻿using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.State.Navigators;

public class Navigator : INavigator
{
    private BaseViewModel _currentViewModel;

    public BaseViewModel CurrentViewModel
    {
        get
        {
            return _currentViewModel;
        }
        set
        {
            _currentViewModel = value;
            StateChange?.Invoke();
        }
    }

    public event Action StateChange;
}