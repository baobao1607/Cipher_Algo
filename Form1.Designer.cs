namespace Cipher
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
            checkBox_auto_key = new CheckBox();
            comboBox_RSA_key = new ComboBox();
            checkBox_RSA_private_key = new CheckBox();
            textBox_private_key = new TextBox();
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
            button_encrypt.Location = new Point(303, 500);
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
            button_decrypt.Location = new Point(58, 500);
            button_decrypt.Name = "button_decrypt";
            button_decrypt.Size = new Size(207, 55);
            button_decrypt.TabIndex = 5;
            button_decrypt.Text = "DECRYPT";
            button_decrypt.UseVisualStyleBackColor = true;
            button_decrypt.Click += button_decrypt_Click;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(122, 215);
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
            // checkBox_auto_key
            // 
            checkBox_auto_key.AutoSize = true;
            checkBox_auto_key.Location = new Point(654, 171);
            checkBox_auto_key.Name = "checkBox_auto_key";
            checkBox_auto_key.Size = new Size(196, 29);
            checkBox_auto_key.TabIndex = 11;
            checkBox_auto_key.Text = "Generated Auto Key";
            checkBox_auto_key.UseVisualStyleBackColor = true;
            // 
            // comboBox_RSA_key
            // 
            comboBox_RSA_key.FormattingEnabled = true;
            comboBox_RSA_key.Location = new Point(122, 166);
            comboBox_RSA_key.Name = "comboBox_RSA_key";
            comboBox_RSA_key.Size = new Size(511, 33);
            comboBox_RSA_key.TabIndex = 12;
            // 
            // checkBox_RSA_private_key
            // 
            checkBox_RSA_private_key.AutoSize = true;
            checkBox_RSA_private_key.Location = new Point(654, 206);
            checkBox_RSA_private_key.Name = "checkBox_RSA_private_key";
            checkBox_RSA_private_key.Size = new Size(169, 29);
            checkBox_RSA_private_key.TabIndex = 13;
            checkBox_RSA_private_key.Text = "Enter Private Key";
            checkBox_RSA_private_key.UseVisualStyleBackColor = true;
            checkBox_RSA_private_key.CheckedChanged += checkBox_RSA_private_key_CheckedChanged;
            // 
            // textBox_private_key
            // 
            textBox_private_key.Location = new Point(561, 269);
            textBox_private_key.Name = "textBox_private_key";
            textBox_private_key.Size = new Size(434, 31);
            textBox_private_key.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 606);
            Controls.Add(textBox_private_key);
            Controls.Add(checkBox_RSA_private_key);
            Controls.Add(comboBox_RSA_key);
            Controls.Add(checkBox_auto_key);
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
        private CheckBox checkBox_auto_key;
        private ComboBox comboBox_RSA_key;
        private CheckBox checkBox_RSA_private_key;
        private TextBox textBox_private_key;
    }
}
