using System;
using System.IO.Compression;

namespace Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("zipFile.zip", ZipArchiveMode.Create);
            // ZipFile zipFile = ZipFile.ExtractToDirectory(zipPath, extractPath);
            ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile("output.txt", "outputEntry.txt");

        }
    }
}
