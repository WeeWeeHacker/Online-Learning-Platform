using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CacheClass.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    BadgeID = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    date_earned = table.Column<DateOnly>(type: "date", nullable: true),
                    type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Achievem__276330E0278FA325", x => x.AchievementID);
                });

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    BadgeID = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    criteria = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Badge__1918237C86317BC7", x => x.BadgeID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    learning_objective = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    credit_points = table.Column<int>(type: "int", nullable: true),
                    difficulty_level = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    prerequisites = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__C92D7187D807DD7B", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    lastest_qualification = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    expertise_area = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruct__9D010B7B60F990BE", x => x.InstructorID);
                });

            migrationBuilder.CreateTable(
                name: "Leaderboard",
                columns: table => new
                {
                    BoardID = table.Column<int>(type: "int", nullable: false),
                    season = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Leaderbo__F9646BD2D391C7E9", x => x.BoardID);
                });

            migrationBuilder.CreateTable(
                name: "Learner",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    last_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    country = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    cultural_background = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learner__67ABFCFABF29C33C", x => x.LearnerID);
                });

            migrationBuilder.CreateTable(
                name: "Learning_goal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__3214EC27A14C0C35", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    message = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    urgency_level = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3214EC2735D9AB29", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    difficulty_level = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    criteria = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quest__B6619ACB65BFD31F", x => x.QuestID);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    RewardID = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reward__825015999656B3DC", x => x.RewardID);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Survey__3214EC27941A649C", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    difficulty = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    contentURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modules__2B7477870C331649", x => x.ModuleID);
                    table.ForeignKey(
                        name: "FK__Modules__CourseI__46E78A0C",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teaches__F193DC63F02B2156", x => new { x.InstructorID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Teaches__CourseI__797309D9",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Teaches__Instruc__787EE5A0",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID");
                });

            migrationBuilder.CreateTable(
                name: "Course_enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true),
                    enrollment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course_e__7F6877FB4FA3C792", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK__Course_en__Cours__74AE54BC",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Course_en__Learn__75A278F5",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "Emotional_feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    emotional_state = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emotiona__6A4BEDF69A54E2FD", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__Emotional__Learn__656C112C",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "LearningPreference",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    preference = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__6032E158DB56B876", x => new { x.LearnerID, x.preference });
                    table.ForeignKey(
                        name: "FK__LearningP__Learn__3C69FB99",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "PersonalizationProfiles",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    Prefered_content_type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    emotional_state = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    personality_type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__353B34725D03E44F", x => new { x.LearnerID, x.ProfileID });
                    table.ForeignKey(
                        name: "FK__Personali__Learn__3F466844",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    BoardID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true),
                    total_points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ranking__4F1ED41D900804B7", x => new { x.BoardID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__Ranking__BoardID__7E37BEF6",
                        column: x => x.BoardID,
                        principalTable: "Leaderboard",
                        principalColumn: "BoardID");
                    table.ForeignKey(
                        name: "FK__Ranking__CourseI__00200768",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Ranking__Learner__7F2BE32F",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__C45BDEA5F7B67C58", x => new { x.LearnerID, x.skill });
                    table.ForeignKey(
                        name: "FK__Skills__LearnerI__398D8EEE",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "LearnersGoals",
                columns: table => new
                {
                    GoalID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learners__3C3540FE147112F4", x => new { x.GoalID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__LearnersG__GoalI__04E4BC85",
                        column: x => x.GoalID,
                        principalTable: "Learning_goal",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__LearnersG__Learn__05D8E0BE",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "RecievedNotification",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recieved__96B591FD97E4723A", x => new { x.NotificationID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__RecievedN__Learn__160F4887",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                    table.ForeignKey(
                        name: "FK__RecievedN__Notif__151B244E",
                        column: x => x.NotificationID,
                        principalTable: "Notification",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Collaborative",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    max_num_participants = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Collabor__B6619ACB646EA16A", x => x.QuestID);
                    table.ForeignKey(
                        name: "FK__Collabora__Quest__2739D489",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerMastery",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    completion_status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerM__CCCDE556A8D3E201", x => new { x.LearnerID, x.QuestID });
                    table.ForeignKey(
                        name: "FK__LearnerMa__Learn__2DE6D218",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                    table.ForeignKey(
                        name: "FK__LearnerMa__Quest__2EDAF651",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID");
                });

            migrationBuilder.CreateTable(
                name: "Skill_Mastery",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skill_Ma__1591B8947FAD3F9B", x => new { x.QuestID, x.skill });
                    table.ForeignKey(
                        name: "FK__Skill_Mas__Quest__245D67DE",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID");
                });

            migrationBuilder.CreateTable(
                name: "QuestReward",
                columns: table => new
                {
                    RewardID = table.Column<int>(type: "int", nullable: false),
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Time_earned = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuestRew__D251A7C94328649A", x => new { x.RewardID, x.QuestID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__QuestRewa__Learn__3B40CD36",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                    table.ForeignKey(
                        name: "FK__QuestRewa__Quest__3A4CA8FD",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID");
                    table.ForeignKey(
                        name: "FK__QuestRewa__Rewar__395884C4",
                        column: x => x.RewardID,
                        principalTable: "Reward",
                        principalColumn: "RewardID");
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SurveyQu__23FB983B5D79D476", x => new { x.SurveyID, x.Question });
                    table.ForeignKey(
                        name: "FK__SurveyQue__Surve__0B91BA14",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    total_marks = table.Column<int>(type: "int", nullable: true),
                    passing_marks = table.Column<int>(type: "int", nullable: true),
                    criteria = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    weightage = table.Column<int>(type: "int", nullable: true),
                    dscription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assessme__3214EC27AAD1B112", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Assessmen__Cours__571DF1D5",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Assessmen__Modul__5629CD9C",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "ContentLibaray",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    metadata = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    contentURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContentL__3214EC27FD714B35", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ContentLi__Cours__52593CB8",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__ContentLi__Modul__5165187F",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "Discussion_forum",
                columns: table => new
                {
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    last_active = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discussi__E210AC4F9E1CD559", x => x.ForumID);
                    table.ForeignKey(
                        name: "FK__Discussio__Cours__32AB8735",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Discussio__Modul__31B762FC",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "LearningActivities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    activity_type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    instruction_details = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Max_points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__45F4A7F1BF716625", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK__LearningA__Cours__5EBF139D",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__LearningA__Modul__5DCAEF64",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "ModuleContent",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    content_type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModuleCo__402E75DAEA44F9F6", x => new { x.ModuleID, x.CourseID, x.content_type });
                    table.ForeignKey(
                        name: "FK__ModuleCon__Cours__4E88ABD4",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__ModuleCon__Modul__4D94879B",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "Target_traits",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    trait = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Target_t__7E4CF787A7841594", x => new { x.ModuleID, x.CourseID, x.trait });
                    table.ForeignKey(
                        name: "FK__Target_tr__Cours__4AB81AF0",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Target_tr__Modul__49C3F6B7",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "Emotionalfeedback_review",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    feedback = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emotiona__C39BFD41C72E957E", x => new { x.FeedbackID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK__Emotional__Feedb__70DDC3D8",
                        column: x => x.FeedbackID,
                        principalTable: "Emotional_feedback",
                        principalColumn: "FeedbackID");
                    table.ForeignKey(
                        name: "FK__Emotional__Instr__71D1E811",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID");
                });

            migrationBuilder.CreateTable(
                name: "HealthCondition",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    condition = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HealthCo__930320B02137C295", x => new { x.LearnerID, x.ProfileID, x.condition });
                    table.ForeignKey(
                        name: "FK__HealthCondition__4222D4EF",
                        columns: x => new { x.LearnerID, x.ProfileID },
                        principalTable: "PersonalizationProfiles",
                        principalColumns: new[] { "LearnerID", "ProfileID" });
                });

            migrationBuilder.CreateTable(
                name: "Learning_path",
                columns: table => new
                {
                    pathID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    ProfileID = table.Column<int>(type: "int", nullable: true),
                    completion_status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    custom_content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    adaptive_rules = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__BFB8200A902835BB", x => x.pathID);
                    table.ForeignKey(
                        name: "FK__Learning_path__68487DD7",
                        columns: x => new { x.LearnerID, x.ProfileID },
                        principalTable: "PersonalizationProfiles",
                        principalColumns: new[] { "LearnerID", "ProfileID" });
                });

            migrationBuilder.CreateTable(
                name: "SkillProgression",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    proficiency_level = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    skill_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SkillPro__3214EC271C556898", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SkillProg__Learn__1BC821DD",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                    table.ForeignKey(
                        name: "FK__SkillProgression__1AD3FDA4",
                        columns: x => new { x.LearnerID, x.skill_name },
                        principalTable: "Skills",
                        principalColumns: new[] { "LearnerID", "skill" });
                });

            migrationBuilder.CreateTable(
                name: "LearnersCollaboration",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    completion_status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learners__CCCDE556CFB7C248", x => new { x.LearnerID, x.QuestID });
                    table.ForeignKey(
                        name: "FK__LearnersC__Learn__2A164134",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                    table.ForeignKey(
                        name: "FK__LearnersC__Quest__2B0A656D",
                        column: x => x.QuestID,
                        principalTable: "Collaborative",
                        principalColumn: "QuestID");
                });

            migrationBuilder.CreateTable(
                name: "FilledSurvey",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FilledSu__D89C33C73F24E9D3", x => new { x.SurveyID, x.Question, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__FilledSur__Learn__0F624AF8",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                    table.ForeignKey(
                        name: "FK__FilledSurvey__0E6E26BF",
                        columns: x => new { x.SurveyID, x.Question },
                        principalTable: "SurveyQuestions",
                        principalColumns: new[] { "SurveyID", "Question" });
                });

            migrationBuilder.CreateTable(
                name: "Takenassessment",
                columns: table => new
                {
                    AssessmentID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    scoredPoint = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Takenass__8B5147F11478F017", x => new { x.AssessmentID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__Takenasse__Asses__59FA5E80",
                        column: x => x.AssessmentID,
                        principalTable: "Assessments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Takenasse__Learn__5AEE82B9",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerDiscussion",
                columns: table => new
                {
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Post = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    time = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerD__FBCECC4A15F95210", x => new { x.ForumID, x.LearnerID, x.Post });
                    table.ForeignKey(
                        name: "FK__LearnerDi__Forum__3587F3E0",
                        column: x => x.ForumID,
                        principalTable: "Discussion_forum",
                        principalColumn: "ForumID");
                    table.ForeignKey(
                        name: "FK__LearnerDi__Learn__367C1819",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "Interaction_log",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false),
                    activity_ID = table.Column<int>(type: "int", nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    action_type = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interact__5E5499A8D2891D44", x => x.LogID);
                    table.ForeignKey(
                        name: "FK__Interacti__Learn__628FA481",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                    table.ForeignKey(
                        name: "FK__Interacti__activ__619B8048",
                        column: x => x.activity_ID,
                        principalTable: "LearningActivities",
                        principalColumn: "ActivityID");
                });

            migrationBuilder.CreateTable(
                name: "Pathreview",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    PathID = table.Column<int>(type: "int", nullable: false),
                    feedback = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pathrevi__11D776B85713958F", x => new { x.InstructorID, x.PathID });
                    table.ForeignKey(
                        name: "FK__Pathrevie__Instr__6D0D32F4",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID");
                    table.ForeignKey(
                        name: "FK__Pathrevie__PathI__6E01572D",
                        column: x => x.PathID,
                        principalTable: "Learning_path",
                        principalColumn: "pathID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_CourseID",
                table: "Assessments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ModuleID",
                table: "Assessments",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentLibaray_CourseID",
                table: "ContentLibaray",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentLibaray_ModuleID",
                table: "ContentLibaray",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_enrollment_CourseID",
                table: "Course_enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_enrollment_LearnerID",
                table: "Course_enrollment",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_forum_CourseID",
                table: "Discussion_forum",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_forum_ModuleID",
                table: "Discussion_forum",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Emotional_feedback_LearnerID",
                table: "Emotional_feedback",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Emotionalfeedback_review_InstructorID",
                table: "Emotionalfeedback_review",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_FilledSurvey_LearnerID",
                table: "FilledSurvey",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_log_activity_ID",
                table: "Interaction_log",
                column: "activity_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_log_LearnerID",
                table: "Interaction_log",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerDiscussion_LearnerID",
                table: "LearnerDiscussion",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerMastery_QuestID",
                table: "LearnerMastery",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnersCollaboration_QuestID",
                table: "LearnersCollaboration",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnersGoals_LearnerID",
                table: "LearnersGoals",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Learning_path_LearnerID_ProfileID",
                table: "Learning_path",
                columns: new[] { "LearnerID", "ProfileID" });

            migrationBuilder.CreateIndex(
                name: "IX_LearningActivities_CourseID",
                table: "LearningActivities",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningActivities_ModuleID",
                table: "LearningActivities",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleContent_CourseID",
                table: "ModuleContent",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseID",
                table: "Modules",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Pathreview_PathID",
                table: "Pathreview",
                column: "PathID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestReward_LearnerID",
                table: "QuestReward",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestReward_QuestID",
                table: "QuestReward",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_CourseID",
                table: "Ranking",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_LearnerID",
                table: "Ranking",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_RecievedNotification_LearnerID",
                table: "RecievedNotification",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillProgression_LearnerID_skill_name",
                table: "SkillProgression",
                columns: new[] { "LearnerID", "skill_name" });

            migrationBuilder.CreateIndex(
                name: "IX_Takenassessment_LearnerID",
                table: "Takenassessment",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Target_traits_CourseID",
                table: "Target_traits",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseID",
                table: "Teaches",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "ContentLibaray");

            migrationBuilder.DropTable(
                name: "Course_enrollment");

            migrationBuilder.DropTable(
                name: "Emotionalfeedback_review");

            migrationBuilder.DropTable(
                name: "FilledSurvey");

            migrationBuilder.DropTable(
                name: "HealthCondition");

            migrationBuilder.DropTable(
                name: "Interaction_log");

            migrationBuilder.DropTable(
                name: "LearnerDiscussion");

            migrationBuilder.DropTable(
                name: "LearnerMastery");

            migrationBuilder.DropTable(
                name: "LearnersCollaboration");

            migrationBuilder.DropTable(
                name: "LearnersGoals");

            migrationBuilder.DropTable(
                name: "LearningPreference");

            migrationBuilder.DropTable(
                name: "ModuleContent");

            migrationBuilder.DropTable(
                name: "Pathreview");

            migrationBuilder.DropTable(
                name: "QuestReward");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "RecievedNotification");

            migrationBuilder.DropTable(
                name: "Skill_Mastery");

            migrationBuilder.DropTable(
                name: "SkillProgression");

            migrationBuilder.DropTable(
                name: "Takenassessment");

            migrationBuilder.DropTable(
                name: "Target_traits");

            migrationBuilder.DropTable(
                name: "Teaches");

            migrationBuilder.DropTable(
                name: "Emotional_feedback");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "LearningActivities");

            migrationBuilder.DropTable(
                name: "Discussion_forum");

            migrationBuilder.DropTable(
                name: "Collaborative");

            migrationBuilder.DropTable(
                name: "Learning_goal");

            migrationBuilder.DropTable(
                name: "Learning_path");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Leaderboard");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "PersonalizationProfiles");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Learner");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
