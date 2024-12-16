﻿using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class DiscussionForum
{
    public int ForumId { get; set; }

    public int? ModuleId { get; set; }

    public int? CourseId { get; set; }

    public string? Title { get; set; }

    public byte[] LastActive { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public string? Description { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<LearnerDiscussion> LearnerDiscussions { get; set; } = new List<LearnerDiscussion>();

    public virtual Module? Module { get; set; }
}