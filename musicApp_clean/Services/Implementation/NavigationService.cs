using CommunityToolkit.Mvvm.ComponentModel;
using musicApp_clean.UI.Services.Interface;
using musicApp_clean.UI.View;
using musicApp_clean.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.UI.Services.Implementation
{
    internal class NavigationService : ObservableObject, INavigationService
    {
        ObservableObject _currentView;
        MusicControlViewModel _musicControlView;
        readonly Func<Type, ObservableObject> _viewModelFactory;

        public ObservableObject CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public MusicControlViewModel MusicControlView
        {
            get => _musicControlView;
            set => SetProperty(ref _musicControlView, value);
        }

        public NavigationService(Func<Type, ObservableObject> viewModelFactory, MusicControlViewModel musicControlView)
        {
            _viewModelFactory = viewModelFactory;
            MusicControlView = musicControlView;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
        {
            ObservableObject viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
