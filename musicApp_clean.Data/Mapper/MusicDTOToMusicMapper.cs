using musicApp_clean.Data.DTO;
using musicApp_clean.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Data.Mapper
{
    internal static class MusicDTOToMusicMapper
    {
        public static Music Map(MusicDTO music)
        {
            return new Music
                (
                    music.Id,
                    music.Title,
                    music.Author,
                    music.Genre,
                    music.Url
                );
        }
    }
}
