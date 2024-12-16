using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CacheClass.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Display(Name = "Latest Qualification")]
    public string? LastestQualification { get; set; }

    [Display(Name = "Expertise Area")]
    public string? ExpertiseArea { get; set; }

    [Display(Name = "Email")]
    public string? Email { get; set; }

    public string? Username { get; set; } // Add this property

    public string? Password { get; set; } // Add this property
    
    public  string PasswordHash { get; set; }
    
    public  string Role { get; set; }

    public virtual ICollection<EmotionalfeedbackReview> EmotionalfeedbackReviews { get; set; } = new List<EmotionalfeedbackReview>();

    public virtual ICollection<Pathreview> Pathreviews { get; set; } = new List<Pathreview>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    
    

    
}
