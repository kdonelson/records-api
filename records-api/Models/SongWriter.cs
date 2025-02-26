using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class SongWriter
{
    public Guid SongId { get; set; }

    public Guid PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
