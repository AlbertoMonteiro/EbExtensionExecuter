using System.IO.Compression;
using System.Net;
using static System.ConsoleColor;
using static System.IO.Path;
using static EbExtensionExecuter.Helpers.ColoredConsole;

namespace EbExtensionExecuter.Steps
{
    public class DownloadFile : IStep
    {
        private readonly string _folderToPlaceDownload;
        private readonly string _url;
        private bool _shouldUnZip;

        public DownloadFile(string folderToPlaceDownload, string url)
        {
            _folderToPlaceDownload = folderToPlaceDownload;
            _url = url;
        }

        public DownloadFile AlsoUnZip()
        {
            _shouldUnZip = true;
            return this;
        }

        public bool Execute()
        {
            WriteLine($"===== Download file: {_url} =====", Yellow);
            var webClient = new WebClient();

            var fileName = Combine(_folderToPlaceDownload, GetFileName(_url));

            WriteLine("Downloading file");
            webClient.DownloadFile(_url, fileName);
            WriteLine("File downloaded");

            if (_shouldUnZip)
            {
                WriteLine($"Unziping {fileName} in: _folderToPlaceDownload");
                ZipFile.Open(fileName, ZipArchiveMode.Read).ExtractToDirectory(_folderToPlaceDownload);
                WriteLine($"File unziped");
            }

            WriteLine($"===== End Download file: {_url} =====", Yellow);
            return true;
        }
    }
}