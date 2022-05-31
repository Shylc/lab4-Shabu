using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace test
{
    public class Student
    {
        private readonly List<string> Name = new List<string>();
        private readonly List<string> Secondname = new List<string>();
        private readonly List<string> Fathername = new List<string>();
        private readonly List<double> GPA = new List<double>();

        public Student(string[] array)
        {
            var regex_name = new Regex("Имя:");
            var regex_secondname = new Regex("Фамилия:");
            var regex_fathername = new Regex("Отчество:");
            var regex_GPA = new Regex("Средний балл:");

            foreach (var VARIABLE in array)
                if (regex_name.Match(VARIABLE).Success)
                {
                    Name.Add(VARIABLE.Split(':')[1]);
                }
                else if (regex_secondname.Match(VARIABLE).Success)
                {
                    var s = VARIABLE.Split(':')[1];
                    Secondname.Add(s);
                }
                else if (regex_fathername.Match(VARIABLE).Success)
                {
                    Fathername.Add(VARIABLE.Split(':')[1]);
                }
                else if (regex_GPA.Match(VARIABLE).Success)
                {
                    // IFormatProvider formatter = new NumberFormatInfo {NumberDecimalSeparator = "."};
                    GPA.Add(double.Parse(VARIABLE.Split(':')[1]));
                }
        }

        public string[] Sort(int flag)
        {
            var s = new string[99];
            var buff = new string[Name.Count];
            var buff1 = new List<string>();
            var buff2 = new double[Name.Count];
            var buff3 = new List<double>();
            switch (flag)
            {
                case 1:
                    var order1 = from n in Name orderby n select n;
                    buff = order1.ToArray();
                    buff1 = Name;
                    break;
                case 2:
                    var order2 = from n in Secondname orderby n select n;
                    buff = order2.ToArray();
                    buff1 = Secondname;
                    break;
                case 3:
                    var order3 = from n in Fathername orderby n select n;
                    buff = order3.ToArray();
                    buff1 = Fathername;
                    break;
                case 4:
                    var order4 = from n in GPA orderby n select n;
                    buff2 = order4.ToArray();
                    buff3 = GPA;
                    break;
            }

            List<int> l = new List<int>();
            var g = 0;
            if (flag < 4)
            {
                foreach (var VARIABLE in buff)
                {
                    for (var i = 0; i < buff1.Count; i++)
                        if (l.Contains(i))
                        {
                            continue;
                        }
                        else if (VARIABLE == buff1[i])
                    {   l.Add(i);
                        s[g] = "Фамилия:" + Secondname[i];
                        g++;
                        s[g] = "Имя:" + Name[i];
                        g++;
                        s[g] = "Отчество" + Fathername[i];
                        g++;
                        s[g] = "Средния балл:" + GPA[i];
                        g++;
                        s[g] = "\n";
                        g++;
                    }
                }

                return s;
            }

            if (flag == 4)
            {
                foreach (var VARIABLE in buff2.Reverse())
                    for (var i = 0; i < buff3.Count; i++)
                        if (l.Contains(i))
                        {
                            continue;
                        }
                else if (VARIABLE == buff3[i])
                        {l.Add(i);
                            s[g] = "Фамилия:" + Secondname[i];
                            g++;
                            s[g] = "Имя:" + Name[i];
                            g++;
                            s[g] = "Отчество" + Fathername[i];
                            g++;
                            s[g] = "Средния балл:" + GPA[i];
                            g++;
                            s[g] = "\n";
                            g++;
                        }

                return s;
            }

            return s;
        }
    }
}