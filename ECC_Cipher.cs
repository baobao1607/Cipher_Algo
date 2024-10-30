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
        private List<BigInteger> public_key;
        private readonly Random random = new Random();
        private List<BigInteger> base_point_G;
        private readonly BigInteger a = 0;
        private readonly BigInteger b = 7;
        private readonly BigInteger p = BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007913129639936"); 

        public ECC_Cipher()
        {
            base_point_G = initialize_base_point_G();
            n = BigInteger.Parse("115792089237316195423570985008687907852837564279074904382605163141518161494337");
            private_key = Choose_Random_K();
            public_key = scalar_multiply(private_key);

        }

        private List<BigInteger> initialize_base_point_G()
        {
            List<BigInteger> base_point_coordinates = new List<BigInteger>(2);
            base_point_coordinates.Add(BigInteger.Parse("55066263022277343669578718895168534326250603453777594175500187360389116729240"));
            base_point_coordinates.Add(BigInteger.Parse("32670510020758816978083085130507043184471273380659243275938904335757337482424"));
            return base_point_coordinates;
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


        private List<BigInteger> scalar_multiply (BigInteger d)
        {
            List<BigInteger> result = new List< BigInteger>();
            result.Add(0);
            result.Add(0);

            for (int i =0; i < d; i++)
            {
                result = AddPoints(result, base_point_G);
            }

            return result;
        }


        private List<BigInteger> AddPoints(List<BigInteger> P, List<BigInteger> Q)
        {
            if (P[0] == 0 && P[1] == 0) return Q; 
            if (Q[0] == 0 && Q[1] == 0) return P; 

            BigInteger x1 = P[0];
            BigInteger y1 = P[1];
            BigInteger x2 = Q[0];
            BigInteger y2 = Q[1];

            BigInteger m;

            if (x1 == x2 && y1 == y2)
            {
                m = (3 * BigInteger.Pow(x1, 2) + a) * ModInverse(2 * y1, p) % p;
            }
            else
            {
                m = (y2 - y1) * ModInverse(x2 - x1, p) % p;
            }

            BigInteger x3 = (BigInteger.Pow(m, 2) - x1 - x2) % p;
            BigInteger y3 = (m * (x1 - x3) - y1) % p;

            return new List<BigInteger> { (x3 + p) % p, (y3 + p) % p }; 
        }

        private BigInteger ModInverse(BigInteger value, BigInteger mod)
        {
            BigInteger m0 = mod;
            BigInteger y = 0;
            BigInteger x = 1;

            if (mod == 1)
                return 0;

            while (value > 1)
            {
                BigInteger q = value / mod;
                BigInteger t = mod;

                mod = value % mod;
                value = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }


    }
}
