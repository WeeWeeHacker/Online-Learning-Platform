using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class Takenassessment
{
    public int AssessmentId { get; set; }

    public int LearnerID { get; set; }

    public int? ScoredPoint { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
