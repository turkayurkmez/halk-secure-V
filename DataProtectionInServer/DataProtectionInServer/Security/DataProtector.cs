using System.Security.Cryptography;
using System.Text;

namespace DataProtectionInServer.Security
{
    public class DataProtector
    {
        /*
         * Uygulamanızın koştuğu sunucuya güvenmeyin!
         * 
         * XML ya da JSON konfigurasyon dosylaraını ya da gizli ve kritik bilgileri sunucu üzerinde kriptolayın!
         * Pa$$w0rd
         * 
         */
        private string path;
        private byte[] enthropy;

        public DataProtector(string path)
        {
            this.path = path;
            enthropy = new byte[16];
            enthropy = RandomNumberGenerator.GetBytes(16);

        }

        public int EncryptData(string secretData)
        {
            //Bir girdiyi şifrelemek:
            var encoded = Encoding.UTF8.GetBytes(secretData);
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            int length = encryptedDataToFile(encoded, enthropy, DataProtectionScope.CurrentUser, fileStream);
            fileStream.Close();
            return length;
        }

        private int encryptedDataToFile(byte[] encoded, byte[] enthropy, DataProtectionScope currentUser, FileStream fileStream)
        {
            byte[] encrypted = ProtectedData.Protect(encoded, enthropy, currentUser);
            int outputLength = 0;

            if (fileStream.CanWrite && encrypted != null)
            {
                fileStream.Write(encrypted, 0, encrypted.Length);
                outputLength = encrypted.Length;
            }

            return outputLength;

        }

        public string DecryptData(int length)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            byte[] decrypt = decryptDataFromFile(fileStream, enthropy, DataProtectionScope.CurrentUser, length);
            fileStream.Close();
            return Encoding.UTF8.GetString(decrypt);
        }

        private byte[] decryptDataFromFile(FileStream fileStream, byte[] enthropy, DataProtectionScope currentUser, int length)
        {
            byte[] input = new byte[length];
            byte[] output = new byte[length];

            if (fileStream.CanRead)
            {
                fileStream.Read(input, 0, input.Length);

                output = ProtectedData.Unprotect(input, enthropy, currentUser);
            }
            return output;
        }
    }
}
