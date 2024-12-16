using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class SkillProgression
{
    public int Id { get; set; }

    public string? ProficiencyLevel { get; set; }

    public int? LearnerID { get; set; }

    public string? SkillName { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public virtual Learner? Learner { get; set; }

    public virtual Skill? Skill { get; set; }
}
