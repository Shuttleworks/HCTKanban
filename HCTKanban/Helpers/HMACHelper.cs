using System.Security.Cryptography;
using System.Text;

namespace HCTKanban.Helpers
{
	public class HMACHelper
	{
		private const int SaltSize = 32;

		public static byte[] GenerateSalt()
		{
			
			using (var generator = RandomNumberGenerator.Create())
			{
				var salt = new byte[SaltSize];
				generator.GetBytes(salt);
				return salt;
			}
			
		}

		public static byte[] ComputeHMAC_SHA256(byte[] data, byte[] salt)
		{
			using (var hmac = new HMACSHA256(salt))
			{
				return hmac.ComputeHash(data);
			}
		}
	}
}
