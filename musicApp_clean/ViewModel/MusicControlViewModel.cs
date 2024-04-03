using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using musicApp_clean.UI.Services.Implementation;
using musicApp_clean.UI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace musicApp_clean.UI.ViewModel
{
    partial class MusicControlViewModel : ObservableObject
    {
        IMusicService musicService;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangePosCommand))]
        MouseEventArgs e;

        public IMusicService MusicService
        {
            get => musicService;
            set => SetProperty(ref musicService, value);
        }

        public ICommand ContinueCommand { get; }
        public ICommand PrevCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand ChangeVolumeCommand { get; }

        public MusicControlViewModel(IMusicService musicService) 
        {
            MusicService = musicService;

            ContinueCommand = new RelayCommand(PlayPause);
            PrevCommand = new RelayCommand(MusicService.Previous);
            NextCommand = new RelayCommand(MusicService.Next);
            ChangeVolumeCommand = new RelayCommand(MusicService.ChangeVolume);
        }

        void PlayPause()
        {
            switch (MusicService.IsPlaying())
            {
                case NAudio.Wave.PlaybackState.Playing:
                    MusicService.Pause(); break;
                case NAudio.Wave.PlaybackState.Paused:
                    MusicService.Continue(); break;
                case NAudio.Wave.PlaybackState.Stopped:
                    MusicService.Play(); break;
            }
        }

        [RelayCommand]
        void ChangePos(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MusicService.ChangePosition();
            }
        }
    }
}
