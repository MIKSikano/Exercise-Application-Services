namespace ExerciseApplicationService.Commands 
{
    public class ValidateSaveExerciseType
    {
        private Dictionary<string, object> payloadDictionary;
        public Dictionary<string, List<string>> Errors {get; private set;}

        public ValidateSaveExerciseType(Dictionary<string, object> payload)
        {
            this.payloadDictionary = payload;
            this.Errors = new Dictionary<string, List<string>>();
            Errors.Add("Id", new List<string>());
            Errors.Add("ExerciseName", new List<string>());
            Errors.Add("ExerciseDescription", new List<string>());
        }

        public bool HasErrors()
        {
            bool answer = false;

            if(Errors["Id"].Count > 0)
            {
                answer = true;
            } 

            if(Errors["ExerciseName"].Count > 0)
            {
                answer = true;
            }

            if(Errors["ExerciseDescription"].Count > 0)
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
            if(!payloadDictionary.ContainsKey("ExerciseName"))
            {
                Errors["ExerciseName"].Add("Please Enter your Exercise Type!");
            }

            if(!payloadDictionary.ContainsKey("ExerciseDescription"))
            {
                Errors["ExerciseDescription"].Add("Please Enter the Description of your Exercise!");
            }
        }
    }
}