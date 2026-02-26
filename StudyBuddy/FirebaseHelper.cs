using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://studybuddy-1226b-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task SaveGoalRecord(GoalRecord goalRecord)
        {
            var newRecord = await firebase
                .Child("GoalRecords")
                .PostAsync(goalRecord);

            goalRecord.Id = newRecord.Key;
        }

        public async Task<List<GoalRecord>> GetGoalRecords()
        {
            var goalRecords = await firebase
                .Child("GoalRecords")
                .OnceAsync<GoalRecord>();

            return goalRecords.Select(gr => new GoalRecord(
                gr.Key,
                gr.Object.SubjectName,
                gr.Object.StudyDuration,
                gr.Object.CreatedAt))
                .OrderByDescending(gr => gr.CreatedAt)
                .ToList();
        }

        public async Task<GoalRecord> GetGoalRecordByKey(string? firebaseKey)
        {
            var goalRecord = await firebase
                .Child("GoalRecords")
                .Child(firebaseKey)
                .OnceSingleAsync<GoalRecord>();

            goalRecord.Id = firebaseKey;
            return goalRecord;
        }

        public async Task UpdateGoalRecord(GoalRecord goalRecord)
        {
            await firebase
                .Child("GoalRecords")
                .Child(goalRecord.Id)
                .PutAsync(goalRecord);
        }

        public async Task DeleteGoalRecord(string firebaseKey)
        {
            await firebase
                .Child("GoalRecords")
                .Child(firebaseKey)
                .DeleteAsync();
        }

    }
}
