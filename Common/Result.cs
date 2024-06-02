namespace TripAPI.Common
{
    public class Result<T> : Result
    {
        public Result(T value) { Value = value; }
        public Result(ErrorMessage errorMessage) : base(errorMessage) { }
        public T? Value { get; private set; }
    }

    public class Result(ErrorMessage? message = null)
    {
        public ErrorMessage? ErrorMessage { get; protected set; } = message;
    }

    public struct ErrorMessage(string value)
    {
        public string Value { get; set; } = value;
    }
}
