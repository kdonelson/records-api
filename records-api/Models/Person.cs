using System;
using System.Collections.Generic;

namespace records_api.Models;

public partial class Person
{
    public Guid PersonId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }
}
