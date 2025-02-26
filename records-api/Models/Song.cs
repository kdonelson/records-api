using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class Song
{
    public Guid SongId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
