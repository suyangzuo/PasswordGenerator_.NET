using 密码生成器控制台.PasswordTools;

public interface PasswordAlgo
{
    public string GetRandomPassword(int length);
}

public class PasswordFactoryAll : PasswordAlgo
{
    public string GetRandomPassword(int length)
    {
        var pwdCharRandom = new char[length];
        var r = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < length; i++)
        {
            pwdCharRandom[i] = Password.PwdCharPool[r.Next(0, Password.PwdCharPool.Length)];
        }
        return string.Join(null, pwdCharRandom);
    }
}

public class PasswordFactoryLD : PasswordAlgo
{
    public string GetRandomPassword(int length)
    {
        var pwdCharRandom = new char[length];
        var r = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < length; i++)
        {
            pwdCharRandom[i] = Password.PwdCharPool[r.Next(0, 62)];
        }
        return string.Join(null, pwdCharRandom);
    }
}

public class PasswordFactoryLS : PasswordAlgo
{
    public string GetRandomPassword(int length)
    {
        var pwdCharRandom = new char[length];
        var r = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < length; i++)
        {
            pwdCharRandom[i] = Password.PwdCharPool[r.Next(10, Password.PwdCharPool.Length)];
        }
        return string.Join(null, pwdCharRandom);
    }
}

public class PasswordFactoryL : PasswordAlgo
{
    public string GetRandomPassword(int length)
    {
        var pwdCharRandom = new char[length];
        var r = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < length; i++)
        {
            pwdCharRandom[i] = Password.PwdCharPool[r.Next(10, 62)];
        }
        return string.Join(null, pwdCharRandom);
    }
}