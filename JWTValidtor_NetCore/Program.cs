using System;

namespace JWTValidtor_NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length>0)
            {

         
            if (string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]))
            {
                Console.WriteLine("Value is empty ! See help ");
                Console.WriteLine("dotnet JWTValidtor_NetCore.dll \"jwttoken\" PasswordList.txt ");
                return;
            }
            if (args[0].Contains("-h"))
            {
                Console.WriteLine("dotnet JWTValidtor_NetCore.dll \"jwttoken\" PasswordList.txt ");
                return;
            }
           
            JWT jwt = JWT.Instance;
            jwt.FileName = args[1];
            jwt.JWTToken = args[0];
            jwt.Worker();
                Console.ReadKey();
            }
            else Console.WriteLine("Value is empty ! See help -h ");
           
        }
    }
}
