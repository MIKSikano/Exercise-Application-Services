namespace ExerciseApplicationService.Commands 
{
    public class ValidateSaveExerciseData
    {
        private Dictionary<string, object> payloadDictionary;
        public Dictionary<string, List<string>> Errors {get; private set;}

        public ValidateSaveExerciseData(Dictionary<string, object> payload)
        {
            this.payloadDictionary = payload;
            this.Errors = new Dictionary<string, List<string>>();
            Errors.Add("Id", new List<string>());
            Errors.Add("CaloriesBurned", new List<string>());
            Errors.Add("CaloriesBurnedGoal", new List<string>());
        }

        public bool HasErrors()
        {
            bool answer = false;

            if(Errors["Id"].Count > 0)
            {
                answer = true;
            } 

            if(Errors["CaloriesBurned"].Count > 0)
            {
                answer = true;
            }

            if(Errors["CaloriesBurnedGoal"].Count > 0)
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
            if(!payloadDictionary.ContainsKey("CaloriesBurned"))
            {
                Errors["CaloriesBurned"].Add("Please Enter your Total Calories Burned!");
            }

            if(!payloadDictionary.ContainsKey("CaloriesBurnedGoal"))
            {
                Errors["CaloriesBurnedGoal"].Add("Please Enter your Calories Burned Goal!");
            }
        }
    }
}