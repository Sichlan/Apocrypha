using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Apocrypha.ModernUi.Themes.Presets;

public class PresetManager : INotifyPropertyChanged
{
    internal const string DefaultPreset = "Default";

    private string _colorPreset = DefaultPreset;
    private string _shapePreset = DefaultPreset;

    private PresetManager()
    {
    }

    public static PresetManager Current { get; } = new PresetManager();

    public string ColorPreset
    {
        get => _colorPreset;
        set
        {
            if (_colorPreset != value)
            {
                _colorPreset = value;
                OnPropertyChanged();
                ColorPresetChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public string ShapePreset
    {
        get => _shapePreset;
        set
        {
            if (_shapePreset != value)
            {
                _shapePreset = value;
                OnPropertyChanged();
                ShapePresetChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public event EventHandler ColorPresetChanged;
    public event EventHandler ShapePresetChanged;
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
}