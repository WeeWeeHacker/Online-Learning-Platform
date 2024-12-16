using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class LearnerMastery
{
    public int LearnerID { get; set; }

    public int QuestId { get; set; }

    public string? CompletionStatus { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Quest Quest { get; set; } = null!;
}
