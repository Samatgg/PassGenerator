namespace PassGenerator
{
    partial class PassGenerator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.passLab = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxSimilarChars = new System.Windows.Forms.CheckBox();
            this.checkBoxSpecialChars = new System.Windows.Forms.CheckBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // passLab
            // 
            this.passLab.AutoSize = true;
            this.passLab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passLab.Location = new System.Drawing.Point(33, 39);
            this.passLab.Name = "passLab";
            this.passLab.Size = new System.Drawing.Size(129, 22);
            this.passLab.TabIndex = 0;
            this.passLab.Text = "Длина пароля";
            this.passLab.Click += new System.EventHandler(this.passLab_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(102, 183);
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(217, 37);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // checkBoxSimilarChars
            // 
            this.checkBoxSimilarChars.AutoSize = true;
            this.checkBoxSimilarChars.Location = new System.Drawing.Point(33, 89);
            this.checkBoxSimilarChars.Name = "checkBoxSimilarChars";
            this.checkBoxSimilarChars.Size = new System.Drawing.Size(300, 20);
            this.checkBoxSimilarChars.TabIndex = 2;
            this.checkBoxSimilarChars.Text = "Включить похожие символы(i, l, 1, L, o, 0, O)";
            this.checkBoxSimilarChars.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpecialChars
            // 
            this.checkBoxSpecialChars.AutoSize = true;
            this.checkBoxSpecialChars.Location = new System.Drawing.Point(33, 130);
            this.checkBoxSpecialChars.Name = "checkBoxSpecialChars";
            this.checkBoxSpecialChars.Size = new System.Drawing.Size(310, 20);
            this.checkBoxSpecialChars.TabIndex = 3;
            this.checkBoxSpecialChars.Text = "Включить небуквенные символы({ } [ ] ( ) / \\ )";
            this.checkBoxSpecialChars.UseVisualStyleBackColor = true;
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneratePassword.Location = new System.Drawing.Point(135, 257);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(142, 42);
            this.btnGeneratePassword.TabIndex = 4;
            this.btnGeneratePassword.Text = "Сгенерировать";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(181, 39);
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownLength.TabIndex = 5;
            // 
            // PassGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.btnGeneratePassword);
            this.Controls.Add(this.checkBoxSpecialChars);
            this.Controls.Add(this.checkBoxSimilarChars);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.passLab);
            this.Name = "PassGenerator";
            this.ShowIcon = false;
            this.Text = "Генератор паролей";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passLab;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxSimilarChars;
        private System.Windows.Forms.CheckBox checkBoxSpecialChars;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
    }
}

