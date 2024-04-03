using System;
using System.Collections.Generic;

namespace musicApp_clean.Infrastructure.EntityFramework.Model;

public partial class TbMusic
{
    public int MusicId { get; set; }

    public string MusicName { get; set; } = null!;

    public int? MusicAuthorId { get; set; }

    public int? MusicGenreId { get; set; }

    public string MusicUrl { get; set; } = null!;

    public virtual TbAuthor? MusicAuthor { get; set; }

    public virtual TbGenre? MusicGenre { get; set; }
}
