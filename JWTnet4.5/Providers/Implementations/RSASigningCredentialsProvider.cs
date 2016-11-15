using System.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace JWTnet4._5
{
    public class RSASigningCredentialsProvider : ISigningCredentialsProvider
    {
        public SigningCredentials GetSigningCredentials()
        {
            // Load the key we are going to use.
            var keyParameters = RSAKeyUtils.GetKeyParameters("rsaKey.json");

            var provider = new RSACryptoServiceProvider(2048);
            provider.ImportParameters(keyParameters);

            var key = new RsaSecurityKey(provider);
            return new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature, SecurityAlgorithms.Sha256Digest);
        }
    }
}