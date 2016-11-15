using JWTnet4._5.Providers;
using SimpleInjector;

namespace JWTnet4._5.App_Start
{
    public static class InversionOfControlConfig
    {
        public static Container GetInitializedContainer()
        {
            var container = new Container();

            container.Register<IApplicationSettingsProvider, ApplicationSettingsProvider>();
            container.Register<IClaimsIdentityProvider, TestClaimsIdentityProvider>();
            //container.Register<ISigningCredentialsProvider, RSASigningCredentialsProvider>();
            container.Register<ISigningCredentialsProvider, HMACSHA256SigningCredentialsProvider>();
            container.Register<IJwtProvider, JwtProvider>();

            return container;
        }
    }
}
