namespace PasswordApp.Core
{
    public static class SpanExtensions
    {
        public static int CountOf(this ReadOnlySpan<char> str, char search)
        {
            int count = 0;

            foreach (char character in str)
            {
                if (character == search)
                    count++;
            }

            return count;
        }
    }
}