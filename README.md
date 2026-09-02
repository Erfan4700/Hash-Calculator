<p align="center">
  <img src="HashCalculator/hsh.ico" width="120" height="120" alt="HashCalculator Logo">
</p>

<h1 align="center">⚡ HashCalculator</h1>

<p align="center">
  An ultra-lightweight, blazing-fast, and cross-platform CLI tool to compute and compare <b>SHA-256</b> checksums of files and text strings, built with modern <b>C# & .NET Native AOT</b>.
</p>

---


# ⚡ HashCalculator

A ultra-lightweight, blazing-fast, and cross-platform CLI tool to compute and compare **SHA-256** checksums of files and text strings, built with modern **C# & .NET Native AOT**.

---

## ✨ Features

- 🚀 **Native AOT Compiled:** Standalone executable (~1.2 MB) with near-instant startup and zero runtime dependencies (.NET installation is **NOT** required).
- 🛡️ **Defensive & Crash-Proof:** Full input sanitization (handling quotes, extra whitespaces), file presence checks, and proper argument validations.
- 🔁 **Variadic File Comparison (`params`):** Compare 2, 3, or more files simultaneously in a single command.
- 💻 **Cross-Platform:** Pre-built native binaries for Windows, Linux, and macOS (Apple Silicon & Intel).
- 🕹️ **Interactive & CLI Modes:** Works as an interactive wizard when launched directly, or via terminal command-line arguments for scripting.

---

## 📥 Downloads (v1.0.0)

You can download the pre-compiled standalone binary for your OS directly from the table below or via the [**Releases**](https://github.com/Erfan4700/Hash-Calculator/releases/tag/v1.0.0) section:

| Platform | Architecture | File & Direct Download Link | Size | SHA-256 Checksum |
| :--- | :--- | :--- | :--- | :--- |
| **Windows** | x64 (Standard 64-bit) | [HashCalculator-Windows-x64.exe](https://github.com/Erfan4700/Hash-Calculator/releases/download/v1.0.0/HashCalculator-Windows-x64.exe) | `1.30 MB` | `1df0fdb596ce18cc457650864d18a3485095d9520de4c7e85bc173ad37f98d70` |
| **Windows** | x86 (Legacy 32-bit) | [HashCalculator-Windows-x86-32bit.exe](https://github.com/Erfan4700/Hash-Calculator/releases/download/v1.0.0/HashCalculator-Windows-x86-32bit.exe) | `1.16 MB` | `480f2caa9e3a39b41802a36d829f59be12fa7d8f862a49627c16f203f2701d71` |
| **Windows** | ARM64 | [HashCalculator-Windows-ARM64.exe](https://github.com/Erfan4700/Hash-Calculator/releases/download/v1.0.0/HashCalculator-Windows-ARM64.exe) | `1.32 MB` | `d57cb7d84a4c00c6be460e5751f9780b82dda49d0edf605fc8c31c7326601d8d` |
| **Linux** | x64 (Standard Linux) | [HashCalculator-Linux-x64](https://github.com/Erfan4700/Hash-Calculator/releases/download/v1.0.0/HashCalculator-Linux-x64) | `1.30 MB` | `fbf2cb99dfefe73384c62dd2a4202189d6ac63846b4be942c25437d393c5dc94` |
| **Linux** | ARM64 (Raspberry Pi, etc.) | [HashCalculator-Linux-ARM64](https://github.com/Erfan4700/Hash-Calculator/releases/download/v1.0.0/HashCalculator-Linux-ARM64) | `1.38 MB` | `77a683112095264ada0e33b7fffb4d65d6a36f7c2ee4f021a7490ef3a5daa26e` |
| **macOS** | Apple Silicon (M1/M2/M3/M4) | [HashCalculator-macOS-AppleSilicon](https://github.com/Erfan4700/Hash-Calculator/releases/download/v1.0.0/HashCalculator-macOS-AppleSilicon) | `1.18 MB` | `0cedfb8b0066a676184458d5d503589087ec2b293945c729f43f195782f65cea` |
| **macOS** | Intel | [HashCalculator-macOS-Intel](https://github.com/Erfan4700/Hash-Calculator/releases/download/v1.0.0/HashCalculator-macOS-Intel) | `1.20 MB` | `b370975befa7812f1fafa949ea37016da24dc9718ec27e6450d09bc564ef239f` |

---

## 🚀 Usage

### 1. Command Line Mode (CLI)

#### **Compare multiple files directly:**
Pass two or more file paths as arguments to compute and verify if all files match:
```bash
HashCalculator file1.zip file2.zip file3.zip
```

#### **Compare one file with prompt:**
Pass a single file as an argument; the tool calculates its hash and asks for a second file:
```bash
HashCalculator file1.iso
# Output:
# File: file1.iso
# SHA256 Hash: D57CB7D8...
# Enter the location of second file: file2.iso
```

---

### 2. Interactive Menu Mode

Run the binary without any arguments to enter the interactive menu:
```bash
./HashCalculator
```

```text
Choose an option: 
1. Compare 2 copied hashes 
2. Compare with file path 
3. Compute one file 
Choice: 
```

- **Option 1:** Paste two hash strings directly to check for a match (Case-Insensitive).
- **Option 2:** Provide two file paths to compute and compare their hashes.
- **Option 3:** Provide a single file path to compute and print its SHA-256 hash.

---

## 🛠️ Linux & macOS Permission Note

If you download the binary on Linux or macOS, grant execute permissions before running:
```bash
chmod +x HashCalculator-Linux-x64
./HashCalculator-Linux-x64
```

---

## 🔨 Building from Source

To compile the native standalone binary using Native AOT:

1. Make sure [.NET 8.0 SDK or later](https://dotnet.microsoft.com/) is installed with native compilation prerequisites.
2. Clone the repository:
   ```bash
   git clone https://github.com/Erfan4700/Hash-Calculator.git
   cd Hash-Calculator
   ```
3. Publish using Native AOT:
   ```bash
   dotnet publish -c Release -r win-x64 /p:PublishAot=true
   ```
   *(Change `-r win-x64` to `linux-x64`, `osx-arm64`, etc. depending on your target).*

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).
