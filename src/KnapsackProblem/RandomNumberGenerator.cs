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
			long m = 2147483647L, a = 16807L, b = 127773L, c = 2836L;

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
