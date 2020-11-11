using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace laba2
{
    class carrier
    {

        public string Source { get; set; }

        public string Target { get; set; }

        public string FileName { get; set; }

        public FileInfo Info { get; set; }



        public carrier(string source, string target, string fileName)
        {
            this.Source = source;
            this.Target = target;
            this.FileName = fileName;
            this.Info = new FileInfo(source + fileName);
        }

        public void addFile()
        {
            string path = this.CreateFolders();
            string newFileName = $"\\Sales_{Info.CreationTime.Year}_{Info.CreationTime.Month}_{Info.CreationTime.Day}_{Info.CreationTime.Hour}" +
                $"_{Info.CreationTime.Minute}_{Info.CreationTime.Second}";
            string fullPath = path + newFileName;
            File.Copy(Source + FileName, fullPath, true);
            File.Delete(Source + FileName);
            (string cryptPath, string cryptName) = crypt.CryptFile(fullPath);
            File.Delete(fullPath);
            string compressSource = compressor.compress(cryptPath, cryptName);
            compressor.Decompress(compressSource, cryptName);
        }


        public string CreateFolders()
        {
            string year = Info.CreationTime.Year.ToString();
            string month = Info.CreationTime.Month.ToString();
            string day = Info.CreationTime.Day.ToString();
            string path = $"{Target}\\{year}\\{month}\\{day}";
            Directory.CreateDirectory(path);
            Directory.CreateDirectory("C:\\Target_Text\\Archive");
            return path;
        }
    }
}
