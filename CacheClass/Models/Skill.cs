﻿using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class Skill
{
    public int LearnerID { get; set; }

    public string Skill1 { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;

    public virtual ICollection<SkillProgression> SkillProgressions { get; set; } = new List<SkillProgression>();
}
