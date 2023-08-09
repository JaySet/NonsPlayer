using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;
using NonsPlayer.Components.ViewModels;
using NonsPlayer.Core.Adapters;
using NonsPlayer.Core.Models;
using NonsPlayer.Helpers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NonsPlayer.Components.Views;

[INotifyPropertyChanged]
public sealed partial class BestArtistCard : UserControl
{
    public BestArtistCardViewModel ViewModel { get; }

    public BestArtistCard()
    {
        ViewModel = App.GetService<BestArtistCardViewModel>();
        SearchHelper.Instance.BestMusicResultChanged += OnBestMusicResultChanged;

        InitializeComponent();
    }

    [ObservableProperty] private ImageSource cover;
    [ObservableProperty] private long? id;
    [ObservableProperty] private string name;

    partial void OnCoverChanged(ImageSource value)
    {
        BeginAnimation();
        AvatarAnimation.Completed += (sender, o) =>
        {
            BeginAnimation();
        };
    }

    private async void BeginAnimation()
    {
        AvatarAnimation.Children[0].SetValue(DoubleAnimation.FromProperty, AvatarTransform.Y);
        AvatarAnimation.Children[0].SetValue(DoubleAnimation.ToProperty, AvatarTransform.Y <= -300 ? 0 : -300);
        AvatarAnimation.Begin();
    }
    private async void OnBestMusicResultChanged(Music value)
    {
        Id = value.Artists[0].Id;
        Name = value.Artists[0].Name;
        value.Artists[0] = await ArtistAdapters.CreateById(value.Artists[0].Id);
        var coverTemp = await CacheHelper.GetImageBrushAsync(value.Artists[0].CacheMiddleAvatarId,
            value.Artists[0].MiddleAvatarUrl);
        Avater.DispatcherQueue.TryEnqueue(() => { Cover = coverTemp.ImageSource; });
    }
}