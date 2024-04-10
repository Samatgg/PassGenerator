using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PassGenerator
{
    public partial class PassGenerator : Form
    {
        // Из опций использовал:
        // 3 - Получив сгенерированный пароль создать некое предложения для запоминания “Remember your password”
        // 4 - При генерации для пользователя следующего пароля, прикрутить проверку, что каждый месяц пароль должен изменяться,не повторяться с предыдущими

        List<string> previousPasswords = new List<string>();
        
        private string GenerateUniquePassword(int length, bool includeSimilarChars, bool includeSpecialChars)
        {
            string newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);

            // Проверяем, что новый пароль уникален и не совпадает с предыдущими
            while (previousPasswords.Contains(newPassword))
            {
                newPassword = GeneratePassword(length, includeSimilarChars, includeSpecialChars);
            }
            previousPasswords.Add(newPassword);
            return newPassword;
        }
        private string GeneratePassword(int length, bool includeSimilarChars, bool includeSpecialChars)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789{}[]()/\\'\"`~,;:.<>";
            if (!includeSimilarChars)
            {
                chars = chars.Replace("iIlLoO", ""); // Удаляем похожие символы
            }

            if (!includeSpecialChars)
            {
                chars = chars.Replace("{}[]()/\\'\"`~,;:.<>", ""); // Удаляем небуквенные символы
            }

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }       
        public PassGenerator()
        {
            InitializeComponent();
        }

        private void passLab_Click(object sender, EventArgs e)
        {

        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            int passwordLength = (int)numericUpDownLength.Value;
            bool includeSimilarChars = checkBoxSimilarChars.Checked;
            bool includeSpecialChars = checkBoxSpecialChars.Checked;

            string generatedPassword = GeneratePassword(passwordLength, includeSimilarChars, includeSpecialChars);
            textBoxPassword.Text = generatedPassword;
            if (textBoxPassword.Text == "")
            {
                MessageBox.Show("You have not chosen the password length!","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string rememberPasswordSentence = $"Remember your password: {generatedPassword}";
                MessageBox.Show(rememberPasswordSentence, "Password Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
