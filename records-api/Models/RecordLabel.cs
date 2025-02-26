using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class RecordLabel
{
    public Guid RecordLabelId { get; set; }

    public string RecordLabelName { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
