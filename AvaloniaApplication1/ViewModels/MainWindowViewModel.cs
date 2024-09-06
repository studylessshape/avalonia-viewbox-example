using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace AvaloniaApplication1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int _width = 50;

        [ObservableProperty]
        private int _height = 50;

        [ObservableProperty]
        private Stretch _stretch = Stretch.Uniform;

        [ObservableProperty]
        private StretchDirection _stretchDirection = StretchDirection.Both;
    }
}
