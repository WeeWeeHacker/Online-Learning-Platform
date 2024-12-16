using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class QuestReward
{
    public int RewardId { get; set; }

    public int QuestId { get; set; }

    public int LearnerID { get; set; }

    public byte[] TimeEarned { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;

    public virtual Quest Quest { get; set; } = null!;

    public virtual Reward Reward { get; set; } = null!;
}
