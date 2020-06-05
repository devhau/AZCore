using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AZCore.Utility
{
    public static class AzHash
	{
		public static string CreatePassword(string value, string salt)
		{
			var valueBytes = KeyDerivation.Pbkdf2(
								password: value,
								salt: Encoding.UTF8.GetBytes(salt),
								prf: KeyDerivationPrf.HMACSHA512,
								iterationCount: 10000,
								numBytesRequested: 256 / 8);

			return Convert.ToBase64String(valueBytes);
		}

		public static bool ValidatePassword(string value, string salt, string hash)
			=> CreatePassword(value, salt) == hash;
		public static string CreateSalt()
		{
			byte[] randomBytes = new byte[128 / 8];
			using (var generator = RandomNumberGenerator.Create())
			{
				generator.GetBytes(randomBytes);
				return Convert.ToBase64String(randomBytes);
			}
		}
		public static string ToHex(this byte[] bytes, bool upperCase=false)
		{
			StringBuilder result = new StringBuilder(bytes.Length * 2);
			for (int i = 0; i < bytes.Length; i++)
				result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
			return result.ToString();
		}

		public static string ToSHA256HexHash(this string StringIn)
		{
			string hashString;
			using (var sha256 = SHA256.Create())
			{
				var hash = sha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
				hashString = hash.ToHex();
			}

			return hashString;
		}
		public static string ToHMACSHA256HexHash(this string StringIn, string secret)
		{
			string hashString;
			using (var sha256 = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
			{
				var hash = sha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
				hashString = hash.ToHex();
			}

			return hashString;
		}
	}
}
