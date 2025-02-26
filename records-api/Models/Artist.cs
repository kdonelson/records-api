using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class Artist
{
    public Guid ArtistId { get; set; }

    public string ArtistName { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
