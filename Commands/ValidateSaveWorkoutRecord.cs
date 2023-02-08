namespace ExerciseApplicationService.Commands
{
    public class ValidateSaveWorkoutRecord
    {
        private Dictionary<string, object> payloadDictionary;
        public Dictionary<string, List<string>> Errors { get; private set; }

        public ValidateSaveWorkoutRecord(Dictionary<string, object> payload)
        {
            this.payloadDictionary = payload;
            this.Errors = new Dictionary<string, List<string>>();
            Errors.Add("Id", new List<string>());
            Errors.Add("Date", new List<string>());
            Errors.Add("StartTime", new List<string>());
            Errors.Add("EndTime", new List<string>());
        }

        public bool HasErrors()
        {
            bool answer = false;

            if (Errors["Id"].Count > 0)
            {
                answer = true;
            }

            if (Errors["Date"].Count > 0)
            {
                answer = true;
            }

            if (Errors["StartTime"].Count > 0)
            {
                answer = true;
            }

            if (Errors["EndTime"].Count > 0)
            {
                answer = true;
            }

            return answer;
        }

        public bool NoErrors()
        {
            return !HasErrors();
        }

        public void ValidateSave()
        {
            if (!payloadDictionary.ContainsKey("Date"))
            {
                Errors["Date"].Add("Please Enter what date you exercise!");
            }

            if (!payloadDictionary.ContainsKey("StartTime"))
            {
                Errors["StartTime"].Add("Please Enter the start time of your exercise!");
            }

            if (!payloadDictionary.ContainsKey("EndTime"))
            {
                Errors["EndTime"].Add("Please Enter the end time of your exercise!");
            }
        }
    }
}

// public int Id {get; set;}
//     public DateTime Date {get; set;}
//     public DateTime StartTime {get; set;}
//     public DateTime EndTime {get; set;}
//     public List<ExerciseData> ExerciseDatas {get; set;}