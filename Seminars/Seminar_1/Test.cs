using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1
{
    class Test
    {
        public int length { get; }
        public string name;
        public bool b;

        public Test()
        {
            length = 0;
            name = "";
            b = false;
        }

        public void Print(string msg = "Hello")
        {
            if (msg == "" || msg == null)
                return;
            Console.WriteLine(msg);
        }

        public string GetReverseName()
        {
            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
