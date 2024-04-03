using CommunityToolkit.Mvvm.ComponentModel;
using musicApp_clean.UI.View;
using musicApp_clean.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.UI.Services.Interface
{
    internal interface INavigationService
    {
        ObservableObject CurrentView { get; }
        MusicControlViewModel MusicControlView { get; }
        void NavigateTo<T>() where T : ObservableObject;
    }
}
