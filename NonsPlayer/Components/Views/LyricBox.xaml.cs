using Microsoft.UI.Xaml.Controls;
using NonsPlayer.Components.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NonsPlayer.Components.Views;

public sealed partial class LyricBox : UserControl
{
    public LyricBoxViewModel ViewModel
    {
        get;
    }

    public LyricBox()
    {
        ViewModel = App.GetService<LyricBoxViewModel>();
        InitializeComponent();
        ViewModel.Init();
        DropShadow.Receivers.Add(Body);
    }
}