using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public static class NameGenerator
    {
        public static string GenerateName(string name)
        {
            return name + '1';
        }
        public static string GenerateName(string name, ref int number)
        {
            return name + number++;
        }
        public static string GenerateName(IEnumerable<string> allNames, string nameBase)
        {
            int max = 0;
            foreach (var name in allNames)
            {
                var namePart = string.Join("", name.SkipWhile(x => !char.IsDigit(x)));
                if (int.TryParse(namePart, out int num))
                {
                    if (num > max)
                        max = num;
                }
            }
            return nameBase + (max + 1);
        }
        public static string GenerateName(IEnumerable allNames, string defaultName)
        {
            return GenerateName(allNames.Cast<string>(), defaultName);
        }
    }
}