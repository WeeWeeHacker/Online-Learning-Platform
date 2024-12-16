using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class InteractionLog
{
    public int LogId { get; set; }

    public int? ActivityId { get; set; }

    public int? LearnerID { get; set; }

    public int? Duration { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public string? ActionType { get; set; }

    public virtual LearningActivity? Activity { get; set; }

    public virtual Learner? Learner { get; set; }
}
