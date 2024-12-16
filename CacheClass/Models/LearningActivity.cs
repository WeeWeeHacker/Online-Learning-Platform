﻿using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class LearningActivity
{
    public int ActivityId { get; set; }

    public int? ModuleId { get; set; }

    public int? CourseId { get; set; }

    public string? ActivityType { get; set; }

    public string? InstructionDetails { get; set; }

    public int? MaxPoints { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<InteractionLog> InteractionLogs { get; set; } = new List<InteractionLog>();

    public virtual Module? Module { get; set; }
}