﻿using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using Microsoft.UI;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using NonsPlayer.Core.Enums;
using NonsPlayer.Core.Nons.Player;
using WinRT.Interop;
using Color = Windows.UI.Color;

namespace NonsPlayer.Converters;

public class ShuffleIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var isShuffle = (bool)value;
        if (isShuffle)
        {
            return Visibility.Visible;
        }

        return Visibility.Collapsed;

    }

    public object? ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return null;
    }
}