// See https://aka.ms/new-console-template for more information
using static 密码生成器控制台.PasswordTools.Password;

while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Input password length: ");
    Console.ForegroundColor = ConsoleColor.Gray;
    int.TryParse(Console.ReadLine() ?? string.Empty, out int passwordLength);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Choose password type: ");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write("1. Letters\n2. Letters + Digits\n3. Letters + Symbols\n4. Letters + Digits + Symbols\n");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Input number and press enter: ");
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
