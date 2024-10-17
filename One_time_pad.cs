using System.Text;

namespace Cipher
{
    internal class One_time_pad
    {
        string encrypted_plaintext;
        string encrypted_key;
        string encrypted_text;
        List<String> key_log;

        public One_time_pad()
        {
            encrypted_plaintext = String.Empty;
            encrypted_text = String.Empty;
            encrypted_key = String.Empty;
            key_log = new List<String>();   
        }



        private string convert_plaintext(string plaintext) 
        {
            StringBuilder build_plaintext = new StringBuilder();
            foreach (char c in plaintext)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (c - '0' != 1 && c - '0' != 0)
                {
                    throw new ArgumentException("Please enter plain text as bit");
                }
                build_plaintext.Append(c);
            }
            return build_plaintext.ToString();
        }


        public string get_encrypted_plaintext()
        {
            return encrypted_plaintext;
        }

        public string get_encrypted_key()
        {
            return encrypted_key;
        }

        public string get_encrypted_text()
        {
            return encrypted_text;
        }


        public string Encrypt(string source)
        {
            encrypted_plaintext = convert_plaintext(source);
            encrypted_key = getkey(encrypted_plaintext);
            if (string.IsNullOrEmpty(encrypted_plaintext) || string.IsNullOrEmpty(encrypted_key))
            {
                throw new ArgumentException("Plaintext or key cannot be empty.");
            }
            StringBuilder plaintext = new StringBuilder(encrypted_plaintext);
            StringBuilder key = new StringBuilder(encrypted_key);
            StringBuilder encrypted = new StringBuilder();
            for (int i = 0; i < plaintext.Length; i++) 
            {
                int p = plaintext[i] - '0';
                int k = key[i] - '0';
                int E = p ^ k;
                encrypted.Append(E);
            }
            encrypted_text = encrypted.ToString();
            return encrypted_text;
        }



        public string Decrypt(string source_encrypt, string source_key)
        {
            StringBuilder plaintext = new StringBuilder();
            if (source_encrypt.Length != source_key.Length)
            {
                throw new ArgumentException("the key and the decrypted message must be of the same length");
            }
            for (int i = 0; i < source_encrypt.Length; i ++)
            {
                if (source_encrypt[i] - '0' != 0 && source_encrypt[i] - '0' != 1 && source_key[i] - '0' != 0 && source_key[i] - '0' != 1)
                {
                    throw new ArgumentException("key and decrypted message only takes binary bit");
                } else
                {
                    int p = source_encrypt[i] - '0';
                    int k = source_key[i] - '0';
                    int E = p ^ k;
                    plaintext.Append(E);
                }
            }
            return plaintext.ToString();
        }

        private String getkey(string plaintext)
        {
            StringBuilder build_plaintext = new StringBuilder(plaintext);
            Random random = new Random();
            StringBuilder key;
            do
            {
                key = new StringBuilder();
                for (int i = 0; i < build_plaintext.Length; i++)
                {
                    int random_num = random.Next(0, 2); 
                    key.Append(random_num);             
                }

                encrypted_key = key.ToString();
            }
            while (key_log.Contains(encrypted_key)); // Keep generating while the key is already in the log

            // Log the new unique key
            key_log.Add(encrypted_key);

            return encrypted_key;
        }


    }
}
