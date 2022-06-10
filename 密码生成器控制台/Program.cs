// See https://aka.ms/new-console-template for more information
using static 密码生成器控制台.Password;
using Spectre.Console;

string copyRight = "开发名单：苏扬\n开发平台：.NET 6.0\n开发时间：2022年6月2日";
string hint = "强密码提示：大小写字母+数字+字符，建议密码长度：8-20";
Console.WriteLine($"{copyRight}\n{hint}\n");

while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("输入密码长度：");
    Console.ForegroundColor = ConsoleColor.Gray;
    int.TryParse(Console.ReadLine() ?? string.Empty, out int passwordLength);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("选择密码类型：");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write("1. 仅字母\n2. 字母 + 数字\n3. 字母 + 符号\n4. 字母 + 数字 + 符号\n");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("输入序号并回车：");
    Console.ForegroundColor = ConsoleColor.Gray;
    int.TryParse(Console.ReadLine() ?? string.Empty, out int pwdTypeSelect);

    PwdType pwdType = pwdTypeSelect switch
    {
        1 => PwdType.Letters,
        2 => PwdType.LettersAndDigits,
        3 => PwdType.LettersAndSymbols,
        4 => PwdType.All,
        _ => PwdType.None
    };

    string password = GetPassword(passwordLength, pwdType);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{password}\n");
    Console.ForegroundColor = ConsoleColor.Gray;
}
