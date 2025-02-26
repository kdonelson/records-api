using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class PersonArtist
{
    public Guid? PersonId { get; set; }

    public Guid? ArtistId { get; set; }

    public virtual Artist? Artist { get; set; }

    public virtual Person? Person { get; set; }
}
