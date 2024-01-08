namespace Api.Helper
{
    public class Option<T> where T : class
    {
        private T? _content = null;

        public static Option<T> Some(T obj) => new() { _content = obj };
        public static Option<T> None() => new();
        
        public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class => 
            _content is null ? Option<TResult>.None() : Option<TResult>.Some(map(_content));

        public T Reduce(T @default) => _content ?? @default;

        public override bool Equals(object? other) => this.Equals(other as Option<T>);
        public bool Equals(Option<T>? other) =>
            other is null 
                ? false
                : _content?.Equals(other._content) 
                    ?? false;

    }
}
