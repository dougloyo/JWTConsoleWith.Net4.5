using System.IdentityModel.Tokens;

namespace JWTnet4._5
{
    public interface ISigningCredentialsProvider
    {
        SigningCredentials GetSigningCredentials();
    }
}
