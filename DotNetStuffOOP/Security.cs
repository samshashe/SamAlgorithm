using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DotNetStuffOOP
{
    public class Security
    {
        public static void Main1(string[] args)
        {

            //int x = 4, y = 7;
            //func(ref x,y);
            //Console.WriteLine("x="+x+" ,     y="+y);


            string hash = CalculateMD5Hash("abc");
            //Console.WriteLine("MD5 hash          = " + hash);
            //Console.WriteLine("MD5 has with Salt = " + CalculateMD5HashWithSalt("abc"));

            byte[] key = { 145, 12, 32, 245, 98, 132, 98, 214, 6, 77, 131, 44, 221, 3, 9, 50 };
            byte[] iv = { 15, 122, 132, 5, 93, 198, 44, 31, 9, 39, 241, 49, 250, 188, 80, 7 };
            byte[] data = { 1, 2, 3, 4, 5 };
            //SymmetricKeyEncryption(data, key, iv);
            //SymmetricKeyDecryption(key, iv);
            //ASymmetricKeyEncryptionDecryption(data);
            //ASymmetric2();
            DigitalSignature();

            //fail_Click();

            Console.ReadKey();
        }
        // [System.Runtime.InteropServices.DllImportAttribute]
        public static void func(ref int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public static string CalculateMD5Hash(string password)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string CalculateMD5HashWithSalt(string password)
        {
            int SALT_BYTE_SIZE = 8;
            int PBKDF2_ITERATIONS = 1000;
            // Step 1 Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = (new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, PBKDF2_ITERATIONS)).GetBytes(16);

            return Convert.ToBase64String(salt) + Convert.ToBase64String(hash);
            //return PBKDF2_ITERATIONS + ":" +
            //    Convert.ToBase64String(salt) + ":" +
            //    Convert.ToBase64String(hash);
        }

        public static void SymmetricKeyEncryption(byte[] data, byte[] key, byte[] iv)
        {
            // This is what we're encrypting.
            using (SymmetricAlgorithm algorithm = Aes.Create())
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
            using (Stream f = File.Create("encrypted.bin"))
            using (Stream c = new CryptoStream(f, encryptor, CryptoStreamMode.Write))
            {
                c.Write(data, 0, data.Length);
            }

        }

        public static void SymmetricKeyDecryption(byte[] key, byte[] iv)
        {
            byte[] decrypted = new byte[5];
            using (SymmetricAlgorithm algorithm = Aes.Create())
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv))
            using (Stream f = File.OpenRead("encrypted.bin"))
            using (Stream c = new CryptoStream(f, decryptor, CryptoStreamMode.Read))
            {
                for (int b; (b = c.ReadByte()) > -1; )
                {
                    Console.Write(b + " ");
                }
            }
        }

        public static void ASymmetricKeyEncryptionDecryption(byte[] data)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                byte[] encrypted = rsa.Encrypt(data, true);

                foreach (byte b in encrypted)
                    Console.Write(b + " ");
                byte[] decrypted = rsa.Decrypt(encrypted, true);

                Console.WriteLine("\n........................");
                foreach (byte b in decrypted)
                    Console.Write(b + " ");


                File.WriteAllText("PublicKeyOnly.xml", rsa.ToXmlString(false));
                File.WriteAllText("PublicPrivate.xml", rsa.ToXmlString(true));
                rsa.ToString();
            }
        }

        public static void ASymmetric2()
        {
            byte[] data = Encoding.UTF8.GetBytes("Message to encrypt");
            string publicKeyOnly = File.ReadAllText("PublicKeyOnly.xml");
            string publicPrivate = File.ReadAllText("PublicPrivate.xml");
            byte[] encrypted, decrypted;
            using (var rsaPublicOnly = new RSACryptoServiceProvider())
            {
                rsaPublicOnly.FromXmlString(publicKeyOnly);
                encrypted = rsaPublicOnly.Encrypt(data, true);
                // The next line would throw an exception because you need the private
                // key in order to decrypt:
                // decrypted = rsaPublicOnly.Decrypt (encrypted, true);
            }
            using (var rsaPublicPrivate = new RSACryptoServiceProvider())
            {
                // With the private key we can successfully decrypt:
                rsaPublicPrivate.FromXmlString(publicPrivate);
                decrypted = rsaPublicPrivate.Decrypt(encrypted, true);
            }
            Console.WriteLine(Encoding.UTF8.GetString(decrypted));
        }

        public static void DigitalSignature()
        {
            byte[] data = Encoding.UTF8.GetBytes("Message to sign");
            byte[] publicKey;
            byte[] signature;
            object hasher = SHA1.Create(); // Our chosen hashing algorithm.
            // Generate a new key pair, then sign the data with it:
            using (var publicPrivate = new RSACryptoServiceProvider())
            {
                signature = publicPrivate.SignData(data, hasher);
                publicKey = publicPrivate.ExportCspBlob(false); // get public key
            }
            // Create a fresh RSA using just the public key, then test the signature.
            using (var publicOnly = new RSACryptoServiceProvider())
            {
                publicOnly.ImportCspBlob(publicKey);
                Console.Write(publicOnly.VerifyData(data, hasher, signature)); // True
                // Let's now tamper with the data, and recheck the signature:
                data[0] = 0;
                Console.Write(publicOnly.VerifyData(data, hasher, signature)); // False
                // The following throws an exception as we're lacking a private key:
                signature = publicOnly.SignData(data, hasher);
            }
        }

        
    }
}
