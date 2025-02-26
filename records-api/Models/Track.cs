using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class Track
{
    public Guid TrackId { get; set; }

    public Guid SongId { get; set; }

    public int TrackLength { get; set; }

    public Guid RecordId { get; set; }

    public string? SongNameOverride { get; set; }

    public int? TrackNumber { get; set; }

    public virtual Record Record { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
