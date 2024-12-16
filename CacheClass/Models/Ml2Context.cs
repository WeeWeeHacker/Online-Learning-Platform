using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CacheClass.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CacheClass.Models;

public partial class Ml2Context : IdentityDbContext
{
    
    
    public Ml2Context(DbContextOptions<Ml2Context> options)
        : base(options)
    {
    }

    

    

    public DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Collaborative> Collaboratives { get; set; }

    public virtual DbSet<ContentLibaray> ContentLibarays { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<DiscussionForum> DiscussionForums { get; set; }

    public virtual DbSet<EmotionalFeedback> EmotionalFeedbacks { get; set; }

    public virtual DbSet<EmotionalfeedbackReview> EmotionalfeedbackReviews { get; set; }

    public virtual DbSet<FilledSurvey> FilledSurveys { get; set; }

    public virtual DbSet<HealthCondition> HealthConditions { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InteractionLog> InteractionLogs { get; set; }

    public virtual DbSet<Leaderboard> Leaderboards { get; set; }

    public DbSet<Learner> Learners { get; set; }


    public virtual DbSet<LearnerDiscussion> LearnerDiscussions { get; set; }

    public virtual DbSet<LearnerMastery> LearnerMasteries { get; set; }

    public virtual DbSet<LearnersCollaboration> LearnersCollaborations { get; set; }

    public virtual DbSet<LearningActivity> LearningActivities { get; set; }

    public virtual DbSet<LearningGoal> LearningGoals { get; set; }

    public virtual DbSet<LearningPath> LearningPaths { get; set; }

    public virtual DbSet<LearningPreference> LearningPreferences { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<ModuleContent> ModuleContents { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Pathreview> Pathreviews { get; set; }

    public virtual DbSet<PersonalizationProfile> PersonalizationProfiles { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<QuestReward> QuestRewards { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillMastery> SkillMasteries { get; set; }

    public virtual DbSet<SkillProgression> SkillProgressions { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }

    public virtual DbSet<Takenassessment> Takenassessments { get; set; }

    public virtual DbSet<TargetTrait> TargetTraits { get; set; }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Achievement> Achievement { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__276330E0278FA325");

            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.BadgeId).HasColumnName("BadgeID");
            entity.Property(e => e.DateEarned).HasColumnName("date_earned");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assessme__3214EC27AAD1B112");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Criteria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("criteria");
            entity.Property(e => e.Dscription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dscription");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.PassingMarks).HasColumnName("passing_marks");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.TotalMarks).HasColumnName("total_marks");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Weightage).HasColumnName("weightage");

            entity.HasOne(d => d.Course).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Assessmen__Cours__571DF1D5");

            entity.HasOne(d => d.Module).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Assessmen__Modul__5629CD9C");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeId).HasName("PK__Badge__1918237C86317BC7");

            entity.ToTable("Badge");

            entity.Property(e => e.BadgeId)
                .ValueGeneratedNever()
                .HasColumnName("BadgeID");
            entity.Property(e => e.Criteria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("criteria");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Collaborative>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__Collabor__B6619ACB646EA16A");

            entity.ToTable("Collaborative");

            entity.Property(e => e.QuestId)
                .ValueGeneratedNever()
                .HasColumnName("QuestID");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.MaxNumParticipants).HasColumnName("max_num_participants");

            entity.HasOne(d => d.Quest).WithOne(p => p.Collaborative)
                .HasForeignKey<Collaborative>(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Collabora__Quest__2739D489");
        });

        modelBuilder.Entity<ContentLibaray>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContentL__3214EC27FD714B35");

            entity.ToTable("ContentLibaray");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContentUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contentURL");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Metadata)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("metadata");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Course).WithMany(p => p.ContentLibarays)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__ContentLi__Cours__52593CB8");

            entity.HasOne(d => d.Module).WithMany(p => p.ContentLibarays)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__ContentLi__Modul__5165187F");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D7187D807DD7B");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.CreditPoints).HasColumnName("credit_points");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("difficulty_level");
            entity.Property(e => e.LearningObjective)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("learning_objective");
            entity.Property(e => e.Prerequisites)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("prerequisites");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Course_e__7F6877FB4FA3C792");

            entity.ToTable("Course_enrollment");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Course_en__Cours__74AE54BC");

            entity.HasOne(d => d.Learner).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Course_en__Learn__75A278F5");
        });

        modelBuilder.Entity<DiscussionForum>(entity =>
        {
            entity.HasKey(e => e.ForumId).HasName("PK__Discussi__E210AC4F9E1CD559");

            entity.ToTable("Discussion_forum");

            entity.Property(e => e.ForumId)
                .ValueGeneratedNever()
                .HasColumnName("ForumID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.LastActive)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("last_active");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.DiscussionForums)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Discussio__Cours__32AB8735");

            entity.HasOne(d => d.Module).WithMany(p => p.DiscussionForums)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Discussio__Modul__31B762FC");
        });

        modelBuilder.Entity<EmotionalFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Emotiona__6A4BEDF69A54E2FD");

            entity.ToTable("Emotional_feedback");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("FeedbackID");
            entity.Property(e => e.EmotionalState)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("emotional_state");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Learner).WithMany(p => p.EmotionalFeedbacks)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Emotional__Learn__656C112C");
        });

        modelBuilder.Entity<EmotionalfeedbackReview>(entity =>
        {
            entity.HasKey(e => new { e.FeedbackId, e.InstructorId }).HasName("PK__Emotiona__C39BFD41C72E957E");

            entity.ToTable("Emotionalfeedback_review");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.Feedback)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("feedback");

            entity.HasOne(d => d.FeedbackNavigation).WithMany(p => p.EmotionalfeedbackReviews)
                .HasForeignKey(d => d.FeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Emotional__Feedb__70DDC3D8");

            entity.HasOne(d => d.Instructor).WithMany(p => p.EmotionalfeedbackReviews)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Emotional__Instr__71D1E811");
        });

        modelBuilder.Entity<FilledSurvey>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.Question, e.LearnerID }).HasName("PK__FilledSu__D89C33C73F24E9D3");

            entity.ToTable("FilledSurvey");

            entity.Property(e => e.SurveyId).HasColumnName("SurveyID");
            entity.Property(e => e.Question)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Answer).HasColumnType("text");

            entity.HasOne(d => d.Learner).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FilledSur__Learn__0F624AF8");

            entity.HasOne(d => d.SurveyQuestion).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => new { d.SurveyId, d.Question })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FilledSurvey__0E6E26BF");
        });

        modelBuilder.Entity<HealthCondition>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.ProfileId, e.Condition }).HasName("PK__HealthCo__930320B02137C295");

            entity.ToTable("HealthCondition");

            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
            entity.Property(e => e.Condition)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("condition");

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.HealthConditions)
                .HasForeignKey(d => new { d.LearnerID, d.ProfileId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HealthCondition__4222D4EF");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010B7B60F990BE");

            entity.ToTable("Instructor");

            entity.Property(e => e.InstructorId)
                .ValueGeneratedNever()
                .HasColumnName("InstructorID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ExpertiseArea)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("expertise_area");
            entity.Property(e => e.LastestQualification)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastest_qualification");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasMany(d => d.Courses).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "Teach",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teaches__CourseI__797309D9"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teaches__Instruc__787EE5A0"),
                    j =>
                    {
                        j.HasKey("InstructorId", "CourseId").HasName("PK__Teaches__F193DC63F02B2156");
                        j.ToTable("Teaches");
                        j.IndexerProperty<int>("InstructorId").HasColumnName("InstructorID");
                        j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");
                    });
        });

        modelBuilder.Entity<InteractionLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Interact__5E5499A8D2891D44");

            entity.ToTable("Interaction_log");

            entity.Property(e => e.LogId)
                .ValueGeneratedNever()
                .HasColumnName("LogID");
            entity.Property(e => e.ActionType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("action_type");
            entity.Property(e => e.ActivityId).HasColumnName("activity_ID");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Activity).WithMany(p => p.InteractionLogs)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__Interacti__activ__619B8048");

            entity.HasOne(d => d.Learner).WithMany(p => p.InteractionLogs)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Interacti__Learn__628FA481");
        });

        modelBuilder.Entity<Leaderboard>(entity =>
        {
            entity.HasKey(e => e.BoardId).HasName("PK__Leaderbo__F9646BD2D391C7E9");

            entity.ToTable("Leaderboard");

            entity.Property(e => e.BoardId)
                .ValueGeneratedNever()
                .HasColumnName("BoardID");
            entity.Property(e => e.Season)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("season");
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerID).HasName("PK__Learner__67ABFCFABF29C33C");

            entity.ToTable("Learner");

            entity.Property(e => e.LearnerID)
                .ValueGeneratedNever()
                .HasColumnName("LearnerID");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CulturalBackground)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cultural_background");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<LearnerDiscussion>(entity =>
        {
            entity.HasKey(e => new { e.ForumId, e.LearnerID, e.Post }).HasName("PK__LearnerD__FBCECC4A15F95210");

            entity.ToTable("LearnerDiscussion");

            entity.Property(e => e.ForumId).HasColumnName("ForumID");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Post)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Time)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("time");

            entity.HasOne(d => d.Forum).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.ForumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerDi__Forum__3587F3E0");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerDi__Learn__367C1819");
        });

        modelBuilder.Entity<LearnerMastery>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.QuestId }).HasName("PK__LearnerM__CCCDE556A8D3E201");

            entity.ToTable("LearnerMastery");

            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.QuestId).HasColumnName("QuestID");
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("completion_status");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerMasteries)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerMa__Learn__2DE6D218");

            entity.HasOne(d => d.Quest).WithMany(p => p.LearnerMasteries)
                .HasForeignKey(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerMa__Quest__2EDAF651");
        });

        modelBuilder.Entity<LearnersCollaboration>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.QuestId }).HasName("PK__Learners__CCCDE556CFB7C248");

            entity.ToTable("LearnersCollaboration");

            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.QuestId).HasColumnName("QuestID");
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("completion_status");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnersC__Learn__2A164134");

            entity.HasOne(d => d.Quest).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnersC__Quest__2B0A656D");
        });

        modelBuilder.Entity<LearningActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Learning__45F4A7F1BF716625");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("activity_type");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.InstructionDetails)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("instruction_details");
            entity.Property(e => e.MaxPoints).HasColumnName("Max_points");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            entity.HasOne(d => d.Course).WithMany(p => p.LearningActivities)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__LearningA__Cours__5EBF139D");

            entity.HasOne(d => d.Module).WithMany(p => p.LearningActivities)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__LearningA__Modul__5DCAEF64");
        });

        modelBuilder.Entity<LearningGoal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Learning__3214EC27A14C0C35");

            entity.ToTable("Learning_goal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasMany(d => d.Learners).WithMany(p => p.Goals)
                .UsingEntity<Dictionary<string, object>>(
                    "LearnersGoal",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnersG__Learn__05D8E0BE"),
                    l => l.HasOne<LearningGoal>().WithMany()
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnersG__GoalI__04E4BC85"),
                    j =>
                    {
                        j.HasKey("GoalId", "LearnerID").HasName("PK__Learners__3C3540FE147112F4");
                        j.ToTable("LearnersGoals");
                        j.IndexerProperty<int>("GoalId").HasColumnName("GoalID");
                        j.IndexerProperty<int>("LearnerID").HasColumnName("LearnerID");
                    });
        });

        modelBuilder.Entity<LearningPath>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__Learning__BFB8200A902835BB");

            entity.ToTable("Learning_path");

            entity.Property(e => e.PathId).HasColumnName("pathID");
            entity.Property(e => e.AdaptiveRules)
                .IsUnicode(false)
                .HasColumnName("adaptive_rules");
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("completion_status");
            entity.Property(e => e.CustomContent)
                .IsUnicode(false)
                .HasColumnName("custom_content");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.LearningPaths)
                .HasForeignKey(d => new { d.LearnerID, d.ProfileId })
                .HasConstraintName("FK__Learning_path__68487DD7");
        });

        modelBuilder.Entity<LearningPreference>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.Preference }).HasName("PK__Learning__6032E158DB56B876");

            entity.ToTable("LearningPreference");

            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Preference)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("preference");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearningPreferences)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearningP__Learn__3C69FB99");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Modules__2B7477870C331649");

            entity.Property(e => e.ModuleId)
                .ValueGeneratedNever()
                .HasColumnName("ModuleID");
            entity.Property(e => e.ContentUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contentURL");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Difficulty)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("difficulty");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Modules__CourseI__46E78A0C");
        });

        modelBuilder.Entity<ModuleContent>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.CourseId, e.ContentType }).HasName("PK__ModuleCo__402E75DAEA44F9F6");

            entity.ToTable("ModuleContent");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.ContentType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("content_type");

            entity.HasOne(d => d.Course).WithMany(p => p.ModuleContents)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ModuleCon__Cours__4E88ABD4");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleContents)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ModuleCon__Modul__4D94879B");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC2735D9AB29");

            entity.ToTable("Notification");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Message)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");
            entity.Property(e => e.UrgencyLevel)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("urgency_level");

            entity.HasMany(d => d.Learners).WithMany(p => p.Notifications)
                .UsingEntity<Dictionary<string, object>>(
                    "RecievedNotification",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RecievedN__Learn__160F4887"),
                    l => l.HasOne<Notification>().WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RecievedN__Notif__151B244E"),
                    j =>
                    {
                        j.HasKey("NotificationId", "LearnerID").HasName("PK__Recieved__96B591FD97E4723A");
                        j.ToTable("RecievedNotification");
                        j.IndexerProperty<int>("NotificationId").HasColumnName("NotificationID");
                        j.IndexerProperty<int>("LearnerID").HasColumnName("LearnerID");
                    });
        });

        modelBuilder.Entity<Pathreview>(entity =>
        {
            entity.HasKey(e => new { e.InstructorId, e.PathId }).HasName("PK__Pathrevi__11D776B85713958F");

            entity.ToTable("Pathreview");

            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.PathId).HasColumnName("PathID");
            entity.Property(e => e.Feedback)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("feedback");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pathrevie__Instr__6D0D32F4");

            entity.HasOne(d => d.Path).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.PathId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pathrevie__PathI__6E01572D");
        });

        modelBuilder.Entity<PersonalizationProfile>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.ProfileId }).HasName("PK__Personal__353B34725D03E44F");

            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
            entity.Property(e => e.EmotionalState)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("emotional_state");
            entity.Property(e => e.PersonalityType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("personality_type");
            entity.Property(e => e.PreferedContentType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Prefered_content_type");

            entity.HasOne(d => d.Learner).WithMany(p => p.PersonalizationProfiles)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personali__Learn__3F466844");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__Quest__B6619ACB65BFD31F");

            entity.ToTable("Quest");

            entity.Property(e => e.QuestId)
                .ValueGeneratedNever()
                .HasColumnName("QuestID");
            entity.Property(e => e.Criteria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("criteria");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("difficulty_level");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<QuestReward>(entity =>
        {
            entity.HasKey(e => new { e.RewardId, e.QuestId, e.LearnerID }).HasName("PK__QuestRew__D251A7C94328649A");

            entity.ToTable("QuestReward");

            entity.Property(e => e.RewardId).HasColumnName("RewardID");
            entity.Property(e => e.QuestId).HasColumnName("QuestID");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.TimeEarned)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("Time_earned");

            entity.HasOne(d => d.Learner).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuestRewa__Learn__3B40CD36");

            entity.HasOne(d => d.Quest).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuestRewa__Quest__3A4CA8FD");

            entity.HasOne(d => d.Reward).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.RewardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuestRewa__Rewar__395884C4");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => new { e.BoardId, e.LearnerID }).HasName("PK__Ranking__4F1ED41D900804B7");

            entity.ToTable("Ranking");

            entity.Property(e => e.BoardId).HasColumnName("BoardID");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.TotalPoints).HasColumnName("total_points");

            entity.HasOne(d => d.Board).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ranking__BoardID__7E37BEF6");

            entity.HasOne(d => d.Course).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Ranking__CourseI__00200768");

            entity.HasOne(d => d.Learner).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ranking__Learner__7F2BE32F");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.RewardId).HasName("PK__Reward__825015999656B3DC");

            entity.ToTable("Reward");

            entity.Property(e => e.RewardId)
                .ValueGeneratedNever()
                .HasColumnName("RewardID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.Skill1 }).HasName("PK__Skills__C45BDEA5F7B67C58");

            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Skill1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("skill");

            entity.HasOne(d => d.Learner).WithMany(p => p.Skills)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skills__LearnerI__398D8EEE");
        });

        modelBuilder.Entity<SkillMastery>(entity =>
        {
            entity.HasKey(e => new { e.QuestId, e.Skill }).HasName("PK__Skill_Ma__1591B8947FAD3F9B");

            entity.ToTable("Skill_Mastery");

            entity.Property(e => e.QuestId).HasColumnName("QuestID");
            entity.Property(e => e.Skill)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("skill");

            entity.HasOne(d => d.Quest).WithMany(p => p.SkillMasteries)
                .HasForeignKey(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skill_Mas__Quest__245D67DE");
        });

        modelBuilder.Entity<SkillProgression>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SkillPro__3214EC271C556898");

            entity.ToTable("SkillProgression");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.ProficiencyLevel)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("proficiency_level");
            entity.Property(e => e.SkillName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("skill_name");
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Learner).WithMany(p => p.SkillProgressions)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__SkillProg__Learn__1BC821DD");

            entity.HasOne(d => d.Skill).WithMany(p => p.SkillProgressions)
                .HasForeignKey(d => new { d.LearnerID, d.SkillName })
                .HasConstraintName("FK__SkillProgression__1AD3FDA4");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Survey__3214EC27941A649C");

            entity.ToTable("Survey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SurveyQuestion>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.Question }).HasName("PK__SurveyQu__23FB983B5D79D476");

            entity.Property(e => e.SurveyId).HasColumnName("SurveyID");
            entity.Property(e => e.Question)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SurveyQue__Surve__0B91BA14");
        });

        modelBuilder.Entity<Takenassessment>(entity =>
        {
            entity.HasKey(e => new { e.AssessmentId, e.LearnerID }).HasName("PK__Takenass__8B5147F11478F017");

            entity.ToTable("Takenassessment");

            entity.Property(e => e.AssessmentId).HasColumnName("AssessmentID");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.ScoredPoint).HasColumnName("scoredPoint");

            entity.HasOne(d => d.Assessment).WithMany(p => p.Takenassessments)
                .HasForeignKey(d => d.AssessmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Takenasse__Asses__59FA5E80");

            entity.HasOne(d => d.Learner).WithMany(p => p.Takenassessments)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Takenasse__Learn__5AEE82B9");
        });

        modelBuilder.Entity<TargetTrait>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.CourseId, e.Trait }).HasName("PK__Target_t__7E4CF787A7841594");

            entity.ToTable("Target_traits");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Trait)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("trait");

            entity.HasOne(d => d.Course).WithMany(p => p.TargetTraits)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Target_tr__Cours__4AB81AF0");

            entity.HasOne(d => d.Module).WithMany(p => p.TargetTraits)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Target_tr__Modul__49C3F6B7");
        });
        
        var dateOnlyConverter = new ValueConverter<DateOnly?, DateTime?>(
            v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
            v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null);

        modelBuilder.Entity<Achievement>()
            .Property(e => e.DateEarned)
            .HasConversion(dateOnlyConverter);

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__276330E0278FA325");

            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.BadgeId).HasColumnName("BadgeID");
            entity.Property(e => e.DateEarned).HasColumnName("date_earned");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.LearnerID).HasColumnName("LearnerID");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");
        });
        
        
        modelBuilder.Entity<Achievement>()
            .Property(e => e.DateEarned)
            .HasConversion(dateOnlyConverter);
        
        modelBuilder.Entity<Collaborative>()
            .Property(e => e.Deadline)
            .HasConversion(dateOnlyConverter);
        
        modelBuilder.Entity<CourseEnrollment>()
            .Property(e => e.EnrollmentDate)
            .HasConversion(dateOnlyConverter);
        
        modelBuilder.Entity<CourseEnrollment>()
            .Property(e => e.CompletionDate)
            .HasConversion(dateOnlyConverter);
        
        modelBuilder.Entity<CourseEnrollment>()
            .Property(e => e.CompletionDate)
            .HasConversion(dateOnlyConverter);

        modelBuilder.Entity<LearningGoal>()
            .Property(e => e.Deadline)
            .HasConversion(dateOnlyConverter);
        
        modelBuilder.Entity<Learner>()
            .Property(e => e.BirthDate)
            .HasConversion(dateOnlyConverter);
        
        



        OnModelCreatingPartial(modelBuilder);
    }


    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<CacheClass.Models.Admin> Admin { get; set; }
}
