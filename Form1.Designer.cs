﻿namespace Cipher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_plaintext = new TextBox();
            button_encrypt = new Button();
            textBox_encrypt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button_decrypt = new Button();
            button_refresh = new Button();
            textBox_key = new TextBox();
            label_key = new Label();
            comboBox1 = new ComboBox();
            label_cipher_mode = new Label();
            SuspendLayout();
            // 
            // textBox_plaintext
            // 
            textBox_plaintext.Location = new Point(122, 63);
            textBox_plaintext.Name = "textBox_plaintext";
            textBox_plaintext.Size = new Size(511, 31);
            textBox_plaintext.TabIndex = 0;
            // 
            // button_encrypt
            // 
            button_encrypt.Location = new Point(20, 279);
            button_encrypt.Name = "button_encrypt";
            button_encrypt.Size = new Size(207, 55);
            button_encrypt.TabIndex = 1;
            button_encrypt.Text = "ENCRYPT";
            button_encrypt.UseVisualStyleBackColor = true;
            button_encrypt.Click += button_encrypt_Click;
            // 
            // textBox_encrypt
            // 
            textBox_encrypt.Location = new Point(122, 110);
            textBox_encrypt.Name = "textBox_encrypt";
            textBox_encrypt.Size = new Size(511, 31);
            textBox_encrypt.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 69);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 3;
            label1.Text = "PlainText";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 116);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 4;
            label2.Text = "Encrypted ";
            // 
            // button_decrypt
            // 
            button_decrypt.Location = new Point(251, 279);
            button_decrypt.Name = "button_decrypt";
            button_decrypt.Size = new Size(207, 55);
            button_decrypt.TabIndex = 5;
            button_decrypt.Text = "DECRYPT";
            button_decrypt.UseVisualStyleBackColor = true;
            button_decrypt.Click += button_decrypt_Click;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(251, 203);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(244, 42);
            button_refresh.TabIndex = 6;
            button_refresh.Text = "REFRESH";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // textBox_key
            // 
            textBox_key.Location = new Point(122, 166);
            textBox_key.Name = "textBox_key";
            textBox_key.Size = new Size(511, 31);
            textBox_key.TabIndex = 7;
            // 
            // label_key
            // 
            label_key.AutoSize = true;
            label_key.Location = new Point(58, 172);
            label_key.Name = "label_key";
            label_key.Size = new Size(41, 25);
            label_key.TabIndex = 8;
            label_key.Text = "KEY";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(923, 61);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(212, 33);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label_cipher_mode
            // 
            label_cipher_mode.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_cipher_mode.Location = new Point(883, 203);
            label_cipher_mode.Name = "label_cipher_mode";
            label_cipher_mode.Size = new Size(252, 82);
            label_cipher_mode.TabIndex = 10;
            label_cipher_mode.Text = "No Cipher Chosen";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 606);
            Controls.Add(label_cipher_mode);
            Controls.Add(comboBox1);
            Controls.Add(label_key);
            Controls.Add(textBox_key);
            Controls.Add(button_refresh);
            Controls.Add(button_decrypt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_encrypt);
            Controls.Add(button_encrypt);
            Controls.Add(textBox_plaintext);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_plaintext;
        private Button button_encrypt;
        private TextBox textBox_encrypt;
        private Label label1;
        private Label label2;
        private Button button_decrypt;
        private Button button_refresh;
        private TextBox textBox_key;
        private Label label_key;
        private ComboBox comboBox1;
        private Label label_cipher_mode;
    }
}
