using Ibnt.Server.Application.Interfaces;
using System.Security.Cryptography;

namespace Ibnt.Server.Infra.Services
{
    public class HashService : IHashService
    {
        private const int _saltSize = 16;
        private const int _keySize = 32;
        private const int _iterations = 50000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

        private const char segmentDelimiter = ':';

        public string HashValue(string value)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                value,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );
            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                _iterations,
                _algorithm
            );
        }
        public bool CompareValue(string value, string hashedValue)
        {
            string[] segments = hashedValue.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                value,
                salt,
                iterations,
                algorithm,
                hash.Length
            );
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }

        public string? GenerateVerificationCode(int codeSize)
        {
            var codeBaseString = Guid.NewGuid().ToString().Split("-");
            var breakString = codeBaseString
                .First()
                .Substring(0, codeSize);
            return breakString;
        }
    }
}
