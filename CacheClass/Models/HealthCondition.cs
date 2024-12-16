using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class HealthCondition
{
    public int LearnerID { get; set; }

    public int ProfileId { get; set; }

    public string Condition { get; set; } = null!;

    public virtual PersonalizationProfile PersonalizationProfile { get; set; } = null!;
}
