using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public int? LearnerID { get; set; }

    public int? BadgeId { get; set; }

    public string? Description { get; set; }

    public DateOnly? DateEarned { get; set; }

    public string? Type { get; set; }
}
