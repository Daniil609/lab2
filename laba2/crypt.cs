using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace laba2
{
    class crypt
    {

        const string archivePath = "C:\\Target_Text\\Archive";
        public static (string, string) CryptFile(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);
            for (int i = 0; i < fileBytes.Length; i++)
            {
                fileBytes[i] ^= 1;
            }


            string newPath = path.EndsWith(".crypt") ? path.Remove(path.LastIndexOf(".crypt")) : path + ".crypt";
            string newName = newPath.Split((char)92)[newPath.Split((char)92).Length - 1];
            File.WriteAllBytes(newPath, fileBytes);
            return (newPath, newName);
        }


        public static void DecryptFile(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);
            for (int i = 0; i < fileBytes.Length; i++)
            {
                fileBytes[i] ^= 1;
            }
            string newPath = path.EndsWith(".txt") ? path.Remove(path.LastIndexOf(".txt")) + "(Decrypted).txt" : path + "(Decrypted).txt";
            File.WriteAllBytes(newPath, fileBytes);
        }

    }
}
