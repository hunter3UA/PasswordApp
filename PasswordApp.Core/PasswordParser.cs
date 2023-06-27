namespace PasswordApp.Core
{
    public class PasswordParser
    {
        public static int ValidatePasswordAsync(List<string>? lines)
        {
            int validPasswords = 0;

            lines?.ForEach(line =>
            {
                validPasswords += ParseLine(line);
            });

            return validPasswords;
        }

        private static int ParseLine(ReadOnlySpan<char> input)
        {
            try
            {
                int indexOfColon = input.IndexOf(':');
                int indexOfDash = input.IndexOf('-');
                int indexOfSpace = input.IndexOf(" ");

                if (indexOfColon < 0)
                    return 0;

                char symbolToSearch = input[indexOfSpace - 1];
                var password = input.Slice(indexOfColon + 1);
                ParseNumbers(input, indexOfDash, indexOfColon, indexOfSpace, out int firstNumber, out int secondNumber);

                int numberOfChar = password.CountOf(symbolToSearch);

                return firstNumber <= numberOfChar && secondNumber >= numberOfChar ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return 0;
            }
        }

        private static void ParseNumbers(
            ReadOnlySpan<char> input,
            int indexOfDash,
            int indexOfColon,
            int indexOfSpace,
            out int firstNumber,
            out int secondNumber)
        {
            if (indexOfDash != -1)
            {
                int.TryParse(input.Slice(2, indexOfDash - 2), out firstNumber);
                int.TryParse(input.Slice(indexOfDash + 1, indexOfColon - indexOfDash - 1), out secondNumber);
            }
            else
            {
                int.TryParse(input.Slice(indexOfSpace, indexOfColon - 1), out firstNumber);
                secondNumber = firstNumber;
            }
        }

    }
}