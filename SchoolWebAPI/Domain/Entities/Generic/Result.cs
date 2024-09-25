namespace SchoolWebAPI.Domain.Entities.Generic
{

    /// <summary>
    /// Result object
    /// </summary>
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="errorMessage">The error message.</param>
        public Result(bool isSuccess, string errorMessage) 
        { 
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Successes this instance.
        /// </summary>
        /// <returns></returns>
        public static Result Success() => new Result(true, string.Empty);

        /// <summary>
        /// Failures the specified error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static Result Failure(string errorMessage) => new Result(false, errorMessage);
    }

    /// <summary>
    /// Result object with T entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        public T Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="value">The value.</param>
        private Result(bool isSuccess, string errorMessage, T value)
        : base(isSuccess, errorMessage)
        {
            Value = value;
        }

        /// <summary>
        /// Successes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Result<T> Success(T value) => new Result<T>(true, string.Empty, value);

        /// <summary>
        /// Failures the specified error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static new Result<T> Failure(string errorMessage) => new Result<T>(false, errorMessage, default);
    }
}
