using System.ComponentModel.DataAnnotations;

namespace CacheClass.Models;


public partial class Learner
{
    
    [Display(Name = "Learner ID")]
    public int LearnerID { get; set; }
    
   
    
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    public string? Gender { get; set; }

    [Display(Name = "Birth Date")]
    public DateOnly? BirthDate { get; set; }

    public string? Country { get; set; }

    [Display(Name = "Cultural Background")]
    public string? CulturalBackground { get; set; }

    public string Username { get; set; } // Add this property

    public string Password { get; set; } // Add this property
    
    // public  string Role { get; set; }
    
    // public string Email { get; set; } 

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual ICollection<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>();

    public virtual ICollection<InteractionLog> InteractionLogs { get; set; } = new List<InteractionLog>();

    public virtual ICollection<LearnerDiscussion> LearnerDiscussions { get; set; } = new List<LearnerDiscussion>();

    public virtual ICollection<LearnerMastery> LearnerMasteries { get; set; } = new List<LearnerMastery>();

    public virtual ICollection<LearnersCollaboration> LearnersCollaborations { get; set; } = new List<LearnersCollaboration>();

    public virtual ICollection<LearningPreference> LearningPreferences { get; set; } = new List<LearningPreference>();

    public virtual ICollection<PersonalizationProfile> PersonalizationProfiles { get; set; } = new List<PersonalizationProfile>();

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<SkillProgression> SkillProgressions { get; set; } = new List<SkillProgression>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<Takenassessment> Takenassessments { get; set; } = new List<Takenassessment>();

    public virtual ICollection<LearningGoal> Goals { get; set; } = new List<LearningGoal>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
