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

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {         
            // Add your code here.
            //Splitting The equation into three variables eg. 42*47=1?74 to A=42 B=47 and C=1?74
            string[] tokens = equation.Split(new[]{'*', '='});
            var A = tokens[0];
            var B = tokens[1];
            var C = tokens[2];
            var missingDIgitHolder = '?';
            var result = -1;
            var ans = 0.0;
            string evaluatedEquation = "";

            //Checking which string variable contain "?" mark and storing the evaluated result in ans
            if(A.Equals("0") || B.Equals("0") || !equation.Contains("?"))
                return result;
            if(A.Contains(missingDIgitHolder))
            {
                ans = double.Parse(C)/double.Parse(B);
                evaluatedEquation= ans.ToString() + "*" + B + "=" + C; 
            }
            else if(B.Contains(missingDIgitHolder))
            {
                ans = double.Parse(C)/double.Parse(A);
                evaluatedEquation = A + "*" + ans.ToString() + "=" + C;
            }
            else if(C.Contains(missingDIgitHolder))
            {
                ans = double.Parse(A) * double.Parse(B);
                evaluatedEquation = A + "*" + B + "=" + ans.ToString();
            }
            
            //Comparing the original and evaluated variables and finding the missing value
            if(equation.Length == evaluatedEquation.Length)
            {
                int indexOfQuestionMark = equation.IndexOf('?');
                var tempChar = evaluatedEquation[ indexOfQuestionMark ];
                result = tempChar  - '0';
                return result;
            }
            else 
                return result; 
        }
    }
}
