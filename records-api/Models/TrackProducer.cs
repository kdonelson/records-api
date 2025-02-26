using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class TrackProducer
{
    public Guid TrackId { get; set; }

    public Guid PersonId { get; set; }

    public virtual Track Track { get; set; } = null!;
}
