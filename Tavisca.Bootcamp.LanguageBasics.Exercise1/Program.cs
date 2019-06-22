using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
        String[] data1=equation.Split('*');
        String[] data2=data1[1].Split('=');
        string a = data1[0];
        string b = data2[0];
        string c = data2[1];
        if(containsQM(c))
        {
            double integerA=Double.Parse(a);
            double integerB=Double.Parse(b);
            double x = integerA * integerB;
            if (!checkValidity(x)) return -1;
            else
            {
                int integerC = Convert.ToInt32(x);
                string calculatedC = integerC.ToString();
                int i = getQmIndex(c);
                if (checkForLeadingZero(c, calculatedC)) return -1;
                else
                {
                    for(int j=0;j<calculatedC.Length;j++)
                    {
                        if(c[j]!='?')
                        {
                            if (c[j] != calculatedC[j])
                                return -1;
                        }
                    }
                    return (calculatedC[i] - '0'); }
            }
        }
        else if(containsQM(a))
        {
            double integerB = Double.Parse(b);
            double integerC = Double.Parse(c);
            double x = integerC / integerB;
            if (!checkValidity(x)) return -1;
            else
            {
                int integerA = Convert.ToInt32(x);
                string calculatedA = integerA.ToString();
                int i = getQmIndex(a);
                if (checkForLeadingZero(a, calculatedA)) return -1;
                else
                {
                    for (int j = 0; j < calculatedA.Length; j++)
                    {
                        if (a[j] != '?')
                        {
                            if (a[j] != calculatedA[j])
                                return -1;
                        }
                    }
                    return (calculatedA[i] - '0');
                }
            }
        }
        else 
        {
            double integerA = Double.Parse(a);
            double integerC = Double.Parse(c);
            double x = integerC / integerA;
            if (!checkValidity(x)) return -1;
            else
            {
                int integerB = Convert.ToInt32(x);
                string calculatedB = integerB.ToString();
                int i = getQmIndex(b);
                if (checkForLeadingZero(b, calculatedB)) return -1;
                else
                {
                    for (int j = 0; j < calculatedB.Length; j++)
                    {
                        if (b[j] != '?')
                        {
                            if (b[j] != calculatedB[j])
                                return -1;
                        }
                    }
                    return (calculatedB[i] - '0');
                }
            }
        }
        
            throw new NotImplementedException();
        }
        static bool checkValidity(double x)
        {
            if (((x - (Convert.ToInt32(x))) == 0))
            return true; 
            else
            return false;
        }
        static bool checkForLeadingZero(string givenStr,string calculatedStr)
        {
        if (givenStr.Length > calculatedStr.Length) return true; 
        else return false; 
        }
        static int getQmIndex(string s)
        {

        int i = 0;
        for (i = 0; i < s.Length; i++)
        {
            if (s[i] == '?') break;
        }
        return i;
        }
        static bool containsQM(string s)
            {
            foreach(Char c in s)
            {
                if (c == '?') return true;
            }
            return false;
             }
    }
}
