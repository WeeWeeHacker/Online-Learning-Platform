using System;
using System.Collections.Generic;

namespace CacheClass.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Title { get; set; }

    public string? LearningObjective { get; set; }

    public int? CreditPoints { get; set; }

    public string? DifficultyLevel { get; set; }

    public string? Prerequisites { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<ContentLibaray> ContentLibarays { get; set; } = new List<ContentLibaray>();

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<DiscussionForum> DiscussionForums { get; set; } = new List<DiscussionForum>();

    public virtual ICollection<LearningActivity> LearningActivities { get; set; } = new List<LearningActivity>();

    public virtual ICollection<ModuleContent> ModuleContents { get; set; } = new List<ModuleContent>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<TargetTrait> TargetTraits { get; set; } = new List<TargetTrait>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
