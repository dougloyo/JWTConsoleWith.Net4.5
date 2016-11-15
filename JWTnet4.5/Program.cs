using System;
using JWTnet4._5.App_Start;
using SimpleInjector;

namespace JWTnet4._5
{
    class Program
    {
        private static readonly Container _container;
        static Program()
        {
            _container = InversionOfControlConfig.GetInitializedContainer();
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" Creating JWT token ");
            Console.ResetColor();

            var jwtProvider = _container.GetInstance<IJwtProvider>();

            var token = jwtProvider.GetToken("someUser", DateTime.Now.AddDays(1));

            Console.WriteLine(token);

            // Validate the Token
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" Validating Token ");
            Console.ResetColor();
            var tokenValid = jwtProvider.ValidateToken(token);
            Console.WriteLine("Token valid="+ tokenValid);


            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" Displaying Claims ");
            Console.ResetColor();

            // Get claims from token.
            if (tokenValid)
            {
                var claimsPrincipal = jwtProvider.GetClaimsPrincipal(token);

                foreach (var claim in claimsPrincipal.Claims)
                    Console.WriteLine(claim.Type + " " + claim.Value);
            }

            Console.WriteLine(" ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" Done ");
            Console.ResetColor();
            Console.WriteLine("Hit any key to close.");
            Console.ReadKey();
        }
    }
}
