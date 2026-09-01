using HashApp;



if (args.Length == 1)
{
    string? firstPath = HashCalculator.GetValidPathFromArgs(args[0]);
    if (firstPath == null)
    {
        Console.WriteLine($"Error: File '{args[0]}' does not exist.");
        return;
    }
    var firstHashedFile = HashCalculator.ComputeSHA256(firstPath);
    DisplayHash(firstPath, firstHashedFile);

    string secondPath = ReadValidFilePath("Enter the location of second file: ");
    var secondHashedFile = HashCalculator.ComputeSHA256(secondPath);
    DisplayHash(secondPath, secondHashedFile);

    bool status = HashCalculator.Compare(firstHashedFile, secondHashedFile);
    DisplayCompareResult(status);
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
            return;
        }

        hashes[i] = HashCalculator.ComputeSHA256(path);
        DisplayHash(path, hashes[i]);
    }

    Console.WriteLine();
    DisplayCompareResult(HashCalculator.Compare(hashes));
    return;
}
else if (args.Length == 0)
{
    byte choice = (byte)ReadInt("Choose an option: \n1. Compare 2 copied hashes \n2. Compare with file path \n3. Compute one file \nChoice: ");

    switch (choice)
    {
        case 1:
            string firstHash = ReadString("Enter the first hash: ");
            string secondHash = ReadString("Enter the second one: ");
            DisplayCompareResult(HashCalculator.Compare(firstHash, secondHash));
            break;
        case 2:
            string firstPath = ReadValidFilePath("Enter the location of first file: ");
            var firstHashedFile = HashCalculator.ComputeSHA256(firstPath);
            DisplayHash(firstPath, firstHashedFile);

            string secondPath = ReadValidFilePath("Enter the location of second file: ");
            var secondHashedFile = HashCalculator.ComputeSHA256(secondPath);
            DisplayHash(secondPath, secondHashedFile);

            DisplayCompareResult(HashCalculator.Compare(firstHashedFile, secondHashedFile));
            break;
        case 3:
            string filePath = ReadValidFilePath("Enter the location of file: ");
            var hashed = HashCalculator.ComputeSHA256(filePath);
            DisplayHash(filePath, hashed);
            break;
    }
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