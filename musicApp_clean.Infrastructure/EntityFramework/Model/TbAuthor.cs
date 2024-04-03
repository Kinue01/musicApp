using System;
using System.Collections.Generic;

namespace musicApp_clean.Infrastructure.EntityFramework.Model;

public partial class TbAuthor
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public virtual ICollection<TbMusic> TbMusics { get; set; } = new List<TbMusic>();
}
