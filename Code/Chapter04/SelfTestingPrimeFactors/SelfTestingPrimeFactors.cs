using System;

namespace Packt
{
    public class SelfTestingPrimeFactors
    {
        public int PrimeFactor(int a)
        {
            int b = 2;
            if (a % b == 0)
            {
                return a / b;
            }
            return 0;
        }
    }
}
