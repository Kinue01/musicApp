using musicApp_clean.Domain.Model;
using musicApp_clean.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Domain.UseCase
{
    public class GetMusicByQueryUseCase(MusicRepository musicRepository)
    {
        MusicRepository musicRepository = musicRepository;

        public async Task<List<Music>> Execute(string query)
        {
            return await musicRepository.GetMusicByQuery(query);
        }
    }
}
