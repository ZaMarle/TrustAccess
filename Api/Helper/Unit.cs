namespace Api.Helper
{
    public class Unit
    {
        private Unit()
        {
            // Private constructor to ensure only one instance (similar to a singleton)
        }

        public static Unit New { get; } = new Unit();
    }
}