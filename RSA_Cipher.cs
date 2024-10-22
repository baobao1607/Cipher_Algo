using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    internal class RSA_Cipher
    {
        long prime_p;
        long prime_q;
        long n;
        long e;
        List<long> key_public;
        List<long> key_private;
        static Random random = new Random();

        public RSA_Cipher()
        {
            List<long> prime_keys = initialize_prime_keys();
            prime_p = prime_keys[0];
            prime_q = prime_keys[1];
            n = prime_p * prime_q;
            key_public = get_public_key();
            key_private = get_private_key(e);
        }


        public RSA_Cipher(long a, long b)
        {
            prime_p = -1;
            prime_q = -1;
            n = a;
            key_public = new List<long>();
            key_private = initialize_private_key(a,b);
        }


        private List<long> initialize_private_key(long a, long b)
        {
            List<long> private_key = new List<long>();
            private_key.Add(a);
            private_key.Add(b);
            return private_key;
        }

        public List<long> retrieve_public_key()
        {
            return key_public;
        }

        public List<long> retrieve_private_key()
        {
            return key_private;
        }

        private List<long> get_public_key()
        {
            List<long> public_key = new List<long>();
            long euler_totient = get_euler_totient();
            e = RandomLong(2, euler_totient);
            while (gcd(e,euler_totient) != 1)
            {
                e = e = RandomLong(2, euler_totient);
            }
            public_key.Add(e);
            public_key.Add(n);
            return public_key;
        }


        private long RandomLong(long min, long max)
        {
            if (max <= min || max > long.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(max), "Invalid range for random long generation.");

            byte[] buf = new byte[8];
            random.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }

        private long gcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }


        private List<long> get_private_key(long e) 
        {
            List<long> private_key = new List<long>();
            long euler_totient = get_euler_totient();
            long d = ComputeD(e, euler_totient);
            private_key.Add(d);
            private_key.Add(n);
            return private_key;
        }


        private long ComputeD(long e, long phi)
        {
            long d = 0, x1 = 0, x2 = 1, y1 = 1, temp_phi = phi;
            while (e > 0)
            {
                long temp1 = temp_phi / e, temp2 = temp_phi - temp1 * e;
                temp_phi = e;
                e = temp2;

                long x = x2 - temp1 * x1;
                long y = d - temp1 * y1;

                x2 = x1;
                x1 = x;
                d = y1;
                y1 = y;
            }

            if (temp_phi == 1)
                return d + phi;
            return 0; // No modular inverse exists
        }

        private long get_euler_totient()
        {
            return (prime_p - 1) * (prime_q - 1);
        }


        private List<long> initialize_prime_keys()
        {
            List<long> prime_keys = new List<long>();
            long big_integers = Create_Big_Number();
            long big_integers_2 = Create_Big_Number();
            while (!Miller_Rabin(big_integers) || !Miller_Rabin(big_integers_2))
            {
                big_integers = Create_Big_Number();
                big_integers_2 = Create_Big_Number();
            }
            prime_keys.Add(big_integers);
            prime_keys.Add(big_integers_2);
            return prime_keys;
        }


        private long Create_Big_Number()
        {
            long a = random.Next(1000000, 100000000);
            return a;
        }



        private bool Miller_Rabin(long n, int k = 100)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;  
            if (n % 2 == 0) return false;       

            long d = n - 1;
            int r = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                r++;
            }

            for (int i = 0; i < k; i++)
            {
                long a = (long)(random.NextDouble() * (n - 2)) + 2;  
                long x = ModularExponentiation(a, d, n);

                if (x == 1 || x == n - 1)
                {
                    continue;
                }

                bool found = false;
                for (int j = 0; j < r - 1; j++)
                {
                    x = (x * x) % n;
                    if (x == n - 1)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found) return false;
            }

            return true;
        }



        private long ModularExponentiation(long baseNum, long exponent, long mod)
        {
            long result = 1;
            baseNum = baseNum % mod;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1) // If exponent is odd
                {
                    result = (result * baseNum) % mod;
                }
                exponent >>= 1; // Divide the exponent by 2
                baseNum = (baseNum * baseNum) % mod; // Square the base
            }

            return result;
        }


        public string Encrypt(string plaintext)
        {
            plaintext = plaintext.Replace(" ", "");
            byte[] byte_array = UTF8Encoding.UTF8.GetBytes(plaintext);
            BigInteger big_byte_array = new BigInteger(byte_array);
            BigInteger big_encrypted = BigInteger.ModPow(big_byte_array, key_public[0], key_public[1]);
            string encrypted_text = ToHex(big_encrypted);
            return encrypted_text;
        }


        public string Decrypt (string encrypt)
        {
            byte[] byte_array = new byte[encrypt.Length/2];
            for (int i = 0; i < byte_array.Length; i++)
            {
                byte_array[i] = Convert.ToByte(encrypt.Substring(i * 2,2 ),16);
            }
            BigInteger encrypted_text = new BigInteger(byte_array);
            BigInteger plaintext_ = BigInteger.ModPow(encrypted_text, key_private[0], key_private[1]);
            byte[] byte_plaintext = plaintext_.ToByteArray();
            string plaintext = Encoding.UTF8.GetString(byte_plaintext);
            return plaintext;
        }


        static string ToHex(BigInteger bigInteger)
        {
            byte[] bytes = bigInteger.ToByteArray();
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}
