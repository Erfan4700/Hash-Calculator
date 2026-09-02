using System.Security.Cryptography;

namespace HashApp
{
    public static class HashCalculator
    {
        public static string ComputeSHA256(string filePath)
        {
            using var stream = File.OpenRead(filePath);
            byte[] hashBytes = SHA256.HashData(stream);
            string hexStringHash = Convert.ToHexString(hashBytes);
            return hexStringHash;
        }




        public static string? GetValidPathFromArgs(string rawPath)
        {
            string cleanPath = rawPath.Trim('"');
            return File.Exists(cleanPath) ? cleanPath : null;
        }



        public static bool Compare(params string[] hashes)
        {
            if (hashes == null || hashes.Length < 2)
                return false;

            string firstHash = hashes[0];

            for (int i = 1; i < hashes.Length; i++)
            {
                if (!string.Equals(firstHash, hashes[i], StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }

    }
}