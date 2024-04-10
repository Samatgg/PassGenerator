using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PassGeneratorTests
{
    public class PasswordGenerator
    {
        private List<string> previousPasswords = new List<string>();

        public string GenerateUniquePassword(int length, bool includeSimilarChars, bool includeSpecialChars)
        {
            string newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);

            while (previousPasswords.Contains(newPassword))
            {
                newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);
            }

            previousPasswords.Add(newPassword);

            return newPassword;
        }

        public string GeneratePassword(int length, bool includeSimilarChars, bool includeSpecialChars)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (!includeSimilarChars)
            {
                chars = chars.Replace("iIlLoO", "");
            }

            if (!includeSpecialChars)
            {
                chars = chars.Replace("{ } [ ] ( ) / \\ ' \" ` ~ , ; : . < >", "");
            }

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void SaveCredentialsToFile(string login, string password)
        {
            using (StreamWriter writer = new StreamWriter("credentials.txt", true))
            {
                writer.WriteLine($"Login: {login}, Password: {password}");
            }
        }
    }
}
