using System;
using System.IO;
using System.Security.Cryptography;

namespace HashApp;

public static class HashCalculator
{
    public static string ComputeSHA256(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        using var stream = File.OpenRead(filePath);
        byte[] hashBytes = SHA256.HashData(stream);
        return Convert.ToHexString(hashBytes);
    }

    public static string? GetValidPathFromArgs(string rawPath)
    {
        if (string.IsNullOrWhiteSpace(rawPath))
            return null;

        string cleanPath = rawPath.Trim().Trim('"');
        return File.Exists(cleanPath) ? cleanPath : null;
    }

    public static string CleanHash(string rawHash)
    {
        if (string.IsNullOrWhiteSpace(rawHash))
            return string.Empty;

        string clean = rawHash.Trim().Trim('"');

        if (clean.StartsWith("sha256:", StringComparison.OrdinalIgnoreCase))
            clean = clean["sha256:".Length..].Trim();
        else if (clean.StartsWith("sha-256:", StringComparison.OrdinalIgnoreCase))
            clean = clean["sha-256:".Length..].Trim();

        int spaceIndex = clean.IndexOf(' ');
        if (spaceIndex > 0)
            clean = clean[..spaceIndex].Trim();

        return clean;
    }

    public static bool Compare(params string[] hashes)
    {
        if (hashes == null || hashes.Length < 2)
            return false;

        string firstHash = CleanHash(hashes[0]);

        for (int i = 1; i < hashes.Length; i++)
        {
            string currentHash = CleanHash(hashes[i]);
            if (!string.Equals(firstHash, currentHash, StringComparison.OrdinalIgnoreCase))
                return false;
        }

        return true;
    }
}