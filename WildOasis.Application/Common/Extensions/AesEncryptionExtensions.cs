using System.Security.Cryptography;
using System.Text;

namespace WildOasis.Application.Common.Extensions;

public static class AesEncryptionExtensions
{
    
        public static string Encrypt(this string text, string key)// dodali smo this sto znaci da je to extension i da je mozemo pozvati na bilo kojem strigu 
        {
            byte[] iv = new byte[16];//pravi se niz koji ce sadrzti 16 bajtova
            byte[] array;//pravimo array u kojem ce se nalaziti nasa sifrovana rijec
            
            using (Aes aes = Aes.Create()) //koristimo using da se cim se zavrsi 
            {
                aes.Key = key.GenerateSha256();//kljuc se generise na strigu key
                aes.IV = iv;
                
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);//Stvara se kriptografski transformator (ICryptoTransform) za enkripciju korištenjem ključa i inicijalizacijskog vektora.
                
                using (MemoryStream memoryStream = new MemoryStream())//stvarano memoriski tok u kojem ce biti nas kljuc
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        //koristi se crypto tok za pohranu sofrovanih podataka koji koirsiti memorySystem
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(text);
                        }
                        //gore navedeni blok sluzi da se pise kriptovani teks
                        
                        array = memoryStream.ToArray();
                        //ubacuje se u niz koji smo vec definisali memoryStrema u kojem se nalazi nas kriptovan string
                    }
                }
            }
            
            return Convert.ToBase64String(array); //dohvata sifrovani teks i pretvara ga u base64 string
        }
        
    


        public static string Decrypt(this string cipherText, string key)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key.GenerateSha256();
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key,
                    aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream,
                               decryptor,
                               CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

  

        private static byte[] GenerateSha256(this string text) => SHA256.HashData(Encoding.UTF8.GetBytes(text));
        //sa gore navedeom metodom generisemo SHA256 za bilo koji string
    }
