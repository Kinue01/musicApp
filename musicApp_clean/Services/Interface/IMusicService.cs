using musicApp_clean.Domain.Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace musicApp_clean.UI.Services.Interface
{
    public interface IMusicService
    {
        //Music CurrentMusic { get; set; }
        //Music MusicToPlay { get; set; }
        List<Music> MusicList { get; set; }
        //TimeSpan CurrentTime { get; set; }
        void Play();
        void Pause();
        void Continue();
        PlaybackState IsPlaying();
        void Previous();
        void Next();
        void ChangePosition();
        void ChangeVolume();
    }
}
