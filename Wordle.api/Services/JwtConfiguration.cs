namespace Wordle.Api.Services
{
    public class JwtConfiguration
    {
        public string? Secret { get; set; }
        public string? Issuer { get; set; }
    }
}
