using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace AvaloniaApplication1.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int _width;

        [ObservableProperty]
        private int _height;

        [ObservableProperty]
        private Stretch _stretch;

        public ObservableCollection<Stretch> EnumStrechs { get; } = new();

        public MainWindowViewModel()
        {
            foreach (var item in Enum.GetValues<Stretch>())
            {
                EnumStrechs.Add(item);
            }
        }
    }
}
