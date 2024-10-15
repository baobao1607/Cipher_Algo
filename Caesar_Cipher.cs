using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cipher
{
    internal class Caesar_Cipher
    {
        Dictionary<int, char> key_to_characters;
        Dictionary<char, int> characters_to_keys;
        private int valid_key;
        StringBuilder ciphertext;
        public Caesar_Cipher(string k)
        {
            ciphertext = new StringBuilder();
            key_to_characters = new Dictionary<int, char>();
            characters_to_keys = new Dictionary<char, int>();
            valid_key = GetKey(k);
            InitializeCipherData();
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



        private int GetKey(string k)
        {
            if (String.IsNullOrEmpty(k))
            {
                throw new ArgumentException("Key cannot be empty.");
            }
            char[] key_character = k.ToArray();
            if (key_character.Length != 1)
            {
                throw new ArgumentException("Caesar Cipher only accepts 1 key character.");
            }
            if (!char.IsDigit(key_character[0]))
            {
                throw new ArgumentException("This is not a valid character for the key. Only digits are allowed.");
            }
            return (int)char.GetNumericValue(key_character[0]);
        }


        public string Encrypt(string plaintext)
        {
            if (String.IsNullOrEmpty(plaintext))
            {
                throw new ArgumentException("You have not input any text in plaintext");
            }
            char[] characters = plaintext.ToCharArray();
            foreach (char c in characters)
            {
                if (!characters_to_keys.ContainsKey(c) && c != ' ')
                {
                    throw new ArgumentException("Invalid Character Found");
                }
                if (c == ' ')
                {
                    ciphertext.Append(c);
                }
                else
                {
                    int p = characters_to_keys[c];
                    int E = (p + valid_key) % 26;
                    if (char.IsUpper(c))
                    {
                        E += 26;
                    }
                    char k = key_to_characters[E];
                    ciphertext.Append(k);
                }
            }
            return ciphertext.ToString();
        }


        public string decrypt (string encrypted_text)
        {
            if (String.IsNullOrEmpty(encrypted_text))
            {
                throw new ArgumentException("You have not input any text in encrypted");
            }
            char[] characters = encrypted_text.ToCharArray();
            foreach (char c in characters)
            {
                if (!characters_to_keys.ContainsKey(c) && c != ' ')
                {
                    throw new ArgumentException("Invalid Character Found");
                }
                if (c == ' ')
                {
                    ciphertext.Append(c);
                }
                else
                {
                    int p = characters_to_keys[c];
                    int E = (p - valid_key) % 26;
                    if (E < 0)
                    {
                        E += 26;
                    }
                    if (char.IsUpper(c))
                    {
                        E += 26;
                    }
                    char k = key_to_characters[E];
                    ciphertext.Append(k);
                }
            }
            return ciphertext.ToString();
        }

    }
}
