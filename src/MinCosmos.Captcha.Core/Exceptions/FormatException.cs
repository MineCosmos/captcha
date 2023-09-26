namespace MinCosmos.Captcha.Core;

public class FormatException : Exception
{
    public FormatException(string message = "格式转换错误") : base(message)
    {

    }
}
