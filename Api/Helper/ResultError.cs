namespace Api.Helper
{
    public class ResultError
    {
        // TODO: Value should be an option?
        public string Value { get; set; } = "";

        private ResultError(string error)
        {
            Value = error;
        }

        public static ResultError New(string error)
        {
            return new ResultError(error);
        }
    }
}
