USE ML2;
----------------
-- Insert Learner records
INSERT INTO Learner (LearnerID, first_name, last_name, gender, birth_date, country, cultural_background)
VALUES
(1, 'Alice', 'Smith', 'F', '1995-04-23', 'USA', 'Western'),
(2, 'Bob', 'Johnson', 'M', '1998-11-10', 'UK', 'Western'),
(3, 'Catherine', 'Zhou', 'F', '1997-07-15', 'China', 'Eastern'),
(4, 'David', 'Khan', 'M', '1999-01-05', 'India', 'South Asian'),
(5, 'Ella', 'Garcia', 'F', '2000-12-12', 'Spain', 'European'),
(6, 'Frank', 'Lee', 'M', '1996-03-08', 'Canada', 'Western');

-- Insert Skills records

INSERT INTO Skills (LearnerID, skill)
VALUES
(1, 'Python'),
(2, 'Java'),
(3, 'SQL'),
(4, 'Machine Learning'),
(5, 'Data Analysis'),
(6, 'Cloud Computing');

-- Insert LearningPreference records

INSERT INTO LearningPreference (LearnerID, preference)
VALUES
(1, 'Visual Learning'),
(2, 'Hands-On'),
(3, 'Theoretical'),
(4, 'Interactive'),
(5, 'Collaborative'),
(6, 'Self-Paced');


-- Insert PersonalizationProfiles records
INSERT INTO PersonalizationProfiles (LearnerID, ProfileID, Prefered_content_type, emotional_state, personality_type)
VALUES
(1, 1001, 'Video Lectures', 'Calm', 'Analytical'),
(2, 1002, 'Text-Based', 'Focused', 'Pragmatic'),
(3, 1003, 'Interactive Quizzes', 'Engaged', 'Curious'),
(4, 1004, 'E-Books', 'Relaxed', 'Logical'),
(5, 1005, 'Live Classes', 'Excited', 'Energetic'),
(6, 1006, 'Case Studies', 'Motivated', 'Innovative');


-- Insert HealthCondition records
INSERT INTO HealthCondition (LearnerID, ProfileID, condition)
VALUES
(1, 1001, 'Dyslexia'),
(2, 1002, 'ADHD'),
(3, 1003, 'None'),
(4, 1004, 'Visual Impairment'),
(5, 1005, 'None'),
(6, 1006, 'Hearing Impairment');


-- Insert Course records
INSERT INTO Course (CourseID, Title, learning_objective, credit_points, difficulty_level, prerequisites, description)
VALUES
(101, 'Intro to Programming', 'Learn basics of coding', 3, 'Beginner', 'None', 'Covers fundamental coding concepts.'),
(102, 'Database Systems', 'Understand databases', 4, 'Intermediate', 'Intro to Programming', 'Focus on SQL and DB design'),
(103, 'Machine Learning', 'Basics of ML', 5, 'Advanced', 'Programming & Math', 'Introduction to ML algorithms'),
(104, 'Web Development', 'Build websites', 3, 'Beginner', 'None', 'Frontend and backend development'),
(105, 'Data Visualization', 'Analyze data effectively', 4, 'Intermediate', 'Intro to Programming', 'Using tools to visualize data'),
(106, 'Cloud Computing', 'Learn cloud technologies', 5, 'Advanced', 'Networking Basics', 'Cloud platforms and services');

-- Insert Modules records
INSERT INTO Modules (ModuleID, CourseID, Title, difficulty, contentURL)
VALUES
(201, 101, 'Variables and Data Types', 'Beginner', 'http://example.com/module101'),
(202, 102, 'SQL Queries', 'Intermediate', 'http://example.com/module102'),
(203, 103, 'Regression Models', 'Advanced', 'http://example.com/module103'),
(204, 104, 'HTML and CSS', 'Beginner', 'http://example.com/module104'),
(205, 105, 'Data Visualization Tools', 'Intermediate', 'http://example.com/module105'),
(206, 106, 'AWS Basics', 'Advanced', 'http://example.com/module106');

-- Insert Target_traits records
INSERT INTO Target_traits (ModuleID, CourseID, trait)
VALUES
(201, 101, 'Analytical Thinking'),
(202, 102, 'Problem Solving'),
(203, 103, 'Attention to Detail');

-- Insert ModuleContent records
INSERT INTO ModuleContent (ModuleID, CourseID, content_type)
VALUES
(201, 101, 'Video'),
(202, 102, 'PDF'),
(203, 103, 'Quiz');

-- Insert ContentLibrary records
INSERT INTO ContentLibaray (ID, ModuleID, CourseID, Title, description, metadata, type, contentURL)
VALUES
(1, 201, 101, 'Introduction to Variables', 'Video explaining variables', 'Length: 10 min', 'Video', 'http://example.com/intro_variables'),
(2, 202, 102, 'SQL Basics PDF', 'Comprehensive SQL guide', 'Pages: 15', 'Document', 'http://example.com/sql_basics'),
(3, 203, 103, 'Attention to Detail Quiz', 'Interactive quiz', 'Questions: 10', 'Quiz', 'http://example.com/detail_quiz');

-- Insert Assessments records
INSERT INTO Assessments (ID, ModuleID, CourseID, type, total_marks, passing_marks, criteria, weightage, dscription, title)
VALUES
(1, 201, 101, 'Quiz', 100, 50, 'Score above 50%', 30, 'Introductory quiz', 'Variables Quiz'),
(2, 202, 102, 'Assignment', 100, 60, 'Complete with > 60%', 50, 'Practical assignment', 'SQL Basics Assignment'),
(3, 203, 103, 'Project', 200, 100, 'Complete with > 50%', 70, 'Detail-oriented project', 'Attention Project');

-- Insert Takenassessment records
INSERT INTO Takenassessment (AssessmentID, LearnerID, scoredPoint)
VALUES
(1, 1, 85),  -- Learner 1 scored 85 on Assessment 1
(2, 2, 75),  -- Learner 2 scored 75 on Assessment 2
(3, 3, 90),  -- Learner 3 scored 90 on Assessment 3
(1, 2, 60),  -- Learner 2 scored 60 on Assessment 1
(2, 3, 80),  -- Learner 3 scored 80 on Assessment 2
(3, 1, 95);  -- Learner 1 scored 95 on Assessment 3

-- Insert LearningActivities records
INSERT INTO LearningActivities ( ModuleID, CourseID, activity_type, instruction_details, Max_points)
VALUES
( 201, 101, 'Video Watching', 'Watch the video and take notes', 10),
( 202, 102, 'Document Reading', 'Read the PDF and highlight key points', 20),
( 203, 103, 'Quiz Attempt', 'Complete the quiz', 30);

-- Insert Interaction_log records with valid ActivityID references
INSERT INTO Interaction_log (LogID, LearnerID, Duration, action_type)
VALUES
(1, 1, 45, 'View'),
(2, 2, 30, 'Download'),
(3, 3, 15, 'Attempt');



-- Insert Emotional_feedback records with DEFAULT for timestamp
INSERT INTO Emotional_feedback (FeedbackID, LearnerID, timestamp, emotional_state)
VALUES
(1, 1, DEFAULT, 'Happy'),
(2, 2, DEFAULT, 'Stressed'),
(3, 3, DEFAULT, 'Motivated');


-- Insert Learning_path records with valid ProfileID references
INSERT INTO Learning_path ( LearnerID, ProfileID, completion_status, custom_content, adaptive_rules)
VALUES
( 1, 1001, 'In Progress', 'Extra ML videos', 'Focus on practical projects'),
( 2, 1002, 'Completed', 'Additional SQL quizzes', 'Simplify examples'),
( 3, 1003, 'Not Started', 'Basic theoretical content', 'Gradual complexity'),
( 4, 1004, 'In Progress', 'More case studies', 'Real-life examples'),
( 5, 1005, 'Completed', 'Extra live sessions', 'Frequent practice'),
( 6, 1006, 'In Progress', 'Additional readings', 'Collaborative tasks');

-- Insert Instructor records
INSERT INTO Instructor (InstructorID, name, lastest_qualification, expertise_area, email)
VALUES
(1, 'Dr. Emily Brown', 'PhD in Computer Science', 'Machine Learning', 'emily.brown@example.com'),
(2, 'Prof. John Smith', 'MSc in Data Science', 'Databases', 'john.smith@example.com'),
(3, 'Ms. Sarah Lee', 'MEd in Education', 'Instructional Design', 'sarah.lee@example.com');

-- Insert Pathreview records
INSERT INTO Pathreview (InstructorID, PathID, feedback)
VALUES
(1, 1, 'Great progress on ML path'),
(2, 2, 'SQL skills on point'),
(3, 3, 'Needs focus on foundational knowledge');

-- Insert Emotionalfeedback_review records
INSERT INTO Emotionalfeedback_review (FeedbackID, InstructorID, feedback)
VALUES
(1, 1, 'Positive feedback, keep up the good work'),
(2, 2, 'Provide stress management resources'),
(3, 3, 'Motivated learner, recommend challenging tasks');


-- Insert Course_enrollment records
INSERT INTO Course_enrollment (CourseID, LearnerID, completion_date, enrollment_date, status)
VALUES
(101, 1, '2024-05-01', '2024-01-10', 'Completed'),
(102, 2, NULL, '2024-02-15', 'In Progress'),
(103, 3, NULL, '2024-03-01', 'Not Started'),
(104, 4, '2024-06-10', '2024-03-20', 'Completed'),
(105, 5, NULL, '2024-04-01', 'In Progress'),
(106, 6, NULL, '2024-05-10', 'Not Started');

-- Insert Teaches records
INSERT INTO Teaches (InstructorID, CourseID)
VALUES
(1, 101),  -- Instructor 1 teaches Course 101
(2, 102),  -- Instructor 2 teaches Course 102
(3, 103),  -- Instructor 3 teaches Course 103
(1, 102),  -- Instructor 1 also teaches Course 102
(2, 103),  -- Instructor 2 also teaches Course 103
(3, 101);  -- Instructor 3 also teaches Course 101


-- Insert Leaderboard records
INSERT INTO Leaderboard (BoardID, season)
VALUES
(1, 'Spring 2024'),
(2, 'Summer 2024');


-- Insert Ranking records
INSERT INTO Ranking (BoardID, LearnerID, CourseID, ranking, total_points)
VALUES
(1, 1, 101, 1, 950),
(1, 2, 102, 2, 880),
(1, 3, 103, 3, 760),
(2, 4, 104, 1, 990),
(2, 5, 105, 2, 920),
(2, 6, 106, 3, 850);

-- Insert Learning_goal records
INSERT INTO Learning_goal (ID, status, deadline, description)
VALUES
(1, 'In Progress', '2024-12-31', 'Complete the Machine Learning course.'),
(2, 'Completed', '2024-06-30', 'Learn basic SQL queries.'),
(3, 'Not Started', '2024-11-15', 'Understand cloud services.');

-- Insert LearnersGoals records
INSERT INTO LearnersGoals (GoalID, LearnerID)
VALUES
(1, 3),
(2, 2),
(3, 6);


-- Insert Survey records
INSERT INTO Survey (ID, Title)
VALUES
(1, 'Learner Satisfaction Survey'),
(2, 'Course Feedback Survey'),
(3, 'Skill Progression Survey');

-- Insert SurveyQuestions records
INSERT INTO SurveyQuestions (SurveyID, Question)
VALUES
(1, 'How satisfied are you with the platform?'),
(1, 'Would you recommend this platform to others?'),
(2, 'Was the course content helpful?'),
(2, 'Did the course meet your expectations?'),
(3, 'Do you feel your skills have improved?'),
(3, 'What additional resources would you like to see?');


-- Insert FilledSurvey records
INSERT INTO FilledSurvey (SurveyID, Question, LearnerID, Answer)
VALUES
(1, 'How satisfied are you with the platform?', 1, 'Very satisfied'),
(1, 'Would you recommend this platform to others?', 1, 'Yes'),
(2, 'Was the course content helpful?', 2, 'Extremely helpful'),
(2, 'Did the course meet your expectations?', 2, 'Mostly'),
(3, 'Do you feel your skills have improved?', 3, 'Yes, significantly'),
(3, 'What additional resources would you like to see?', 3, 'More coding exercises');


-- Insert Notification records with shortened message text
INSERT INTO Notification ( message, urgency_level)
VALUES
( 'Assignment deadline soon', 'High'),
( 'New course material up', 'Medium');


-- Insert RecievedNotification records
INSERT INTO RecievedNotification (NotificationID, LearnerID)
VALUES
(1, 1),
(2, 2);

-- Insert Badge records
INSERT INTO Badge (BadgeID, title, description, criteria, points)
VALUES
(1, 'SQL Master', 'Achieved advanced SQL proficiency', 'Complete SQL course with > 80%', 50),
(2, 'Machine Learning Expert', 'Excels in ML concepts', 'Complete ML course with > 90%', 100);

-- Insert SkillProgression records excluding the timestamp column
INSERT INTO SkillProgression (ID, proficiency_level, LearnerID, skill_name)
VALUES
(1, 'Intermediate', 1, 'Python'),
(2, 'Advanced', 2, 'Java');

-- Insert Achievement records
INSERT INTO Achievement ( LearnerID, BadgeID, description, date_earned, type)
VALUES
( 1, 1, 'Earned for SQL proficiency', '2024-11-20', 'Badge'),
( 2, 2, 'Earned for ML excellence', '2024-11-25', 'Badge');

-- Insert Reward records
INSERT INTO Reward (RewardID, value, description, type)
VALUES
(1, 100, 'Gift card for learning resources', 'Gift Card'),
(2, 200, 'Extra credit points', 'Points');


-- Insert Quest records
INSERT INTO Quest (QuestID, difficulty_level, criteria, description, title)
VALUES
(1, 'Intermediate', 'Complete 3 ML assignments', 'Hands-on ML practice', 'ML Quest 1'),
(2, 'Beginner', 'Solve 5 SQL queries', 'Intro to Databases', 'SQL Quest 1'),
(3, 'Advanced', 'Complete 2 coding projects', 'Practical coding challenges', 'Programming Quest 1');

-- Insert Skill_Mastery records
INSERT INTO Skill_Mastery (QuestID, skill)
VALUES
(1, 'Machine Learning'),
(2, 'SQL');

-- Insert Collaborative records
INSERT INTO Collaborative (QuestID, deadline, max_num_participants)
VALUES
(1, '2024-12-15', 5),
(2, '2024-12-10', 10);

-- Insert LearnersCollaboration records
INSERT INTO LearnersCollaboration (LearnerID, QuestID, completion_status)
VALUES
(1, 1, 'In Progress'),
(2, 2, 'Completed');

-- Insert LearnerMastery records
INSERT INTO LearnerMastery (LearnerID, QuestID, completion_status)
VALUES
(1, 1, 'Completed'),  -- Learner 1 completed Quest 1
(2, 1, 'In Progress'),  -- Learner 2 is working on Quest 1
(3, 1, 'Not Started'),  -- Learner 3 has not started Quest 1
(1, 2, 'In Progress'),  -- Learner 1 is working on Quest 2
(2, 2, 'Completed'),  -- Learner 2 completed Quest 2
(3, 2, 'In Progress');  -- Learner 3 is working on Quest 2


-- Insert into Discussion_forum
INSERT INTO Discussion_forum (ForumID, ModuleID, CourseID, title, timestamp, description)
VALUES
(1, 201, 101, 'Intro to Variables', '2024-11-20 09:00:00', 'Discuss variables and data types.'),
(2, 202, 102, 'SQL Basics', '2024-11-18 08:00:00', 'Questions about SQL queries.');


-- Insert into LearnerDiscussion
INSERT INTO LearnerDiscussion (ForumID, LearnerID, Post)
VALUES
(1, 1, 'I think variables are the foundation of programming.'),
(2, 2, 'SQL queries can be tricky, but practicing helps.'),
(1, 3, 'The concept of data types is crucial for any language.');

-- Insert QuestReward records
INSERT INTO QuestReward (RewardID, QuestID, LearnerID, Time_earned)
VALUES
(1, 1, 1, DEFAULT),  -- Learner 1 earned Reward 1 for Quest 1
(2, 2, 2, DEFAULT),  -- Learner 2 earned Reward 2 for Quest 2
(1, 3, 3, DEFAULT),  -- Learner 3 earned Reward 1 for Quest 3
(2, 1, 1, DEFAULT),  -- Learner 1 earned Reward 2 for Quest 1
(1, 2, 2, DEFAULT),  -- Learner 2 earned Reward 1 for Quest 2
(2, 3, 3, DEFAULT);  -- Learner 3 earned Reward 2 for Quest 3
