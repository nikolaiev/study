using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class MyClass
    {
        public String GetElem(int n,String str)
        {
            if (str.Length <= n || n<0)
            {
                return str[str.Length - 1].ToString();
            }
            return str[n].ToString();
        }
    }
}

