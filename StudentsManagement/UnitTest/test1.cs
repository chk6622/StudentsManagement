using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StudentsManagement.UnitTest
{
    public class test1
    {
        public static void main(string[] args)
        {
            string str = "adsffad-fafaza";
            string spliteCharacter = "-";
            string[] results=test1.SpliteString(str, spliteCharacter);
            foreach(var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static string[] SpliteString(string str, string spliteCharacter)
        {
            string[] sArray = Regex.Split(str, spliteCharacter, RegexOptions.IgnoreCase);
            foreach (var item in sArray)
            {
                Console.WriteLine(item);
            }
            return sArray;
        }
    }
}
