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
            //Splitting The equation into three variables eg. 42*47=1?74 to A=42 B=47 and C=1?74
            string[] tokens = equation.Split(new[]{'*', '='});
            var A = tokens[0];
            var B = tokens[1];
            var C = tokens[2];
            var missingDIgitHolder = '?';
            var result = -1;
            var ans = 0.0;

            //Checking which string variable contain "?" mark and storing the evaluated result in ans
            if(A.Equals("0") || B.Equals("0") || equation.Contains("?") == false)
                return result;
            if(A.Contains(missingDIgitHolder))
            {
                ans = double.Parse(C)/double.Parse(B);
                return findMissingDigit( ans.ToString(), A );
            }
            else if(B.Contains(missingDIgitHolder))
            {
                ans = double.Parse(C)/double.Parse(A);
                return findMissingDigit( ans.ToString(), B );
            }
            else if(C.Contains(missingDIgitHolder))
            {
                ans = double.Parse(A) * double.Parse(B);
                return findMissingDigit( ans.ToString(), C );                
            }
        }
        public int findMissingDigit(string actualValue, string evaluatedValue)
        {
            if(actualValue.Length == evaluatedValue.Length)
            {
                int indexOfQuestionMark = actualValue.IndexOf('?');
                var tempChar = evaluatedValue[ indexOfQuestionMark ];
                result = tempChar  - '0';
                return result;
            }
            else 
                return result; 

        }
    }
}
