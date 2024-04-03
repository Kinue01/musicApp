using musicApp_clean.Data.DTO;
using musicApp_clean.Infrastructure.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Infrastructure.EntityFramework.Mapper
{
    internal static class TbMusicToMusicDTOMapper
    {
        readonly static MusicsDbContext musicsDbContext = new();
        public static MusicDTO Map(TbMusic music)
        {
            return new MusicDTO
                (
                    music.MusicId,
                    music.MusicName,
                    musicsDbContext.TbAuthors.Find(music.MusicAuthorId).AuthorName,
                    musicsDbContext.TbGenres.Find(music.MusicGenreId).GenreName,
                    music.MusicUrl
                );
        }
    }
}
