using PasswordApp.Core;

string filePath = GetFilePath("Passwords.txt");
var text = await FileHelper.ReadFileOrDefaultAsync(filePath);
int count = PasswordParser.ValidatePasswordAsync(text);

Console.WriteLine($"Total number of valid passwords: {count}");

//This method is not part of business logic and only for convenient testing,
//just putting any of your files into "PasswordApp.Core" folder.
//Instead of this method, you can use either path.
static string GetFilePath(string fileName)
{
    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @$"..\..\..\{fileName}");
    string fullPath = Path.GetFullPath(filePath);

    return fullPath;
}