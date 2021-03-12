using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorCS
{
    public class RandomNumberGenerator
    {
        private long seed;

        public RandomNumberGenerator(long seedValue)
        {
            seed = seedValue;
        }

		public int nextInt(int low, int high)
		{
			long k;
			double value_0_1;
			long m = 2147483647l, a = 16807l, b = 127773l, c = 2836l;

			k = seed / b;
			seed = a * (seed % b) - k * c;
			if (seed < 0)
				seed = seed + m;
			value_0_1 = seed;
			value_0_1 /= m;
			return low + (int)Math.Floor(value_0_1 * (high - low + 1));
		}
		public float nextFloat(int low, int high)
		{
			low *= 100000;
			high *= 100000;
			float val = nextInt(low, high) / 100000.0f;
			return val;
		}

	}
}
