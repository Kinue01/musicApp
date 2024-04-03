using Microsoft.EntityFrameworkCore;
using musicApp_clean.Data.DTO;
using musicApp_clean.Data.Repository;
using musicApp_clean.Infrastructure.EntityFramework.Mapper;
using musicApp_clean.Infrastructure.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Infrastructure.EntityFramework.Implementations
{
    public class MusicEFDataSourceImpl(IDbContextFactory<MusicsDbContext> dbContextFactory) : MusicEFDataSource
    {
        IDbContextFactory<MusicsDbContext> dbContextFactory = dbContextFactory;

        public async Task<List<MusicDTO>> GetMusics()
        {
            using MusicsDbContext musicsDbContext = await dbContextFactory.CreateDbContextAsync();
            List<TbMusic> musicList = await musicsDbContext.TbMusics.ToListAsync();
            List<MusicDTO> res = [];
            musicList.ForEach(music => 
            { 
                res.Add(TbMusicToMusicDTOMapper.Map(music)); 
            });
            return res;
        }

        public async Task<List<MusicDTO>> GetMusicsByQuery(string query)
        {
            using MusicsDbContext musicsDbContext = await dbContextFactory.CreateDbContextAsync();
            List<TbMusic> tbMusics = await musicsDbContext.TbMusics.Where(x => x.MusicName.ToLower().Contains(query) 
            || x.MusicAuthorId == musicsDbContext.TbAuthors.First(y => y.AuthorName.ToLower().Contains(query)).AuthorId 
            || x.MusicGenreId == musicsDbContext.TbGenres.First(z => z.GenreName.ToLower().Contains(query)).GenreId).ToListAsync();
            List<MusicDTO> res = [];
            tbMusics.ForEach(music =>
            {
                res.Add(TbMusicToMusicDTOMapper.Map(music));
            });
            return res;
        }
    }
}
