namespace MinCosmos.Captcha.Core.Abstracts;

public interface IMineCosmosCaptcha
{
    string GenerateCode(string id);

    bool Validate(string id, string code);
}