USE ML2;

-- Admin Procedures

-- Youssef (1-12):
-- 1 (Works)


GO
CREATE PROCEDURE ViewInfo
@LearnerID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
        )
    BEGIN
        SELECT * FROM Learner
        WHERE LearnerID = @LearnerID;
    END
    ELSE
    BEGIN
		PRINT 'Learner not found';
	END
END;

EXEC ViewInfo @LearnerID = 1

--2 (works)
GO
CREATE PROCEDURE LearnerInfo
@LearnerID INT
AS
BEGIN
    IF EXISTS (
		SELECT 1
		FROM Learner
		WHERE LearnerID = @LearnerID
		)
    BEGIN
        SELECT * FROM Learner WHERE LearnerID = @LearnerID;
        SELECT * FROM Skills WHERE LearnerID = @LearnerID;
        SELECT * FROM LearningPreference WHERE LearnerID = @LearnerID;
        SELECT * FROM PersonalizationProfiles WHERE LearnerID = @LearnerID;
        SELECT * FROM HealthCondition WHERE LearnerID = @LearnerID;
    END
    ELSE
    BEGIN
        PRINT 'Learner not found';
    END

END;

EXEC LearnerInfo @LearnerID = 1

--3 (works)
GO
CREATE PROCEDURE EmotionalState
@LearnerID INT
AS
BEGIN
    IF EXISTS(
        SELECT  1
        FROM PersonalizationProfiles
		WHERE LearnerID = @LearnerID
    )
    BEGIN
		SELECT emotional_state
		FROM PersonalizationProfiles
		WHERE LearnerID = @LearnerID;
	END
	ELSE
    BEGIN
        PRINT 'Learner not found';
    END
END;

EXEC EmotionalState @LearnerID = 1

--4 (works)
GO
CREATE PROCEDURE LogDetails
@LearnerID INT
AS
BEGIN
    IF EXISTS(
    SELECT 1
    FROM Interaction_log
    WHERE LearnerID = @LearnerID
    )
    BEGIN
		SELECT * FROM Interaction_log
        WHERE LearnerID = @LearnerID;
	END
	ELSE
    BEGIN
        PRINT 'No logs available';
	END
END;

EXEC LogDetails @LearnerID = 1

--5 (works)
GO
CREATE PROCEDURE InstructorReview
@InstructorID INT
AS
BEGIN
    IF EXISTS(
		SELECT 1
		FROM Instructor
		WHERE InstructorID = @InstructorID
	)
	BEGIN
		SELECT * FROM Emotionalfeedback_review
        WHERE InstructorID = @InstructorID;
	END
	ELSE
	BEGIN
		PRINT 'No emotional feedback available for this instructor';
	END
END;

EXEC InstructorReview @InstructorID = 1

--6 (works)
GO
CREATE PROCEDURE CourseRemove
@courseID INT
AS
BEGIN
    IF NOT EXISTS(
        SELECT 1
        FROM Teaches
		WHERE CourseID = @courseID
    )
    BEGIN
        IF EXISTS(
            SELECT 1
            FROM Course
			WHERE CourseID = @courseID
        )
        BEGIN
			DELETE FROM Course
			WHERE CourseID = @courseID;
			PRINT 'Course removed';
		END
		ELSE
        PRINT 'Course not found';
    END
    ELSE
    PRINT 'Cannot remove; course is being taught'

END;

-- EXEC CourseRemove @courseID = 101 Recursive call for some reason

--7 (works)
GO
CREATE PROCEDURE Highestgrade
AS
BEGIN
SELECT MAX(total_marks) AS 'Highest Assessment Score', Course.CourseID
FROM Course INNER JOIN Assessments ON Course.CourseID = Assessments.CourseID
GROUP BY Course.CourseID
END

EXEC Highestgrade

--8 (works)
GO
CREATE PROCEDURE InstructorCount
AS
BEGIN
SELECT Course.Title AS 'Courses'
FROM Teaches INNER JOIN Course ON Teaches.CourseID = Course.CourseID
GROUP BY Course.Title
HAVING COUNT(Teaches.InstructorID) > 1
END

EXEC InstructorCount

--9 (works)
GO
CREATE PROCEDURE ViewNot
@LearnerID INT
AS
BEGIN
    IF EXISTS (
		SELECT 1
		FROM RecievedNotification
		WHERE LearnerID = @LearnerID
		)
    BEGIN
        SELECT Notification.ID, Notification.timestamp, Notification.message, Notification.urgency_level
        FROM Notification INNER JOIN RecievedNotification ON Notification.ID = RecievedNotification.NotificationID
        WHERE RecievedNotification.LearnerID = @LearnerID
    END
    ELSE
    PRINT 'No notifications recieved'
END

-- EXEC ViewNot @LearnerID = 1 Recursive Call for some reason

--10
GO
CREATE PROCEDURE CreateDiscussion
@ModuleID INT, @CourseID INT, @title VARCHAR(50), @description VARCHAR(50)
AS
BEGIN
INSERT INTO Discussion_forum(ModuleID, CourseID, title, description)
VALUES(@ModuleID, @CourseID, @title, @description)
print 'Discussion Forum ' + @title + ' created'
END

--11 (works)
GO
CREATE PROCEDURE RemoveBadge
@BadgeID INT
AS
BEGIN
    IF EXISTS (
		SELECT 1
		FROM Badge
		WHERE BadgeID = @BadgeID
	)
    BEGIN
        DELETE FROM Badge
        WHERE BadgeID = @BadgeID
        print 'Badge ' + @BadgeID + ' removed'
    END
    ELSE
    PRINT 'Badge not found'
END

EXEC RemoveBadge @BadgeID = 1000

--12 (works)
GO
CREATE PROCEDURE CriteriaDelete
@criteria VARCHAR(50)
AS
BEGIN
	IF EXISTS (
		SELECT 1
		FROM Quest
		WHERE criteria = @criteria
	)
	BEGIN
		DELETE FROM Quest
		WHERE criteria = @criteria
		print 'Quest(s) with criteria ' + @criteria + ' deleted'
	END
	ELSE
	PRINT 'No quests with "' + @criteria + '" criteria found'
END

--Ahmed (13-14/1-9):
--13 (No)


    
GO
CREATE PROCEDURE NotificationUpdate
@LearnerID int, @NotificationID int, @ReadStatus bit
AS
IF @ReadStatus = 1
    BEGIN
        UPDATE RecievedNotification
        SET IsRead = 1
        WHERE LearnerID = @LearnerID AND NotificationID = @NotificationID;
    END
ELSE
    BEGIN
        DELETE FROM RecievedNotification
        WHERE LearnerID = @LearnerID AND NotificationID = @NotificationID;
    END


-- 14 (No)

GO
CREATE PROCEDURE EmotionalTrendAnalysis
@CourseID int, @ModuleID int, @TimePeriod datetime
AS
BEGIN
Select e.emotional_state
From Course c
    inner join Modules m ON c.CourseID = m.CourseID
    inner join Learner l ON l.ModuleID = m.ModuleID
    inner join Emotional_feedback e ON l.LearnerID = e.LearnerID
where c.CourseID = @CourseID AND m.ModuleID = @ModuleID AND e.timestamp >= @TimePeriod
END

-----------------------------------------------------------------------------------------------------------------------------------------

-- Learner Procedures
-- 1
GO
CREATE PROCEDURE ProfileUpdate
@LearnerID int, @ProfileID int, @PreferedContentType varchar(50), @emotional_state varchar(50), @PersonalityType varchar(50)
AS
BEGIN
Update PersonalizationProfiles
SET
Prefered_content_type = @PreferedContentType,
emotional_state = @emotional_state,
personality_type = @PersonalityType
WHERE LearnerID = @LearnerID AND ProfileID = @ProfileID
END

--2
    
GO
CREATE PROCEDURE TotalPoints
@LearnerID int, @RewardType varchar(50)
AS
BEGIN
Select Count(points)
from QuestReward q inner join Reward r ON q.RewardID = r.RewardID
where LearnerID = @LearnerID AND type = @RewardType
END

--3
GO
CREATE PROCEDURE EnrolledCourses
@LearnerID int
AS
BEGIN
Select Title
from Course_enrollment ce inner join Course c ON ce.CourseID = c.CourseID
where ce.LearnerID = @LearnerID
END

--4
GO
CREATE PROCEDURE Prerequisites
@LearnerID INT, @CourseID INT
AS
BEGIN
DECLARE @Prerequisites VARCHAR(30)
DECLARE @CompletionStatus VARCHAR(30)

Select @Prerequisites = prerequisites
From Course
Where CourseID = @CourseID

Select @CompletionStatus = status
from Course_enrollment
where LearnerID = @LearnerID AND CourseID IN (SELECT CourseID FROM Course WHERE prerequisites = @Prerequisites)

    IF @CompletionStatus = 'Completed'
        SELECT 'All prerequisites are completed.' AS Message;
    ELSE
        SELECT 'Not all prerequisites are completed.' AS Message;
END

--5
GO
CREATE PROCEDURE Moduletraits
@TargetTrait varchar(50), @CourseID int
AS
BEGIN
Select Title
from Target_traits tt inner join Modules m ON tt.CourseID = m.CourseID
where Trait = @TargetTrait AND m.CourseID = @CourseID
END

--6
GO
CREATE PROCEDURE LeaderboardRank
@LeaderboardID int
AS
BEGIN
Select LearnerID , rank
from Ranking
where BoardID = @LeaderboardID
END

--7 (No)

    
GO
CREATE PROCEDURE ViewMyDeviceCharge
@ActivityID INT, @LearnerID INT, @emotionalstate VARCHAR(50)
AS
BEGIN
    SELECT i.ActivityID, i.LearnerID, i.timestamp, e.emotional_state
    FROM Interaction_log i
    INNER JOIN Emotional_feedback e ON i.LearnerID = e.LearnerID
    WHERE i.ActivityID = @ActivityID AND i.LearnerID = @LearnerID;

    INSERT INTO Emotional_feedback (LearnerID, emotional_state, ActivityID)
    VALUES (@LearnerID, @emotionalstate, @ActivityID);
END;

--8
GO
CREATE PROCEDURE JoinQuest
@LearnerID int, @QuestID int
AS
BEGIN
DECLARE @CurrentParticipants INT;
    DECLARE @MaxParticipants INT;

    SELECT @MaxParticipants = max_num_participants
    FROM Collaborative
    WHERE QuestID = @QuestID;

    SELECT @CurrentParticipants = COUNT(*)
    FROM LearnersCollaboration
    WHERE QuestID = @QuestID;

    IF @CurrentParticipants < @MaxParticipants
    BEGIN
        INSERT INTO LearnersCollaboration (LearnerID, QuestID, completion_status)
        VALUES (@LearnerID, @QuestID, 'Not Completed');

        SELECT 'You have successfully joined the quest!' AS Message;
    END

    ELSE
        SELECT 'Sorry, the quest is full. You cannot join.' AS Message;
END

--9
GO
CREATE PROCEDURE SkillsProfeciency
@LearnerID int
AS
BEGIN
Select proficiency_level , skill_name
from SkillProgression
where LearnerID = @LearnerID
END


-----------------------------------------------------------------------------------------------------------------------------------------

--Learner Procedures
--Nour's part

-- [2] 10) View my score for a certain assessment.

GO
CREATE PROCEDURE ViewScore
    @LearnerID INT,
    @AssessmentID INT,
    @score INT OUTPUT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Takenassessment
        WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID
    )
    BEGIN
        SELECT @score = scoredPoint
        FROM Takenassessment
        WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID;
    END
    ELSE
    BEGIN
        SET @score = NULL;
    END
END;


--execute
DECLARE @score INT;
EXEC ViewScore @LearnerID = 1, @AssessmentID = 1, @score = @score OUTPUT;

SELECT @score AS Score;


-- [2] 11)View all the assessments I took and its grades for a certain module.
GO
CREATE PROCEDURE AssessmentsList
    @courseID INT,
    @ModuleID INT,
    @LearnerID INT
AS
BEGIN
    SELECT
        a.title AS AssessmentTitle,
        a.total_marks AS TotalMarks,
        a.passing_marks AS PassingMarks,
        ta.scoredPoint AS LearnerScore,
        (CASE
            WHEN ta.scoredPoint >= a.passing_marks THEN 'Passed'
            ELSE 'Failed'
        END) AS GradeStatus
    FROM
        Assessments a
    JOIN
        Takenassessment ta ON a.ID = ta.AssessmentID
    WHERE
        a.CourseID = @courseID
        AND a.ModuleID = @ModuleID
        AND ta.LearnerID = @LearnerID;
END;


--EXECUTE

EXEC AssessmentsList
    @courseID = 102,
    @ModuleID = 202,
    @LearnerID = 1;


 -- [2] 12) Register in any course I want as long as I completed its prerequisites


GO
CREATE PROCEDURE Courseregister
    @LearnerID INT,
    @CourseID INT
AS
BEGIN

    DECLARE @Prerequisites VARCHAR(30);
    SELECT @Prerequisites = prerequisites
    FROM Course
    WHERE CourseID = @CourseID;


    IF @Prerequisites IS NULL OR @Prerequisites = ''
    BEGIN
        INSERT INTO Course_enrollment (CourseID, LearnerID, enrollment_date, status)
        VALUES (@CourseID, @LearnerID, GETDATE(), 'Enrolled');
        PRINT 'Registration Approved: No prerequisites required.';
        RETURN;
    END


    DECLARE @CompletedCoursesCount INT;
    SELECT @CompletedCoursesCount = COUNT(*)
    FROM Course_enrollment
    WHERE LearnerID = @LearnerID
      AND CourseID IN (SELECT CourseID FROM Course WHERE Title = @Prerequisites)
      AND status = 'Completed';


    IF @CompletedCoursesCount > 0
    BEGIN
        INSERT INTO Course_enrollment (CourseID, LearnerID, enrollment_date, status)
        VALUES (@CourseID, @LearnerID, GETDATE(), 'Enrolled');
        PRINT 'Registration Approved: Prerequisites met.';
    END
    ELSE
    BEGIN
        PRINT 'Registration Rejected: Prerequisites not met.';
    END
END;


--exec

EXEC Courseregister @LearnerID = 1, @CourseID = 102;



--[2] 13)Add any post to an existing discussion forum.
GO
CREATE PROCEDURE Post
    @LearnerID INT,
    @DiscussionID INT,
    @Post VARCHAR(MAX)
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Discussion_forum
        WHERE ForumID = @DiscussionID
    )
    BEGIN
        PRINT 'Error: Discussion forum does not exist.';
        RETURN;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
        PRINT 'Error: Learner does not exist.';
        RETURN;
    END;

    INSERT INTO LearnerDiscussion (ForumID, LearnerID, Post)
    VALUES (@DiscussionID, @LearnerID, @Post);

    PRINT 'Post added successfully.';
END;




--exec

EXEC Post
    @LearnerID = 1,
    @DiscussionID = 1,
    @Post = 'This is a new post on the forum.';



--[2] 14)Add new learning goals for myself.
GO
CREATE PROCEDURE AddGoal
    @LearnerID INT,
    @GoalID INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
        PRINT 'Error: Learner does not exist.';
        RETURN;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM Learning_goal
        WHERE ID = @GoalID
    )
    BEGIN
        PRINT 'Error: Learning goal does not exist.';
        RETURN;
    END;

    IF EXISTS (
        SELECT 1
        FROM LearnersGoals
        WHERE GoalID = @GoalID AND LearnerID = @LearnerID
    )
    BEGIN
        PRINT 'Error: Learning goal is already added for this learner.';
        RETURN;
    END;

    INSERT INTO LearnersGoals (GoalID, LearnerID)
    VALUES (@GoalID, @LearnerID);

    PRINT 'Learning goal added successfully.';
END;


--exec

EXEC AddGoal @LearnerID = 1, @GoalID = 3;


--[2]  15) View all the current statuses of my learning paths --WORKS!!

GO
CREATE PROCEDURE CurrentPath
    @LearnerID INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
        PRINT 'Error: Learner does not exist.';
        RETURN;
    END;

    SELECT
        LP.pathID AS PathID,
        LP.completion_status AS Status,
        LP.custom_content AS CustomContent,
        LP.adaptive_rules AS AdaptiveRules
    FROM Learning_path LP
    WHERE LP.LearnerID = @LearnerID;
END;


--exec

EXEC CurrentPath @LearnerID = 1;


-- [2] 16) View all the members participating in all the collaborative quests that I am participating in and --WORKSS!!

GO
CREATE PROCEDURE QuestMembers
    @LearnerID INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
        PRINT 'Error: Learner does not exist.';
        RETURN;
    END;

    SELECT
        CQ.QuestID,
        CQ.deadline,
        L.LearnerID,
        L.first_name + ' ' + L.last_name AS MemberName
    FROM Collaborative CQ
    INNER JOIN QuestReward QR ON CQ.QuestID = QR.QuestID
    INNER JOIN Learner L ON QR.LearnerID = L.LearnerID
    WHERE QR.QuestID IN (
        SELECT QuestID
        FROM QuestReward
        WHERE LearnerID = @LearnerID
    )
    AND CQ.deadline >= GETDATE()
    ORDER BY CQ.QuestID, MemberName;
END;


--exec
EXEC QuestMembers @LearnerID = 1;




--[2] 17) View my progress toward earning badges or completing quests.


GO
CREATE PROCEDURE QuestProgress
    @LearnerID INT
AS
BEGIN
    SELECT
        q.QuestID,
        q.title AS QuestTitle,
        q.criteria AS QuestCriteria,
        q.difficulty_level AS QuestDifficulty,
        CASE
            WHEN qr.LearnerID IS NOT NULL THEN 'Completed'
            ELSE 'In Progress'
        END AS QuestProgressStatus,
        CASE
            WHEN qr.LearnerID IS NOT NULL THEN 'Earned'
            ELSE 'Not Earned'
        END AS QuestRewardStatus,

        sm.skill AS QuestSkill,
        sm.QuestID AS SkillMasteryQuestID,
        CASE
            WHEN sm.QuestID IS NOT NULL THEN 'Mastered'
            ELSE 'Not Mastered'
        END AS SkillMasteryStatus,

        b.BadgeID,
        b.title AS BadgeTitle,
        b.criteria AS BadgeCriteria,
        a.date_earned AS BadgeEarnedDate,
        CASE
            WHEN a.LearnerID IS NOT NULL THEN 'Earned'
            ELSE 'Not Earned'
        END AS BadgeProgressStatus
    FROM
        Quest q
    LEFT JOIN
        QuestReward qr ON q.QuestID = qr.QuestID AND qr.LearnerID = @LearnerID
    LEFT JOIN
        Skill_Mastery sm ON sm.QuestID = q.QuestID
    LEFT JOIN
        Achievement a ON a.LearnerID = @LearnerID
    LEFT JOIN
        Badge b ON a.BadgeID = b.BadgeID
    WHERE
        qr.LearnerID = @LearnerID
        OR sm.QuestID IS NOT NULL
        OR a.LearnerID = @LearnerID;
END;



--EXEC

EXEC QuestProgress @LearnerID = 1;

--[2] 18) Receive reminders if I am falling behind on a learning goals timeline. --WORKS!!


GO
CREATE PROCEDURE GoalReminder
    @LearnerID INT
AS
BEGIN
    SELECT
        lg.ID AS GoalID,
        lg.description AS GoalDescription,
        lg.deadline AS GoalDeadline,
        CASE
            WHEN GETDATE() > lg.deadline AND lg.status <> 'Completed' THEN 'You are behind schedule on your learning goal. The deadline has passed.'
            WHEN GETDATE() > DATEADD(DAY, -7, lg.deadline) AND lg.status <> 'Completed' THEN 'Reminder: Your learning goal is approaching the deadline. Please catch up.'
            ELSE 'On Track'
        END AS ReminderMessage,
        'Please review your progress and take necessary actions to complete the goal on time.' AS ActionMessage
    FROM
        Learning_goal lg
    INNER JOIN
        LearnersGoals lgmap ON lg.ID = lgmap.GoalID
    WHERE
        lgmap.LearnerID = @LearnerID
        AND (GETDATE() > lg.deadline OR GETDATE() > DATEADD(DAY, -7, lg.deadline))
        AND lg.status <> 'Completed';
END;


--exec
EXEC GoalReminder @LearnerID = 1;


--[2] 19) Track my skill progression over time. --WORKS!!


GO
CREATE PROCEDURE SkillProgressHistory
    @LearnerID INT,
    @Skill VARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
        PRINT 'Error: Learner does not exist.';
        RETURN;
    END;

    SELECT
        SP.timestamp AS ProgressTimestamp,
        SP.proficiency_level AS ProficiencyLevel,
        SP.skill_name AS Skill,
        L.first_name + ' ' + L.last_name AS LearnerName
    FROM SkillProgression SP
    INNER JOIN Learner L ON SP.LearnerID = L.LearnerID
    WHERE SP.LearnerID = @LearnerID
    AND SP.skill_name = @Skill
    ORDER BY SP.timestamp;
END;



--exec

EXEC SkillProgressHistory @LearnerID = 1, @Skill = 'Python';


--[2] 20) Access a breakdown of my assessment scores to identify strengths and weaknesses. --WORKS!!

GO
CREATE PROCEDURE AssessmentAnalysis
    @LearnerID INT
AS
BEGIN
    SELECT
        a.ID AS AssessmentID,
        a.title AS AssessmentTitle,
        a.total_marks AS TotalMarks,
        ta.scoredPoint AS LearnerScore,
        ta.scoredPoint * 100.0 / a.total_marks AS ScorePercentage,
        a.criteria AS AssessmentCriteria,
        m.Title AS ModuleTitle,
        c.Title AS CourseTitle,
        c.learning_objective AS CourseObjective,
        CASE
            WHEN ta.scoredPoint * 100.0 / a.total_marks >= 90 THEN 'Excellent'
            WHEN ta.scoredPoint * 100.0 / a.total_marks >= 75 THEN 'Good'
            WHEN ta.scoredPoint * 100.0 / a.total_marks >= 50 THEN 'Average'
            ELSE 'Needs Improvement'
        END AS PerformanceLevel
    FROM
        Takenassessment ta
    INNER JOIN
        Assessments a ON ta.AssessmentID = a.ID
    INNER JOIN
        Modules m ON a.ModuleID = m.ModuleID
    INNER JOIN
        Course c ON m.CourseID = c.CourseID
    WHERE
        ta.LearnerID = @LearnerID;
END;

--exec


EXEC AssessmentAnalysis @LearnerID = 1;


--[2] 21) Filter or sort leaderboards by my rank descendingly . --WORKS!1

GO
CREATE PROCEDURE LeaderboardFilter
    @LearnerID INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
        PRINT 'Error: Learner does not exist.';
        RETURN;
    END;

    SELECT
        L.first_name + ' ' + L.last_name AS LearnerName,
        R.rank AS Rank,
        C.Title AS CourseTitle,
        R.total_points AS TotalPoints
    FROM Ranking R
    INNER JOIN Learner L ON R.LearnerID = L.LearnerID
    INNER JOIN Course C ON R.CourseID = C.CourseID
    WHERE R.LearnerID = @LearnerID
    ORDER BY R.rank DESC;
END;




--exec
EXEC LeaderboardFilter @LearnerID = 1;

-----------------------------------------------------------------------------------------------------------------------------------------
--Instructor Procedures
--Lana
-- 1. SkillLearners
GO
CREATE PROCEDURE SkillLearners
@Skillname VARCHAR(50)
AS
BEGIN
    SELECT
        L.first_name + ' ' + L.last_name AS LearnerName,
        S.skill AS Skill
    FROM Skills S
    INNER JOIN Learner L ON S.LearnerID = L.LearnerID
    WHERE S.skill = @Skillname;
END;

-- 2. NewActivity
GO
CREATE PROCEDURE NewActivity
    @CourseID INT,
    @ModuleID INT,
    @activity_type VARCHAR(50),
    @instruction_details VARCHAR(MAX),
    @Max_points INT
AS
BEGIN
    INSERT INTO LearningActivities (CourseID, ModuleID, activity_type, instruction_details, Max_points)
    VALUES (@CourseID, @ModuleID, @activity_type, @instruction_details, @Max_points);
END;

-- 3. NewAchievement
GO
CREATE PROCEDURE NewAchievement
    @LearnerID INT,
    @BadgeID INT,
    @description VARCHAR(MAX),
    @date_earned DATE,
    @type VARCHAR(50)
AS
BEGIN
    INSERT INTO Achievement (LearnerID, BadgeID, description, date_earned, type)
    VALUES (@LearnerID, @BadgeID, @description, @date_earned, @type);

    SELECT 'Achievement Added Successfully' AS ConfirmationMessage; -- Added Output
END;

-- 4. LearnerBadge
GO
CREATE PROCEDURE LearnerBadge
    @BadgeID INT
AS
BEGIN
    SELECT
        L.first_name + ' ' + L.last_name AS LearnerName
    FROM Achievement A
    INNER JOIN Learner L ON A.LearnerID = L.LearnerID
    WHERE A.BadgeID = @BadgeID;
END;

-- 5. CollaborativeQuest
GO
CREATE PROCEDURE CollaborativeQuest
    @difficulty_level VARCHAR(50),
    @criteria VARCHAR(50),
    @description VARCHAR(50),
    @title VARCHAR(50),
    @Maxnumparticipants INT,
    @deadline DATETIME
AS
BEGIN
    DECLARE @QuestID INT = (SELECT ISNULL(MAX(QuestID), 0) + 1 FROM Quest);

    INSERT INTO Quest (QuestID, difficulty_level, criteria, description, title)
    VALUES (@QuestID, @difficulty_level, @criteria, @description, @title);

    INSERT INTO Collaborative (QuestID, deadline, max_num_participants)
    VALUES (@QuestID, @deadline, @Maxnumparticipants);
END;

-- 6. GradeUpdate
GO
CREATE PROCEDURE GradeUpdate
    @LearnerID INT,
    @AssessmentID INT,
    @NewGrade INT
AS
BEGIN
    UPDATE TakenAssessment
    SET scoredPoint = @NewGrade
    WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID;

    SELECT 'Grade Updated Successfully' AS ConfirmationMessage; -- Added Output
END;

-- 7. NewGoal
GO
CREATE PROCEDURE NewGoal
    @GoalID INT,
    @status VARCHAR(MAX),
    @deadline DATETIME,
    @description VARCHAR(MAX)
AS
BEGIN
    INSERT INTO Learning_goal (ID, status, deadline, description)
    VALUES (@GoalID, @status, @deadline, @description);

    SELECT 'Goal Added Successfully' AS ConfirmationMessage; -- Added Output
END;

--8
GO
CREATE PROCEDURE DeadlineUpdate
@QuestID INT, @deadline datetime
AS
BEGIN
    IF EXISTS(
        SELECT 1
        FROM Collaborative
        WHERE QuestID = @QuestID
    )
    BEGIN
		UPDATE Collaborative
		SET deadline = @deadline
		WHERE QuestID = @QuestID;
	END
	ELSE
    PRINT 'Quest not found'
END

--9
GO
CREATE PROCEDURE GradeUpdate
@LearnerID INT, @AssessmentID INT, @points INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM takenassessment
		WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID
    )
    BEGIN
        UPDATE takenassessment
        SET scoredPoint = @points
		WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID;
        PRINT 'Asessment score updated!'
    END
    ELSE
    PRINT 'Assessment not found'
END

--10
GO
CREATE PROCEDURE AssessmentNot
@NotificationID INT, @timestamp timestamp, @message varchar(50), @urgency_level varchar(50), @LearnerID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
        SET IDENTITY_INSERT Notification ON;
        INSERT INTO Notification (ID, message, urgency_level)
        VALUES (@NotificationID, @timestamp, @message, @urgency_level);
        SET IDENTITY_INSERT Notification OFF;
        INSERT INTO RecievedNotification (LearnerID, NotificationID)
    VALUES (@LearnerID, @NotificationID)
    PRINT 'Notification sent'
    END
    ELSE
    PRINT 'Learner not found'
END


-- ==============================
-- Execute Procedures
-- ==============================

-- Example: SkillLearners
EXEC SkillLearners 'Python';

-- Example: NewActivity
EXEC NewActivity 1, 1, 'Quiz', 'Solve these questions', 50;

-- Example: NewAchievement
EXEC NewAchievement 1, 10, 'Python Mastery Completed', '2023-11-25', 'Academic';

-- Example: LearnerBadge
EXEC LearnerBadge 10;

-- Example: CollaborativeQuest
EXEC CollaborativeQuest 'Intermediate', 'Teamwork', 'Complete Project', 'Team Quest', 5, '2023-12-31';

-- Example: GradeUpdate
EXEC GradeUpdate 1, 1, 95;

-- Example: NewGoal
EXEC NewGoal 1, 'Active', '2024-01-15', 'Complete AI Module';

-----------------------------------------------------------------------------------------------------------------------------------------
--Moaz (11-21)

--11
GO
CREATE PROCEDURE NewGoal
@GoalID int,
@status varchar(max),
@deadline datetime,
@description varchar(max)
AS
Insert into Learning_goal(ID , status , deadline , description) values (@GoalID , @status , @deadline , @description)

--12
Go
CREATE PROC LearnersCourses
@CourseID INT,
@InstructorID INT
AS
SELECT l.LearnerID, l.first_name + ' ' + l.last_name AS Name
FROM Learner l
INNER JOIN Course_enrollment e ON l.LearnerID = e.LearnerID
INNER JOIN Course c ON e.CourseID = c.CourseID
WHERE c.CourseID = @CourseID ;

--13
GO
CREATE PROCEDURE LastActive
@ForumID INT,
@lastactive DATETIME OUTPUT
AS
SELECT @lastactive = last_active
FROM Discussion_forum
WHERE ForumID = @ForumID;

--14
GO
CREATE PROCEDURE CommonEmotiobnalState
@state VARCHAR(50) OUTPUT
AS
WITH StateCounts AS (
        SELECT emotional_state, COUNT(*) AS Count
        FROM Emotional_feedback
        GROUP BY emotional_state)

SELECT @state = emotional_state
FROM StateCounts
WHERE Count = (SELECT MAX(Count) FROM StateCounts)

--15
GO
CREATE PROCEDURE ModuleDifficulty
@courseID INT
AS
BEGIN
SELECT ModuleID, Title, difficulty, contentURL
FROM Modules
WHERE CourseID = @courseID
ORDER BY difficulty
END

--16
GO
CREATE PROCEDURE ProfeciencyLevel
@LearnerID INT, @skill varchar(50) OUTPUT
AS
BEGIN
    IF EXISTS(
        SELECT skill
        FROM Skills
        WHERE LearnerID = @LearnerID
    )
    BEGIN
		SELECT TOP 1 @skill = skill
		FROM Skills
		WHERE LearnerID = @LearnerID
		ORDER BY skill DESC;
	END
	ELSE
    PRINT 'No skills found'
END

DECLARE @skill varchar(50);

EXEC ProfeciencyLevel @LearnerID = 1, @skill = @skill OUTPUT;
SELECT @skill AS skill;

--17
GO
CREATE PROCEDURE ProficiencyUpdate
@Skill VARCHAR(50), @LearnerID INT, @Level VARCHAR(50)
AS
BEGIN
    INSERT INTO SkillProgression (LearnerID, skill_name, proficiency_level)
    VALUES (@LearnerID, @Skill, @Level);
END;

--18
GO
CREATE PROCEDURE LeastBadge
@LearnerID INT OUTPUT
AS
BEGIN
    IF EXISTS(
        SELECT 1
        FROM Learner
        WHERE LearnerID = @LearnerID
    )
    BEGIN
    SELECT LearnerID
    FROM (
        SELECT TOP 1 LearnerID, COUNT(BadgeID) AS BadgeCount
        FROM Achievement
        GROUP BY LearnerID
        ORDER BY BadgeCount ASC
        ) AS LeastBadges
    END
    ELSE
    PRINT 'Learner not found'
END;

DECLARE @LearnerID INT;

EXEC LeastBadge @LearnerID = @LearnerID OUTPUT;

SELECT @LearnerID AS LearnerID;

--19
GO
CREATE PROCEDURE PreferredType
@type VARCHAR(50) OUTPUT
AS
BEGIN
    SELECT Prefered_content_type
    INTO TopType
    FROM PersonalizationProfiles
    GROUP BY Prefered_content_type
    ORDER BY COUNT(*) DESC;
END

DECLARE @type VARCHAR(50);

EXEC PreferredType @type = @type OUTPUT;

SELECT @type AS PreferredType;

--20
GO
CREATE PROCEDURE AssessmentAnalytics
@CourseID INT, @ModuleID INT
AS
BEGIN
    SELECT
        ce.LearnerID,
        a.type AS AssessmentType,
        AVG(a.total_marks) AS AverageScore,
        m.Title AS ModuleName
    FROM Course_enrollment ce
    JOIN Assessments a ON a.CourseID = ce.CourseID
    JOIN Modules m ON m.ModuleID = a.ModuleID
    WHERE a.CourseID = @CourseID AND a.ModuleID = @ModuleID
    GROUP BY ce.LearnerID, a.type, m.Title;
END;

--21
GO
CREATE PROCEDURE EmotionalTrendAnalysis
@CourseID INT, @ModuleID INT, @TimePeriod DATETIME
AS
BEGIN
    SELECT
        ce.LearnerID,
        ef.emotional_state,
        COUNT(*) AS StateOccurrences
    FROM Course_enrollment ce
    JOIN Emotional_feedback ef ON ce.LearnerID = ef.LearnerID
    JOIN Modules m ON m.CourseID = ce.CourseID
    WHERE ce.CourseID = @CourseID AND m.ModuleID = @ModuleID AND ef.timestamp <= @TimePeriod
    GROUP BY ce.LearnerID, ef.emotional_state;
END;

    -- fetch servername and database name
SELECT @@SERVERNAME AS 'ServerName', DB_NAME() AS 'DatabaseName';

    
-- add username and password or sum idk
Alter table Learner
    Add Username nvarchar(50) not null default '',
        Password nvarchar(50) not null default '';
    
-- Check the table schema
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Learners';

-- Example query with correct column names
SELECT LearnerID, Username, Password
FROM Learner
WHERE Username = 'some_value';
    
-- check table schema-- Check the table schema
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Learner';