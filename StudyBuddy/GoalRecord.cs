using System;

namespace StudyBuddy
{
    public class GoalRecord
    {
        public string? Id { get; set; }
        public string? SubjectName { get; set; }
        public TimeSpan StudyDuration { get; set; }
        public DateTime CreatedAt { get; set; }

        public GoalRecord()
        {
        }

        public GoalRecord(string? subjectName, TimeSpan studyDuration)
        {
            SubjectName = subjectName;
            StudyDuration = studyDuration;
            CreatedAt = DateTime.Now;
        }

        public GoalRecord(string? id, string? subjectName, TimeSpan studyDuration, DateTime createdAt)
        {
            Id = id;
            SubjectName = subjectName;
            StudyDuration = studyDuration;
            CreatedAt = createdAt;
        }
    }
}
