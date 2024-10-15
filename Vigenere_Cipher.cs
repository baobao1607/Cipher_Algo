using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cipher
{
    internal class Vigenere_Cipher
    {
        Dictionary<int, char> key_to_characters;
        Dictionary<char, int> characters_to_keys;
        private string valid_key;
        StringBuilder ciphertext;

        public Vigenere_Cipher(string key)
        {
            ciphertext = new StringBuilder();
            key_to_characters = new Dictionary<int, char>();
            characters_to_keys = new Dictionary<char, int>();
            valid_key = GetKey(key);
            InitializeCipherData();
        }

        private string GetKey(string key)
        {
            StringBuilder processedKey = new StringBuilder();
            char[] key_char = key.ToCharArray();
            if (key_char.Length == 0)
            {
                throw new ArgumentException("you have not input any key");
            }
            foreach (char c in key_char) 
            {
                if (!char.IsLetter(c))
                {
                    throw new ArgumentException("Invalid Character Spotted. Only accept characters");
                }
                processedKey.Append(c);
            }

            return processedKey.ToString(); 
        }


        private void InitializeCipherData()
        {
            for (int i = 0; i <= 25; i++)
            {
                char letter = (char)('a' + i);
                char upperletter = (char)('A' + i);
                key_to_characters.Add(i, letter);
                key_to_characters.Add(i + 26, upperletter);
                characters_to_keys.Add(letter, i);
                characters_to_keys.Add(upperletter, i + 26);
            }
        }

        public string Encrypt(string plaintext)
        {
            if (String.IsNullOrEmpty(plaintext))
            {
                throw new ArgumentException("You have not input any text in plaintext");
            }
            char[] plaintext_char = plaintext.ToCharArray();
            char[] key_text = valid_key.ToCharArray();
            StringBuilder plaintext_builder = new StringBuilder();
            foreach (char c in plaintext_char)
            {
                if (!characters_to_keys.ContainsKey(c) && c != ' ')
                {
                    throw new ArgumentException("Invalid Character Found");
                }
                plaintext_builder.Append(c);
            }
            StringBuilder extendedKey = new StringBuilder();
            int key_index = 0;
            for (int i = 0; i < plaintext_builder.Length; i++)
            {
                char current_plaintext_character = plaintext_builder[i];
                if (char.IsLetter(current_plaintext_character))
                {
                    extendedKey.Append(valid_key[key_index]);
                    key_index = (key_index + 1) % valid_key.Length;
                } else
                {
                    extendedKey.Append(' ');
                }
            }
            StringBuilder encrypted_string = new StringBuilder();
            for (int i = 0; i < extendedKey.Length; i++)
            {
                char k = extendedKey[i];
                char p = plaintext_builder[i];
                if (k == ' ' && p == ' ')
                {
                    encrypted_string.Append(' ');
                    continue;
                }
                int key_k = characters_to_keys[k];
                int key_p = characters_to_keys[p];
                int key_e = (key_k + key_p) % 52;
                char e = key_to_characters[key_e];
                encrypted_string.Append(e);
            }
            return encrypted_string.ToString();
        }


        public string Decrypt(string encrypted)
        {
            if (String.IsNullOrEmpty(encrypted))
            {
                throw new ArgumentException("You have not input any text in plaintext");
            }
            char[] encrypted_char = encrypted.ToCharArray();
            char[] key_text = valid_key.ToCharArray();
            StringBuilder encrypted_builder = new StringBuilder();
            foreach (char c in encrypted_char)
            {
                if (!characters_to_keys.ContainsKey(c) && c != ' ')
                {
                    throw new ArgumentException("Invalid Character Found");
                }
                encrypted_builder.Append(c);
            }
            StringBuilder extendedKey = new StringBuilder();
            int key_index = 0;
            for (int i = 0; i < encrypted_builder.Length; i++)
            {
                char current_plaintext_character = encrypted_builder[i];
                if (char.IsLetter(current_plaintext_character))
                {
                    extendedKey.Append(valid_key[key_index]);
                    key_index = (key_index + 1) % valid_key.Length;
                }
                else
                {
                    extendedKey.Append(' ');
                }
            }
            StringBuilder plaintext_string = new StringBuilder();
            for (int i = 0; i < extendedKey.Length; i++)
            {
                char k = extendedKey[i];
                char p = encrypted_builder[i];
                if (k == ' ' && p == ' ')
                {
                    plaintext_string.Append(' ');
                    continue;
                }
                int key_k = characters_to_keys[k];
                int key_p = characters_to_keys[p];
                int key_e = (key_p - key_k + 52) % 52;
                char e = key_to_characters[key_e];
                plaintext_string.Append(e);
            }
            return plaintext_string.ToString();
        }

    }
}
