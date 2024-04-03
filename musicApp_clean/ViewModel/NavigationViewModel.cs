using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using musicApp_clean.UI.Services.Interface;


namespace musicApp_clean.UI.ViewModel
{
    internal class NavigationViewModel : ObservableObject
    {
        INavigationService navigationService;
        
        public INavigationService NavigationService
        {
            get => navigationService;
            set => SetProperty(ref navigationService, value);
        }
        
        public ICommand NavigateMusicsCommand { get; }
        public ICommand NavigateHomeCommand { get; }
        
        public NavigationViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            
            NavigateMusicsCommand = new RelayCommand(NavigationService.NavigateTo<MusicsViewModel>);
            NavigateHomeCommand = new RelayCommand(NavigationService.NavigateTo<HomeViewModel>);
        }        
    }
}
