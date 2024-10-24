using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    internal class ECC_Cipher
    {
        private BigInteger n;
        private BigInteger private_key;
        private BigInteger public_key;
        private readonly Random random = new Random();

        public ECC_Cipher()
        {
            n = BigInteger.Parse("115792089237316195423570985008687907852837564279074904382605163141518161494337");
            private_key = Choose_Random_K();
        }


        private BigInteger Choose_Random_K()
        {
            Random random = new Random();
            return Random_Big_Integer(1, n);
        }

        private BigInteger Random_Big_Integer(BigInteger min, BigInteger max)
        {
            if (max <= min)
            {
                throw new ArgumentException("Invalid Range");
            } else
            {
                BigInteger range = max - min;
                byte[] bytes = range.ToByteArray();
                BigInteger randomValue;
                do
                {
                    random.NextBytes(bytes);  
                    bytes[^1] &= 0x7F;        
                    randomValue = new BigInteger(bytes);
                } while (randomValue >= range); 

                return randomValue + min;
            }
        } 


    }
}
