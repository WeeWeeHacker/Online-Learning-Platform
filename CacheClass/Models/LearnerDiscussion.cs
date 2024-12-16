using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class LearnerDiscussion
{
    public int ForumId { get; set; }

    public int LearnerID { get; set; }

    public string Post { get; set; } = null!;

    public byte[] Time { get; set; } = null!;

    public virtual DiscussionForum Forum { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
    
    
}
