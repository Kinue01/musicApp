using System;
using System.Collections.Generic;

namespace musicApp_clean.Infrastructure.EntityFramework.Model;

public partial class TbGenre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<TbMusic> TbMusics { get; set; } = new List<TbMusic>();
}
