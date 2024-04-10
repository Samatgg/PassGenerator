using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PassGeneratorTests
{
    [TestClass]
    public class PassGeneratorTests
    {
        private List<string> previousPasswords = new List<string>();
        /// <summary>
        /// #1 - Тест генерациии уникального пароля длиной 8 символов
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_Length8_NoSimilarChars_NoSpecialChars()
        {
            string newPassword = GenerateUniquePassword(8, false, false);
            Assert.IsFalse(previousPasswords.Contains(newPassword));
            previousPasswords.Add(newPassword);
        }
        /// <summary>
        /// #2 - Тест генерациии уникального пароля длиной 12 символов
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_Length12_IncludeSimilarChars_NoSpecialChars()
        {
            string newPassword = GenerateUniquePassword(12, true, false);
            Assert.IsFalse(previousPasswords.Contains(newPassword));
            previousPasswords.Add(newPassword);
        }
        /// <summary>
        /// #3 - Тест генерациии уникального пароля длиной 10 символов
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_Length10_NoSimilarChars_IncludeSpecialChars()
        {
            string newPassword = GenerateUniquePassword(10, false, true);
            Assert.IsFalse(previousPasswords.Contains(newPassword));
            previousPasswords.Add(newPassword);
        }
        /// <summary>
        /// #4 - Исключение из аргумента недопустимой длины
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_InvalidLength_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => GenerateUniquePassword(-1, false, false));
        }
        /// <summary>
        /// #5 - Правильность сгенерированного уникального пароля
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_LengthIsCorrect()
        {
            string newPassword = GenerateUniquePassword(8, true, true);
            Assert.AreEqual(8, newPassword.Length);
        }
        /// <summary>
        /// #6 - Генерируются различные пароли
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_DifferentPasswordsGenerated()
        {
            string password1 = GenerateUniquePassword(8, true, true);
            string password2 = GenerateUniquePassword(8, true, true);
            Assert.AreNotEqual(password1, password2);
        }
        /// <summary>
        /// #7 - Включает похожие символы
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_IncludeSimilarChars()
        {
            string newPassword = GenerateUniquePassword(8, false, true);
            Assert.IsFalse(newPassword.Contains("i") || newPassword.Contains("I") || newPassword.Contains("l") || newPassword.Contains("L"));
        }
        /// <summary>
        /// #8 - Включает небуквенные символы
        /// </summary>
        [TestMethod]
        public void TestGenerateUniquePassword_IncludeSpecialChars()
        {
            string newPassword = GenerateUniquePassword(8, true, false);
            Assert.IsTrue(newPassword.Any(c => "!@#$%^&*()-_=+".Contains(c)));
        }
        /// <summary>
        /// #9 - Включает все символы
        /// </summary>
        [TestMethod]
        public void TestGeneratePassword_IncludeAllChars()
        {
            PasswordGenerator generator = new PasswordGenerator();
            string password = generator.GeneratePassword(10, true, true);

            string allChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Assert.IsTrue(allChars.All(c => password.Contains(c)));
        }
        /// <summary>
        /// #10 - Содержит только значимые символы
        /// </summary>
        [TestMethod]
        public void TestGeneratePassword_ContainsOnlyValidCharacters()
        {
            string generatedPassword = GenerateUniquePassword(8, true, true);
            Assert.IsTrue(generatedPassword.All(char.IsLetterOrDigit));
        }
        /// <summary>
        /// #11 - Использует случайные символы
        /// </summary>
        [TestMethod]
        public void TestGeneratePassword_UsesRandomClass()
        {
            string password1 = GenerateUniquePassword(8, true, true);
            string password2 = GenerateUniquePassword(8, true, true);
            Assert.AreNotEqual(password1, password2);
        }
        /// <summary>
        /// #12 - Заменяет аналогичные символы
        /// </summary>
        [TestMethod]
        public void GeneratePassword_ReplacesSimilarCharacters()
        {
            string password = GeneratePassword(8, false, true);
            Assert.IsFalse(password.Contains('i') || password.Contains('I') || password.Contains('l') || password.Contains('L'));
        }
        /// <summary>
        /// 13 - Предположим, что есть список, где будут сохраняться сгенерированные пароли
        /// </summary>
        [TestMethod]
        public void GenerateUniquePassword_RegeneratesPasswordIfSameAsPrevious()
        {
            previousPasswords.Add("");
            string newPassword = GenerateUniquePassword(8, true, true);
            Assert.IsFalse(previousPasswords.Contains(newPassword));
        }
        /// <summary>
        /// #14 - Проверкa смены пароля каждый месяц
        /// </summary>
        [TestMethod]
        public void PasswordChangesEveryMonth()
        {
            string password1 = GenerateUniquePassword(8, true, true);
            //предположим, прошел месяц
            string password2 = GenerateUniquePassword(8, true, true);

            Assert.AreNotEqual(password1, password2);
        }
        /// <summary>
        /// #15 - Проверка на уникальность пароля
        /// </summary>
        [TestMethod]
        public void GeneratedPassword_IsUnique()
        {
            string password1 = GenerateUniquePassword(8, true, true);
            string password2 = GenerateUniquePassword(8, true, true);
            Assert.AreNotEqual(password1, password2);
        }

        private string GenerateUniquePassword(int length, bool includeSimilarChars, bool includeSpecialChars)
        {
            string newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);
            while (previousPasswords.Contains(newPassword))
            {
                newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);
            }
            previousPasswords.Add(newPassword);
            return newPassword;
        }

        private string GeneratePassword(int length, bool includeSimilarChars, bool includeSpecialChars)
        {
            string newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);

            while (previousPasswords.Contains(newPassword))
            {
                newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);
            }
            previousPasswords.Add(newPassword);
            return newPassword;
        }
    }
}
