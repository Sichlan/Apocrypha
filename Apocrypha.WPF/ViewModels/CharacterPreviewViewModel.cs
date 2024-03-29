﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.ViewModels;

public class CharacterPreviewViewModel : BaseViewModel
{
    private readonly Character _character;

    public CharacterPreviewViewModel(Random random, Character character, ICharacterStore characterStore,
        IRenavigator renavigator)
    {
        _character = character;
        SetCurrentCharacterCommand = new SetCurrentCharacterCommand(_character, characterStore, renavigator);

        var colorInt = random.Next(0, 72);
        LeftColor ??= GetColorFromStandardColorsByInt(colorInt);
        RightColor ??= GetComplementaryColor(LeftColor.Value);
    }

    public string CharacterName
    {
        get
        {
            return string.IsNullOrWhiteSpace(_character.DisplayName) ? _character.CharacterName : _character.DisplayName;
        }
    }

    public string PreviewInfo
    {
        get
        {
            return "Human SaBa 1 / Ar 4 / Ur 2 / PsTh 3 / SuCh 1 / MyTh 3 / PsTh 1 / Cere 5";
        }
    }

    public Color? LeftColor { get; set; }
    public Color? RightColor { get; set; }

    public LinearGradientBrush Background
    {
        get
        {
            var output = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 2)
            };
            output.GradientStops.Add(new GradientStop(LeftColor.Value, 0));
            output.GradientStops.Add(new GradientStop(RightColor ?? GetComplementaryColor(LeftColor.Value), 0.75));

            return output;
        }
    }

    public ICommand SetCurrentCharacterCommand { get; set; }

    /// <summary>
    ///     Gets the complementary color to a given colour.
    ///     <a href="https://www.quora.com/Whats-the-algorithm-for-obtaining-a-hexadecimal-colors-opposite-in-the-color-wheel">Source for this algorithm</a>
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private Color GetComplementaryColor(Color color)
    {
        byte r = (byte)((color.R + 180) % 360),
            g = (byte)((color.G + 180) % 360),
            b = (byte)((color.B + 180) % 360);

        return Color.FromArgb(255, r, g, b);
    }

    private Color GetColorFromStandardColorsByInt(int colorInt)
    {
        var type = typeof(Brushes);
        var colors = type.GetProperties();
        var brushConverter = new BrushConverter();

        return (Color)ColorConverter.ConvertFromString((brushConverter.ConvertFromString(colors[colorInt].Name) as Brush)?.ToString())!;
    }
}