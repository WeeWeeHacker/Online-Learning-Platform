-- Active: 1732464601553@@127.0.0.1@3306
CREATE DATABASE ML2;
USE ML2;

CREATE TABLE Learner(
LearnerID INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
gender VARCHAR(1),
birth_date DATE,
country VARCHAR(50),
cultural_background VARCHAR(50)
);

CREATE TABLE Skills(
LearnerID INT,
skill VARCHAR(50),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
PRIMARY KEY (LearnerID, skill)
);


CREATE TABLE LearningPreference(
LearnerID INT,
preference VARCHAR(50),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
PRIMARY KEY (LearnerID, preference)
);

CREATE TABLE PersonalizationProfiles(
LearnerID INT,
ProfileID INT,
Prefered_content_type varchar(50),
emotional_state varchar(50),
personality_type varchar(50),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
PRIMARY KEY (LearnerID, ProfileID)
);





CREATE TABLE HealthCondition(
    LearnerID INT,
    ProfileID INT,
    condition VARCHAR(50),
    PRIMARY KEY (LearnerID, ProfileID, condition),
    FOREIGN KEY (LearnerID, ProfileID) REFERENCES PersonalizationProfiles(LearnerID, ProfileID)
);

CREATE TABLE Course(
CourseID INT PRIMARY KEY,
Title VARCHAR(50),
learning_objective VARCHAR(50),
credit_points INT,
difficulty_level VARCHAR(50),
prerequisites VARCHAR(50),
description VARCHAR(50)
);

CREATE TABLE Modules(
ModuleID INT PRIMARY KEY,
CourseID INT,
Title VARCHAR(50),
difficulty VARCHAR(50),
contentURL VARCHAR(255), -- i had to change "URL" simce it doesnot work for me
FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);


CREATE TABLE Target_traits(
ModuleID INT,
CourseID INT,
trait VARCHAR(50),
FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
PRIMARY KEY (ModuleID, CourseID, trait)
);

CREATE TABLE ModuleContent(
ModuleID INT,
CourseID INT,
content_type VARCHAR(50),
FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
PRIMARY KEY (ModuleID, CourseID, content_type)
);

CREATE TABLE ContentLibaray(
ID INT PRIMARY KEY,
ModuleID INT,
CourseID INT,
Title VARCHAR(50),
description VARCHAR(50),
metadata VARCHAR(50),
type VARCHAR(50),
contentURL VARCHAR(255), -- same with the url
FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

CREATE TABLE Assessments(
ID INT PRIMARY KEY,
ModuleID INT,
CourseID INT,
type VARCHAR(50),
total_marks INT,
passing_marks INT,
criteria VARCHAR(50),
weightage INT,
dscription VARCHAR(50),
title VARCHAR(50),
FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

CREATE TABLE Takenassessment (
    AssessmentID INT,
    LearnerID INT,
    scoredPoint INT,
    PRIMARY KEY (AssessmentID, LearnerID),
    FOREIGN KEY (AssessmentID) REFERENCES Assessments(ID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID)
);

CREATE TABLE LearningActivities(
ActivityID INT IDENTITY PRIMARY KEY,
ModuleID INT,
CourseID INT,
activity_type VARCHAR(50),
instruction_details VARCHAR(50),
Max_points INT,
FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);


CREATE TABLE Interaction_log(
LogID INT PRIMARY KEY,
activity_ID INT,
LearnerID INT,
Duration INT,
Timestamp TIMESTAMP,
action_type VARCHAR(50),
FOREIGN KEY (activity_ID) REFERENCES LearningActivities(ActivityID),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID)
);



CREATE TABLE Emotional_feedback(
FeedbackID INT PRIMARY KEY,
LearnerID INT,
timestamp TIMESTAMP,
emotional_state VARCHAR(50),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID)
);



CREATE TABLE Learning_path(
    pathID INT IDENTITY PRIMARY KEY,
    LearnerID INT,
    ProfileID INT,
    completion_status VARCHAR(50),
    custom_content TEXT,
    adaptive_rules TEXT,
    FOREIGN KEY (LearnerID, ProfileID) REFERENCES PersonalizationProfiles(LearnerID, ProfileID)
);

CREATE TABLE Instructor(
InstructorID INT PRIMARY KEY,
name VARCHAR(50),
lastest_qualification VARCHAR(50),
expertise_area VARCHAR(50),
email VARCHAR(50)
);

CREATE TABLE Pathreview(
InstructorID INT,
PathID INT,
feedback VARCHAR(50),
FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID),
FOREIGN KEY (PathID) REFERENCES Learning_path(pathID),
PRIMARY KEY (InstructorID, PathID)
);
ALTER TABLE Pathreview ALTER COLUMN feedback VARCHAR(100);


CREATE TABLE Emotionalfeedback_review(
FeedbackID INT,
InstructorID INT,
feedback VARCHAR(100),
FOREIGN KEY (FeedbackID) REFERENCES Emotional_feedback(FeedbackID),
FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID),
PRIMARY KEY (FeedbackID, InstructorID)
);

CREATE TABLE Course_enrollment(
EnrollmentID INT IDENTITY PRIMARY KEY, -- make it identity
CourseID INT,
LearnerID INT,
completion_date DATE,
enrollment_date DATE,
status VARCHAR(50),
FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID)
);



CREATE TABLE Teaches(
InstructorID INT,
CourseID INT,
FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID),
FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
PRIMARY KEY (InstructorID, CourseID)
);

CREATE TABLE Leaderboard(
BoardID INT PRIMARY KEY,
season VARCHAR(50)
);

CREATE TABLE Ranking(
    BoardID INT,
    LearnerID INT,
    CourseID INT,
    ranking INT,
    total_points INT,
    FOREIGN KEY (BoardID) REFERENCES Leaderboard(BoardID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    PRIMARY KEY (BoardID, LearnerID)
);

CREATE TABLE Learning_goal(
ID INT PRIMARY KEY,
status VARCHAR(50),
deadline DATE,
description VARCHAR(50)
);

CREATE TABLE LearnersGoals(
GoalID INT,
LearnerID INT,
FOREIGN KEY (GoalID) REFERENCES Learning_goal(ID),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
PRIMARY KEY (GoalID, LearnerID)
);

CREATE TABLE Survey(
ID INT PRIMARY KEY,
Title VARCHAR(50)
);

CREATE TABLE SurveyQuestions(
SurveyID INT,
Question VARCHAR(255), -- i had to remove "text" since it didn't work for me
FOREIGN KEY (SurveyID) REFERENCES Survey(ID),
PRIMARY KEY (SurveyID, Question)
);



CREATE TABLE FilledSurvey(
    SurveyID INT,
    Question VARCHAR(255),
    LearnerID INT,
    Answer TEXT,
    FOREIGN KEY (SurveyID, Question) REFERENCES SurveyQuestions(SurveyID, Question),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
    PRIMARY KEY (SurveyID, Question, LearnerID)
);


CREATE TABLE Notification(
ID INT IDENTITY PRIMARY KEY,
timestamp TIMESTAMP,
message VARCHAR(50),
urgency_level VARCHAR(50)
);
ALTER TABLE Notification
ALTER COLUMN message VARCHAR(100);

CREATE TABLE RecievedNotification(
NotificationID INT,
LearnerID INT,
FOREIGN KEY (NotificationID) REFERENCES Notification(ID),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
PRIMARY KEY (NotificationID, LearnerID)
);

CREATE TABLE Badge(
BadgeID INT PRIMARY KEY,
title VARCHAR(50),
description VARCHAR(50),
criteria VARCHAR(50),
points INT
);



CREATE TABLE SkillProgression (
    ID INT PRIMARY KEY,
    proficiency_level VARCHAR(50),
    LearnerID INT,
    skill_name VARCHAR(50),
    timestamp DATETIME,
    FOREIGN KEY (LearnerID, skill_name) REFERENCES Skills(LearnerID, skill),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID)
);


CREATE TABLE Achievement(
AchievementID INT IDENTITY PRIMARY KEY,
LearnerID INT,
BadgeID INT,
description VARCHAR(50),
date_earned DATE,
type VARCHAR(50)
);

CREATE TABLE Reward(
RewardID INT PRIMARY KEY,
value INT,
description VARCHAR(50),
type VARCHAR(50)
);

CREATE TABLE Quest(
QuestID INT PRIMARY KEY,
difficulty_level VARCHAR(50),
criteria VARCHAR(50),
description VARCHAR(50),
title VARCHAR(50)
);

CREATE TABLE Skill_Mastery(
QuestID INT,
skill VARCHAR(50),
FOREIGN KEY (QuestID) REFERENCES Quest(QuestID),
Primary KEY (QuestID, skill)
);

CREATE TABLE Collaborative(
QuestID INT,
deadline DATE,
max_num_participants INT,
FOREIGN KEY (QuestID) REFERENCES Quest(QuestID),
Primary KEY (QuestID)
);

CREATE TABLE LearnersCollaboration (
    LearnerID INT,
    QuestID INT,
    completion_status VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
    FOREIGN KEY (QuestID) REFERENCES Collaborative(QuestID),
    PRIMARY KEY (LearnerID, QuestID)
);

CREATE TABLE LearnerMastery (
    LearnerID INT,
    QuestID INT,
    completion_status VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
    FOREIGN KEY (QuestID) REFERENCES Quest(QuestID),
    PRIMARY KEY (LearnerID, QuestID)
);



CREATE TABLE Discussion_forum(
    ForumID INT PRIMARY KEY,
    ModuleID INT,
    CourseID INT,
    title VARCHAR(50),
    last_active TIMESTAMP, -- If you want a timestamp that automatically updates when modified
    timestamp DATETIME, -- Use DATETIME for the custom timestamp
    description VARCHAR(50),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);


CREATE TABLE LearnerDiscussion(
ForumID INT,
LearnerID INT,
Post VARCHAR(255), -- had to use varchar instead of "text"
time TIMESTAMP,
FOREIGN KEY (ForumID) REFERENCES Discussion_forum(ForumID),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
PRIMARY KEY (ForumID, LearnerID, Post)
);

CREATE TABLE QuestReward(
RewardID INT,
QuestID INT,
LearnerID INT,
Time_earned TIMESTAMP,
FOREIGN KEY (RewardID) REFERENCES Reward(RewardID),
FOREIGN KEY (QuestID) REFERENCES Quest(QuestID),
FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID),
PRIMARY KEY (RewardID, QuestID, LearnerID)
);

--------------------------
