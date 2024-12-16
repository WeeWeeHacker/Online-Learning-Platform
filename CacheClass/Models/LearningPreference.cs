using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class LearningPreference
{
    public int LearnerID { get; set; }

    public string Preference { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
