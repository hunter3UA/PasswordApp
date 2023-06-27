namespace PasswordApp.Core
{
    public static class FileHelper
    {
        public static async Task<List<string>?> ReadFileOrDefaultAsync(string? filePath)
        {

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File with such path: '{filePath}' does not exist");

                return null;
            }

            var lines = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    lines.Add(line!);
                }
            }

            return lines;
        }
    }
}