// Class for converting positive integer from different (2..16) numeral systems to other (2..16) ones

using System;
using System.Text;

namespace input_your_namespace
{
    class NumeralSystem
    {
        const int N = 16;
        static char[] symbols = new char[N] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
             'A', 'B', 'C', 'D', 'E', 'F'};

        // Convert x (decimal system) into "toBase" numeral system
        public static string From_10(int x, int toBase)
        {
            if (x < 0 || toBase < 2 || toBase > N)
                throw new Exception("Impossible to convert");
            StringBuilder result = new StringBuilder();
            while (x >= toBase)
            {
                result.Insert(0, symbols[x % toBase]);
                x /= toBase;
            }
            result.Insert(0, symbols[x]);
            return result.ToString();
        }

        // Return ch as integer
        private static int Number(char ch, int fromBase)
        {
            for (int i = 0; i < fromBase; i++)
                if (symbols[i] == ch)
                    return i;
            throw new Exception("Impossible to convert");   // if ch is incorrect
        }

        // Convert st ("fromBase" numeral system) into decimal system
        public static int To_10(string st, int fromBase)
        {
            if (fromBase < 2 || fromBase > 16 || st.Length == 0)
                throw new Exception("Impossible to convert");
            int result = 0, q = 1, i = st.Length - 1;
            while (i >= 0)
            {
                result += Number(st[i], fromBase) * q;
                q *= fromBase;
                i--;
            }
            return result;
        }

        // Convert x ("fromBase" numeral system) into "toBase" numeral system
        public static string From_A_to_B(string x, int fromBase, int toBase)
        {
            return From_10(To_10(x, fromBase), toBase);
        }
    }
}
