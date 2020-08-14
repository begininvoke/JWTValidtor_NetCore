using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jwt;
using Microsoft.CodeAnalysis;
namespace JWTValidtor_NetCore
{

   
    class JWT
    {
        private static JWT instance = null;
        public string JWTToken { get; set; }

        List<string> listpasswords = new List<string>();
		public string FileName { get; set; }
		public JWT()
        {

        }
        public static JWT Instance
        {
            get
            {
                if (instance==null)
				{
                    instance = new JWT();
                }
                return instance;
            }

        }

		public void Worker()
		{
			Console.WriteLine("Github && twitter : @begininvoke");
			listpasswords.AddRange(System.IO.File.ReadAllLines(FileName).ToList());
			BruteForce(JWTToken);
		}
		private void BruteForce(string Token)
		{
			if (!string.IsNullOrEmpty(Token))
			{
				JWTToken =Token;
				foreach (var item in listpasswords)
				{
					var ret = invalidnew(item);
					if (ret)
					{
						Console.WriteLine( "Password Find " + item);
						
						return;
					}
					else
						Console.WriteLine("Faild " + item);
				}
			}
			else
			{
				Console.WriteLine("Jwt is Empty!");
				return;
			}
		}
		public bool invalidnew(string secret)
		{


			try
			{
				string jsonPayload = Jwt.JsonWebToken.Decode(JWTToken, secret);

				return true;
			}
			catch
			{


			}
			return false;
		}
	}
}
