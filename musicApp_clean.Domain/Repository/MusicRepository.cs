using musicApp_clean.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Domain.Repository
{
    public interface MusicRepository
    {
        Task<List<Music>> GetMusics();
        Task<List<Music>> GetMusicByQuery(string query);
    }
}
