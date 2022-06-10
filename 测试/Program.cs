// See https://aka.ms/new-console-template for more information

var r = new Random(Guid.NewGuid().GetHashCode());
char[] 密码字符池 = new char[94]; //字母索引：0-51，数字索引：52-66，字符索引：

for (int i = 0; i < 密码字符池.Length; i++)
{
    if (i < 26)
        密码字符池[i] = (char)(65 + i); //大写字母
    else if (i < 52)
        密码字符池[i] = (char)(97 + i - 26); //小写字母
    else if (i < 62)
        密码字符池[i] = (char)(i - 4); //数字字符
    else if (i < 77)
        密码字符池[i] = (char)(i - 29); //ASCII码：33-47，共15个，数字之前
    else if (i < 84)
        密码字符池[i] = (char)(i - 19); //ASCII码：58-64，共7个，大写字母之前
    else if (i < 90)
        密码字符池[i] = (char)(i + 7); //ASCII码：91-96，共6个，小写字母之前
    else
        密码字符池[i] = (char)(i + 33); //ASCII码：123-126，共4个，小写字母之后
}

var 字母字符临时集合 = new List<char>();
字母字符临时集合.AddRange(密码字符池[0..52]);
字母字符临时集合.AddRange(密码字符池[62..密码字符池.Length]);
char[] 密码字符池_字母_字符 = 字母字符临时集合.ToArray();

foreach (var item in 密码字符池[90..94])
{
    Console.Write($"{item}  ");
}