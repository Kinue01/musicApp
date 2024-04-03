using musicApp_clean.Data.DTO;
using musicApp_clean.Data.Mapper;
using musicApp_clean.Data.Repository;
using musicApp_clean.Domain.Model;
using musicApp_clean.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Data.Implementations
{
    public class MusicRepositoryImpl(MusicEFDataSource musicEFDataSource) : MusicRepository
    {
        MusicEFDataSource dataSource = musicEFDataSource;

        public async Task<List<Music>> GetMusicByQuery(string query)
        {
            List<MusicDTO> musics = await dataSource.GetMusicsByQuery(query);
            List<Music> result = [];
            musics.ForEach(music =>
            {
                result.Add(MusicDTOToMusicMapper.Map(music));
            });
            return result;
        }

        public async Task<List<Music>> GetMusics()
        {
            List<MusicDTO> musics = await dataSource.GetMusics();
            List<Music> res = [];
            musics.ForEach(m => { res.Add(MusicDTOToMusicMapper.Map(m)); });
            return res;
        }
    }
}
