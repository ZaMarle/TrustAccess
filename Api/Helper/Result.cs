namespace Api.Helper
{
    public class Result<T>
    {

        private readonly T value;
        private readonly string error;
        private readonly bool isSuccess;
    
        private Result(T value, string error, bool isSuccess)
        {
            this.value = value;
            this.error = error;
            this.isSuccess = isSuccess;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value, default, true);
        }

        public static Result<T> Err(string error)
        {
            return new Result<T>(default, error, false);
        }

        public bool IsOk()
        {
            return isSuccess;
        }

        public bool IsErr()
        {
            return !isSuccess;
        }

        public TResult Match<TResult>(Func<T, TResult> ok, Func<string, TResult> err)
        {
            if (IsOk())
            {
                return ok(value);
            }
            else
            {
                return err(error);
            }
        }

        public void Match(Action<T> ok, Action<string> err)

        {
            if (IsOk())
            {
                ok(value);
            }
            else
            {
                err(error);
            }
        }

        // public T Unwrap()
        // {
        //     if (IsOk())
        //     {
        //         return value;
        //     }
        //     throw new InvalidOperationException("Cannot unwrap error value");
        // }

        // public string UnwrapErr()
        // {
        //     if (IsErr())
        //     {
        //         return error;
        //     }
        //     throw new InvalidOperationException("Cannot unwrap value");
        // }
    }
}