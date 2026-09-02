using System;
using System.IO;
using HashApp;

if (args.Length == 1)
{
    string? firstPath = HashCalculator.GetValidPathFromArgs(args[0]);
    if (firstPath == null)
    {
        Console.WriteLine($"Error: File '{args[0]}' does not exist.");
        WaitAndExit();
        return;
    }

    string firstHash = HashCalculator.ComputeSHA256(firstPath);
    DisplayHash(firstPath, firstHash);

    Console.WriteLine("\n[Options] Enter a 2nd file path OR paste a Hash to compare (Press Enter to exit):");
    Console.Write("Input: ");
    string? secondInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(secondInput))
    {
        return;
    }

    string cleanInput = secondInput.Trim().Trim('"');

    if (File.Exists(cleanInput))
    {
        string secondHash = HashCalculator.ComputeSHA256(cleanInput);
        DisplayHash(cleanInput, secondHash);
        DisplayCompareResult(HashCalculator.Compare(firstHash, secondHash));
    }
    else
    {
        string targetHash = HashCalculator.CleanHash(cleanInput);
        Console.WriteLine($"\nTarget Hash: {targetHash}");
        DisplayCompareResult(HashCalculator.Compare(firstHash, targetHash));
    }

    WaitAndExit();
    return;
}

else if (args.Length >= 2)
{
    string[] hashes = new string[args.Length];

    for (int i = 0; i < args.Length; i++)
    {
        string? path = HashCalculator.GetValidPathFromArgs(args[i]);
        if (path == null)
        {
            Console.WriteLine($"Error: File '{args[i]}' does not exist.");
            WaitAndExit();
            return;
        }

        hashes[i] = HashCalculator.ComputeSHA256(path);
        DisplayHash(path, hashes[i]);
    }

    Console.WriteLine();
    DisplayCompareResult(HashCalculator.Compare(hashes));

    WaitAndExit();
    return;
}

else if (args.Length == 0)
{
    while (true)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("           HASH CALCULATOR              ");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Compare 2 copied hashes");
        Console.WriteLine("2. Compare 2 files");
        Console.WriteLine("3. Compare 1 file with a copied hash");
        Console.WriteLine("4. Compute single file hash");
        Console.WriteLine("5. Exit");

        int choice = ReadInt("\nChoice: ");
        Console.WriteLine();

        switch (choice)
        {
            case 1:
                string firstHash = HashCalculator.CleanHash(ReadString("Enter 1st hash: "));
                string secondHash = HashCalculator.CleanHash(ReadString("Enter 2nd hash: "));
                DisplayCompareResult(HashCalculator.Compare(firstHash, secondHash));
                break;

            case 2:
                string path1 = ReadValidFilePath("Enter path of 1st file: ");
                var hash1 = HashCalculator.ComputeSHA256(path1);
                DisplayHash(path1, hash1);

                string path2 = ReadValidFilePath("Enter path of 2nd file: ");
                var hash2 = HashCalculator.ComputeSHA256(path2);
                DisplayHash(path2, hash2);

                DisplayCompareResult(HashCalculator.Compare(hash1, hash2));
                break;

            case 3:
                string targetFilePath = ReadValidFilePath("Enter file path: ");
                var computedFileHash = HashCalculator.ComputeSHA256(targetFilePath);
                DisplayHash(targetFilePath, computedFileHash);

                string copiedHash = HashCalculator.CleanHash(ReadString("Paste the expected hash: "));
                DisplayCompareResult(HashCalculator.Compare(computedFileHash, copiedHash));
                break;

            case 4:
                string singlePath = ReadValidFilePath("Enter file path: ");
                var singleHash = HashCalculator.ComputeSHA256(singlePath);
                DisplayHash(singlePath, singleHash);
                break;

            case 5:
                return;

            default:
                Console.WriteLine("Invalid choice. Please choose 1 to 5.");
                break;
        }

        Console.WriteLine("\n");
    }
}

static void WaitAndExit()
{
    Console.WriteLine("\nPress any key to exit...");
    Console.ReadKey();
}




static int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("You've Entered an invalid number! Try again.\n");
        }
    }
}

static string ReadString(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? text = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(text))
        {
            return text;
        }
        else
        {
            Console.WriteLine("Please enter a valid text.\n");
        }
    }
}


static void DisplayHash(string file, string hash) =>
            Console.WriteLine($"File: {Path.GetFileName(file)} \nSHA256 Hash: {hash}");

static void DisplayCompareResult(bool isMatch) => Console.WriteLine(isMatch ? "The files are identical." : "The files are different.");


static string ReadValidFilePath(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Path can't be empty.");
            continue;
        }

        string cleanPath = input.Trim('"');
        if (File.Exists(cleanPath))
        {
            return cleanPath;
        }
        else
        {
            Console.WriteLine($"File not found at {cleanPath}. Please try again. \n");
        }
    }
}

static string CleanHash(string rawHash)
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