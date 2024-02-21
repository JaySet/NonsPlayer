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

public class SearchDataTypeToString : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var item = value as SearchDataType?;
        switch (item)
        {
            case SearchDataType.Music:
                return "单曲";
            case SearchDataType.Artist:
                return "艺术家";
            case SearchDataType.Playlist:
                return "歌单";
            case SearchDataType.Album:
                return "专辑";
            default:
                return "未知";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return "未知";
    }
}