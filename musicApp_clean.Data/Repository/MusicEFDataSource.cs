using musicApp_clean.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Data.Repository
{
    public interface MusicEFDataSource
    {
        Task<List<MusicDTO>> GetMusics();
        Task<List<MusicDTO>> GetMusicsByQuery(string query);
    }
}
