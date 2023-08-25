using System.Security.Cryptography;
using System.Text;
using System;
namespace L2.Services
{
    public class Cryptography

    {
        private RijndaelManaged rijndael = new RijndaelManaged();
        private byte[] passBytes;
        private byte[] encryptionkeyBytes;

        /// <param name="encryptionKey"></param>
        public Cryptography()
        {
            passBytes = Encoding.UTF8.GetBytes("Secure Compute and Firewall");
        }

        /// <param name="textToEncrypt"></param>
        public string Encrypt(string textToEncrypt)
        {
            SetOperation();

            SetBeginCryptography();

            byte[] textDataByte = Encoding.UTF8.GetBytes(textToEncrypt);

            ICryptoTransform objtransform = rijndael.CreateEncryptor();
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }


        /// <param name="encryptedText"></param>
        public string Decrypt(string encryptedText)
        {
            SetOperation();

            byte[] encryptedTextByte = Convert.FromBase64String(encryptedText);
            encryptionkeyBytes = new byte[0x10];

            SetBeginCryptography();

            byte[] textByte = rijndael.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(textByte);
        }

        private void SetOperation()
        {
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.KeySize = 0x80;
            rijndael.BlockSize = 0x80;
        }

        private void SetBeginCryptography()
        {
            encryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            int len = passBytes.Length;
            if (len > encryptionkeyBytes.Length)
            {
                len = encryptionkeyBytes.Length;
            }

            Array.Copy(passBytes, encryptionkeyBytes, len);

            rijndael.Key = encryptionkeyBytes;
            rijndael.IV = encryptionkeyBytes;
        }
    }
}



