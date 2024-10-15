using System.Text;

namespace Cipher
{
    public partial class Form1 : Form
    {

        private int cipher_mode;

        public Form1()
        {

            InitializeComponent();
            cipher_mode = -1;
            InitalizeComboBox();
        }

        private void InitalizeComboBox()
        {
            comboBox1.Items.Add("Caesar Cipher");
            comboBox1.Items.Add("Vigenere Cipher");
        }

        private void button_encrypt_Click(object sender, EventArgs e)
        {
            if (cipher_mode == 0)
            {
                button_encrypt_caesar_cipher();
            }
            else if (cipher_mode == 1)
            {
                button_encrypt_vigenere_case();
            }
            else
            {
                MessageBox.Show("You have not chosen a cipher scheme");
                return;
            }
        }

        private void button_encrypt_vigenere_case()
        {
            try
            {
                string key = string.Empty;
                Vigenere_Cipher cipher;
                if (checkBox_auto_key.Checked)
                {
                    Vigenere_Cipher vn = new Vigenere_Cipher();
                    key = vn.get_auto_key(textBox_plaintext.Text);
                } else
                {
                    key = textBox_key.Text;
                }
                cipher = new Vigenere_Cipher(key);
                string plaintext = textBox_plaintext.Text;
                string encryptedText = cipher.Encrypt(plaintext);
                textBox_encrypt.Text = encryptedText;
                textBox_key.Text = key;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_encrypt_caesar_cipher()
        {
            try
            {
                string key = textBox_key.Text;
                Caesar_Cipher cipher = new Caesar_Cipher(key);

                string plaintext = textBox_plaintext.Text;
                string encryptedText = cipher.Encrypt(plaintext);

                textBox_encrypt.Text = encryptedText;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_decrypt_caesar_cipher()
        {
            try
            {
                string key = textBox_key.Text;
                Caesar_Cipher cipher = new Caesar_Cipher(key);

                string encrypt_text = textBox_encrypt.Text;
                string plaintext = cipher.decrypt(encrypt_text);

                textBox_plaintext.Text = plaintext;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button_decrypt_Click(object sender, EventArgs e)
        {
            if (cipher_mode == 0)
            {
                button_decrypt_caesar_cipher();
            }
            else if (cipher_mode == 1)
            {
                button_decrypt_vigenere_cipher();
            }
            else
            {
                MessageBox.Show("You have not chosen a cipher scheme");
                return;
            }
        }

        private void button_decrypt_vigenere_cipher()
        {
            try
            {
                string key = textBox_key.Text;
                Vigenere_Cipher vn = new Vigenere_Cipher(key);
                string encrypted = textBox_encrypt.Text;
                string plainText = vn.Decrypt(encrypted);
                textBox_plaintext.Text = plainText;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            textBox_plaintext.Clear();
            textBox_encrypt.Clear();
            textBox_key.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = string.Empty;
            label_cipher_mode.Text = "No Cipher Chosen";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                cipher_mode = 0;
                label_cipher_mode.Text = comboBox1.Text;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                cipher_mode = 1;
                label_cipher_mode.Text = comboBox1.Text;
            }
        }
    }
}
