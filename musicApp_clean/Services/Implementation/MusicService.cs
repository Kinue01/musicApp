using musicApp_clean.Domain.Model;
using musicApp_clean.UI.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using NAudio.Wave;
using musicApp_clean.Domain.UseCase;
using musicApp_clean.Data.Implementations;
using musicApp_clean.Infrastructure.EntityFramework.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Timers;
using musicApp_clean.Infrastructure.EntityFramework.Model;
using NAudio.Utils;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace musicApp_clean.UI.Services.Implementation
{
    class MusicService : ObservableObject, IMusicService
    {
        readonly string baseUrl = "http://192.168.0.107/";

        Music currMusic;
        Music musicToPlay;
        List<Music> musics;

        MediaFoundationReader media;
        WasapiOut wasapiOut;

        GetMusicsUseCase getMusicsUseCase;

        System.Timers.Timer timer;
        TimeSpan currTime, totalTime;
        double currDoubleTime, totalDoubleTime;
        float currVolume;
        
        public Music CurrentMusic
        {
            get => currMusic;
            set 
            { 
                SetProperty(ref currMusic, value);
                SetMusic(currMusic);
            }
        }
        public Music MusicToPlay
        {
            get => musicToPlay;
            set => SetProperty(ref musicToPlay, value);
        }
        public List<Music> MusicList 
        { 
            get => musics;
            set => SetProperty(ref musics, value);
        }
        public TimeSpan CurrentTime 
        { 
            get => currTime; 
            set => SetProperty(ref currTime, value);
        }
        public TimeSpan TotalTime
        {
            get => totalTime;
            set => SetProperty(ref totalTime, value);
        }
        public double CurrentDoubleTime
        {
            get => currDoubleTime;
            set => SetProperty(ref currDoubleTime, value);
        }
        public double TotalDoubleTime
        {
            get => totalDoubleTime;
            set => SetProperty(ref totalDoubleTime, value);
        }
        public float CurrentVolume
        {
            get => currVolume;
            set => SetProperty(ref currVolume, value);
        }

        public MusicService(IDbContextFactory<MusicsDbContext> dbContextFactory)
        {
            wasapiOut = new WasapiOut();

            CurrentTime = TimeSpan.Zero;
            timer = new System.Timers.Timer();

            getMusicsUseCase = new GetMusicsUseCase(new MusicRepositoryImpl(new MusicEFDataSourceImpl(dbContextFactory)));
            GetMusics();
        }

        private void WasapiOut_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (wasapiOut.PlaybackState == PlaybackState.Stopped)
            {
                timer.Stop();
                Next();
            }
        }

        public void Pause()
        {
            timer?.Stop();
            wasapiOut.Pause();
        }

        public void Play()
        {
            media = new MediaFoundationReader(baseUrl + MusicToPlay.Url);
            wasapiOut = new WasapiOut();
            wasapiOut.PlaybackStopped += WasapiOut_PlaybackStopped;
            wasapiOut.Init(media);

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Tick;
            ConfigureTime();

            timer.Start();

            wasapiOut.Play();
        }

        private void Timer_Tick(object? sender, ElapsedEventArgs e)
        {
            CurrentTime += TimeSpan.FromSeconds(1);
            CurrentDoubleTime += 1;
        }

        public void Stop()
        {
            if (timer.Enabled == true)
                timer.Stop();

            wasapiOut.Stop();
        }

        public void SetMusic(Music music)
        {
            if (MusicToPlay == null)
            {
                MusicToPlay = music;
                Play();
            }

            if (music != null && MusicToPlay.Id != music.Id)
            {
                Stop();
                media = null;
                MusicToPlay = music;
                Play();
            }
        }

        public void Continue()
        {
            timer.Start();
            wasapiOut.Play();
        }

        public PlaybackState IsPlaying()
        {
            return wasapiOut.PlaybackState;
        }

        async Task GetMusics()
        {
            MusicList = await getMusicsUseCase.Execute();
        }

        public void Previous()
        {
            Music temp = MusicList.Find(x => x.Id == CurrentMusic.Id - 1);
            if (temp == null)
                CurrentMusic = MusicList[MusicList.Count - 1];
            else
                CurrentMusic = temp;
        }

        public void Next()
        {
            Music temp = MusicList.Find(x => x.Id == CurrentMusic.Id + 1);
            if (temp == null)
                CurrentMusic = MusicList[0];
            else
                CurrentMusic = temp;
        }

        public void ChangePosition()
        {
            Pause();
            media.CurrentTime = TimeSpan.FromSeconds(CurrentDoubleTime);
            CurrentTime = TimeSpan.FromSeconds((int)CurrentDoubleTime);
            Continue();
        }

        void ConfigureTime()
        {
            CurrentTime = TimeSpan.Zero;
            CurrentDoubleTime = 0;
            TotalTime = TimeSpan.FromSeconds((int)media.TotalTime.TotalSeconds);
            TotalDoubleTime = media.TotalTime.TotalSeconds;
        }

        public void ChangeVolume()
        {
            wasapiOut.Volume = CurrentVolume;
        }
    }
}
