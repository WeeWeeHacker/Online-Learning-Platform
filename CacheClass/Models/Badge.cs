using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class Badge
{
    public int BadgeId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Criteria { get; set; }

    public int? Points { get; set; }
}
