using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicApp_clean.Domain.Model
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Url { get; set; }

        public Music(int id, string title, string author, string genre, string url)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Url = url;
        }
    }
}
