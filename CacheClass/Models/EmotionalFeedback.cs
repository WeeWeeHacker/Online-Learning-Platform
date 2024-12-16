using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class EmotionalFeedback
{
    public int FeedbackId { get; set; }

    public int? LearnerID { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public string? EmotionalState { get; set; }

    public virtual ICollection<EmotionalfeedbackReview> EmotionalfeedbackReviews { get; set; } = new List<EmotionalfeedbackReview>();

    public virtual Learner? Learner { get; set; }
}
