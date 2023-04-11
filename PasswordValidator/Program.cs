using PasswordValidator;
using System.Text;

IParser parser = new Parser();
var filepath = "passwords.txt";

var lines = File.ReadAllLines(filepath);
var errors = new List<string>();
var parsedPasswords = parser.Parse(lines, out errors);

var counter = 0;

foreach(var line in parsedPasswords)
{
    var entries = line.Password.Where(x => x == line.Letter).Count();
    if(entries >= line.MinCount && entries <= line.MaxCount)
        counter++;
}
StringBuilder sb = new StringBuilder();

foreach(var error in errors)
    sb.AppendLine(error);

Console.WriteLine($"Valid passwords count: {counter}");
Console.WriteLine($"Errors: \n{sb}");