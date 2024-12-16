using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class Notification
{
    public int Id { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public string? Message { get; set; }

    public string? UrgencyLevel { get; set; }

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
