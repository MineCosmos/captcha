using System.Runtime.InteropServices;

namespace MinCosmos.Captcha.Core.ExtensionsTypes;

[StructLayout(LayoutKind.Sequential)]
public struct Expiry
{
    private TimeSpan _value;

    public Expiry(string value)
    {
        _value = value.ToTimeSpan();
    }

    public Expiry(int hours, int minutes, int seconds)
    {
        _value = new TimeSpan(hours, minutes, seconds);
    }

    public static Expiry FromSeconds(int seconds)
    {
        return new Expiry(0, 0, seconds);
    }

    public static Expiry FromMinutes(int minutes)
    {
        return new Expiry(0, minutes, 0);
    }

    public static Expiry FromHours(int hours)
    {
        return new Expiry(hours, 0, 0);
    }

    public override string ToString()
    {
        return $"{_value.TotalSeconds}s";
    }

    public TimeSpan GetTimeSpan() => _value;

    public string Value { get => _value.ToString(); set => _value = value.ToTimeSpan(); }
}
