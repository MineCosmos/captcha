using MinCosmos.Captcha.Core;
using MinCosmos.Captcha.Core.ExtensionsTypes;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace MineCosmos.Captcha.Core.Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;
    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        var opts = new CaptchaOption();
        opts.Expiry = new Expiry("6s");

        var res = JsonConvert.SerializeObject(opts);

    }

    [Fact]
    public void Test2()
    {
        var json = @"{""Expiry"":""6s""}";

        var opts = JsonConvert.DeserializeObject<CaptchaOption>(json);

    }
}