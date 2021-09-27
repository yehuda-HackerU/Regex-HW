using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regex_HW
{
    class Program
    {
        public static bool Abc(string str)
        {
            Regex regex = new Regex(@"(ABC|abc)");
            return regex.IsMatch(str);
        }
        public static bool Name(string str)
        {
            Regex regex = new Regex(@"^[A-Za-z]{2,18}( [A-Za-z]{2,18})+$");
            return regex.IsMatch(str);
        }
        public static bool Decimal(string str)
        {
            Regex regex = new Regex(@"^\d+\.{1}\d+$");
            return regex.IsMatch(str);
        }

        public static bool Decimal3(string str)
        {
            Regex regex = new Regex(@"^\d+\.{1}\d{3}$");
            return regex.IsMatch(str);
        }

        public static bool Email(string str)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9._-]+@(gmail|yahoo)(\.[A-Za-z]{2,}){1,2}$");
            return regex.IsMatch(str);
        }

        public static bool Proxy(string str)
        {
            Regex regex = new Regex(@"^(?:http(s)?:\/\/)?[\w.-]+\.co\.il[\w\-\._~:\/?#[\]@!\$&'\(\)\*\+,;=%.]*$");
            return regex.IsMatch(str);
        }


        static void Main(string[] args)
        {
            #region Abc
            Dictionary<string, bool> testAbc = new Dictionary<string, bool>()
            {
                {"uyeAbcdd", false },
                {"testABCfff", true },
                {"oyeabcg", true },
                {"AbC", false },
                {"abvc", false }
            };

            Console.WriteLine("\nAbc pattern:");
            foreach (var item in testAbc)
            {
                bool result = Abc(item.Key);
                Console.WriteLine($"{item.Key} => {result}.  {(result == item.Value ? "pass" : "fail")}");
            }
            #endregion

            #region Name
            Dictionary<string, bool> testName = new Dictionary<string, bool>()
            {
                {"Yehuda Ben Shushan", true },
                {"Efraim", false },
                {"y b s", false },
                {"yehuda benshushanasdfghjkl", false },
                {"Elon Musk", true }
            };

            Console.WriteLine("\nName pattern:");
            foreach (var item in testName)
            {
                bool result = Name(item.Key);
                Console.WriteLine($"{item.Key} => {result}.  {(result == item.Value ? "pass" : "fail")}");
            }
            #endregion

            #region Decimal
            Dictionary<string, bool> testDecimal = new Dictionary<string, bool>()
            {
                {"11.1", true },
                {"1.", false },
                {".2", false },
                {"0.256554", true },
                {"1..2", false }
            };

            Console.WriteLine("\nDecimal pattern:");
            foreach (var item in testDecimal)
            {
                bool result = Decimal(item.Key);
                Console.WriteLine($"{item.Key} => {result}.  {(result == item.Value ? "pass" : "fail")}");
            }
            #endregion

            #region Decimal *.3
            Dictionary<string, bool> testDecimal3 = new Dictionary<string, bool>()
            {
                {".123", false },
                {"1.656", true },
                {"123.12", false },
                {"0.1234", false },
                {"1234", false }
            };

            Console.WriteLine("\nDecimal *.3 pattern:");
            foreach (var item in testDecimal3)
            {
                bool result = Decimal3(item.Key);
                Console.WriteLine($"{item.Key} => {result}.  {(result == item.Value ? "pass" : "fail")}");
            }
            #endregion

            #region Email
            Dictionary<string, bool> testEmail = new Dictionary<string, bool>()
            {
                {"yehuda@gmail.com", true },
                {"someone@yahoo.co.il", true },
                {"me_12@outlook.com", false },
                {"@gmail.com", false },
                {"yehuda_HackerU@gmail.co.il", true }
            };

            Console.WriteLine("\nEmail pattern:");
            foreach (var item in testEmail)
            {
                bool result = Email(item.Key);
                Console.WriteLine($"{item.Key} => {result}.  {(result == item.Value ? "pass" : "fail")}");
            }
            #endregion

            #region Proxy
            Dictionary<string, bool> testProxy = new Dictionary<string, bool>()
            {
                {"https://yehuda100.cf", false },
                {"http://www.google.co.il", true },
                {"https://www.hackeru.co.il/course/web-developer", true },
                {"https://www.google.co.il/somewhere123?id=123", true },
                {"http://dontasktoask.com", false }
            };

            Console.WriteLine("\nProxy pattern:");
            foreach (var item in testProxy)
            {
                bool result = Proxy(item.Key);
                Console.WriteLine($"{item.Key} => {result}.  {(result == item.Value ? "pass" : "fail")}");
            }
            #endregion


            Console.WriteLine("\n\nPress any key to close...");
            Console.ReadKey();
        }
    }
}
