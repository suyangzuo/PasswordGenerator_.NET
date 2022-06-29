namespace 密码生成器控制台.PasswordTools
{
    public static class Password
    {
        [Flags]
        public enum PwdType
        {
            None = 0,
            //Decimal     //Binary
            Letters = 1,  //0000 0001
            Digits = 2,   //0000 0010
            Symbols = 4,  //0000 0100
            LettersAndDigits = Letters | Digits,
            LettersAndSymbols = Letters | Symbols,
            All = Letters | Digits | Symbols
        }

        public static char[] PwdCharPool = new Func<char[]>(() =>
        {
            var r = new Random(Guid.NewGuid().GetHashCode());
            var pwdCharPool = new char[94];

            for (int i = 0; i < pwdCharPool.Length; i++)
            {
                pwdCharPool[i] = i switch
                {
                    < 10 => (char)(i + 48), //ASCII：48-57，数字
                    < 36 => (char)(i + 55), //ASCII：65-90，大写字母
                    < 62 => (char)(i + 61), //ASCII：97-122，小写字母
                    < 77 => (char)(i - 29), //ASCII：33-47，共15个字符，数字之前
                    < 84 => (char)(i - 19), //ASCII：58-64，共7个字符，大写字母之前
                    < 90 => (char)(i + 7),  //ASCII：91-96，共6个字符，小写字母之前
                    _ => (char)(i + 33)     //ASCII：123-126，共4个字符，小写字母之后
                };
            }
            return pwdCharPool;
        })();

        public static string GetPassword(int length, PwdType pwdType)
        {
            var r = new Random(Guid.NewGuid().GetHashCode());
            var pwdCharPool = new char[94];

            for (int i = 0; i < pwdCharPool.Length; i++)
            {
                pwdCharPool[i] = i switch
                {
                    < 10 => (char)(i + 48), //ASCII：48-57，数字
                    < 36 => (char)(i + 55), //ASCII：65-90，大写字母
                    < 62 => (char)(i + 61), //ASCII：97-122，小写字母
                    < 77 => (char)(i - 29), //ASCII：33-47，共15个字符，数字之前
                    < 84 => (char)(i - 19), //ASCII：58-64，共7个字符，大写字母之前
                    < 90 => (char)(i + 7),  //ASCII：91-96，共6个字符，小写字母之前
                    _ => (char)(i + 33)     //ASCII：123-126，共4个字符，小写字母之后
                };
            }

            var pwdCharRandom = new char[length];

            for (int i = 0; i < length; i++)
            {
                pwdCharRandom[i] = pwdType switch
                {
                    PwdType.Letters => pwdCharPool[r.Next(10, 62)],
                    PwdType.LettersAndDigits => pwdCharPool[r.Next(0, 62)],
                    PwdType.LettersAndSymbols => pwdCharPool[r.Next(10, pwdCharPool.Length)],
                    PwdType.All => pwdCharPool[r.Next(0, pwdCharPool.Length)],
                    _ => '\0'
                };
            }

            return string.Join(null, pwdCharRandom);
        }
    }
}
