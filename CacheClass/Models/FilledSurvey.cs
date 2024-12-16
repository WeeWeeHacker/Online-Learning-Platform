﻿using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class FilledSurvey
{
    public int SurveyId { get; set; }

    public string Question { get; set; } = null!;

    public int LearnerID { get; set; }

    public string? Answer { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual SurveyQuestion SurveyQuestion { get; set; } = null!;
}
