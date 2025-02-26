using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class Record
{
    public Guid RecordId { get; set; }

    public string Title { get; set; } = null!;

    public Guid ArtistId { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string? AlbumArt { get; set; }

    public Guid RecordLabelId { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual RecordLabel RecordLabel { get; set; } = null!;

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
