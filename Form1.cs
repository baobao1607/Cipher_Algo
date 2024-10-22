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
            checkBox_auto_key.Visible = false;
            comboBox_RSA_key.Visible = false;
            checkBox_RSA_private_key.Visible = false;
            textBox_private_key.Visible= false;
            InitalizeComboBox();
        }

        private void InitalizeComboBox()
        {
            comboBox1.Items.Add("Caesar Cipher");
            comboBox1.Items.Add("Vigenere Cipher");
            comboBox1.Items.Add("One Time Pad");
            comboBox1.Items.Add("RSA Cipher");
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
            else if (cipher_mode == 2)
            {
                button_encrypt_one_time_pad();
            }
            else if (cipher_mode == 3)
            {
                button_encrypt_RSA_cipher();
            }
            else
            {
                MessageBox.Show("You have not chosen a cipher scheme");
                return;
            }
        }

        private void button_encrypt_RSA_cipher()
        {
            comboBox_RSA_key.Items.Clear();
            string plaintext = textBox_plaintext.Text;
            RSA_Cipher rsa = new RSA_Cipher();
            textBox_encrypt.Text = rsa.Encrypt(plaintext);
            List<long> public_key = rsa.retrieve_public_key();
            List<long> private_key = rsa.retrieve_private_key();
            comboBox_RSA_key.Items.Add($"Public key: {public_key[0]}, {public_key[1]}");
            comboBox_RSA_key.Items.Add($"Private key: {private_key[0]}, {private_key[1]}");
        }


        private void button_encrypt_one_time_pad()
        {
            try
            {
                One_time_pad otp = new One_time_pad();
                string plaintext = textBox_plaintext.Text;
                string encrypted_text = otp.Encrypt(plaintext);
                textBox_encrypt.Text = encrypted_text;
                textBox_key.Text = otp.get_encrypted_key();
                textBox_plaintext.Text = otp.get_encrypted_plaintext();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
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
                }
                else
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
            else if (cipher_mode == 2)
            {
                button_decrypt_one_time_pad();
            }
            else if (cipher_mode == 3)
            {
                button_decrypt_rsa_cipher();
            }
            else
            {
                MessageBox.Show("You have not chosen a cipher scheme");
                return;
            }
        }


        private void button_decrypt_rsa_cipher()
        {
            if (String.IsNullOrEmpty(textBox_private_key.Text))
            {
                MessageBox.Show("Please put in the private key");
            }
            if (String.IsNullOrEmpty(textBox_encrypt.Text))
            {
                MessageBox.Show("Please put in the encrypted text");
            }
            string[] parts = textBox_private_key.Text.Split(',');
            long a = long.Parse(parts[0]);
            long b = long.Parse(parts[1]);
            List<long> private_key_pair = new List<long>();
            private_key_pair.Add(a);
            private_key_pair.Add(b);
            string encrypted = textBox_encrypt.Text;
            RSA_Cipher rsa = new RSA_Cipher(a, b);
            string plaintext = rsa.Decrypt(encrypted);
            textBox_plaintext.Text = plaintext;
        }


        private void button_decrypt_one_time_pad()
        {
            try
            {
                One_time_pad otp = new One_time_pad();
                string encrypted = textBox_encrypt.Text;
                string key = textBox_key.Text;
                string plaintext = otp.Decrypt(encrypted, key);
                textBox_plaintext.Text = plaintext;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
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
            textBox_key.Clear();
            textBox_plaintext.Clear();
            textBox_encrypt.Clear();
            textBox_private_key.Clear();
        }


        private void refresh()
        {
            textBox_plaintext.Clear();
            textBox_encrypt.Clear();
            textBox_key.Clear();
            label_cipher_mode.Text = "No Cipher Chosen";
            comboBox_RSA_key.Visible = false;
            comboBox_RSA_key.Items.Clear();
            textBox_key.Visible = true;
            checkBox_RSA_private_key.Visible = false;
            textBox_private_key.Visible = false;
            checkBox_auto_key.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                refresh();
                cipher_mode = 0;
                label_cipher_mode.Text = comboBox1.Text;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                refresh();
                cipher_mode = 1;
                label_cipher_mode.Text = comboBox1.Text;
                checkBox_auto_key.Visible = true;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                refresh();
                cipher_mode = 2;
                label_cipher_mode.Text = comboBox1.Text;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                refresh();
                cipher_mode = 3;
                label_cipher_mode.Text = comboBox1.Text;
                textBox_key.Visible = false;
                comboBox_RSA_key.Visible = true;
                checkBox_RSA_private_key.Visible = true;
            }
        }

        private void checkBox_RSA_private_key_CheckedChanged(object sender, EventArgs e)
        {
            textBox_private_key.Visible = checkBox_RSA_private_key.Checked;
        }
    }
}
