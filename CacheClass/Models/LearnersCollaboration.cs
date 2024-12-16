﻿using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class LearnersCollaboration
{
    public int LearnerID { get; set; }

    public int QuestId { get; set; }

    public string? CompletionStatus { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Collaborative Quest { get; set; } = null!;
}