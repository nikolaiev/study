using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPolindrom
{
    /// <summary>
    /// str - input string
    /// </summary>
    public class MyPolindrom
    {
        public static string Pol(string str)
        {
            string temp1="";
            for (int i=0;i<=(int)(str.Length/2);i++)
            {
                temp1 += str[i];
                //Console.WriteLine(temp1);

                string temp2 = "";
                for(int j = i + 1; j <= 2*i+1 && !(i== (int)(str.Length / 2)/* && str.Length% 2>0*/); j++)
                {
                    temp2 = str[j]+temp2;
                }

                //Console.WriteLine(temp2);

                string temp3 = "";
                for (int j = i; j <= 2 * i && i>0 && !(i == (int)(str.Length / 2) && str.Length% 2==0); j++)
                {
                    temp3 = str[j] + temp3;
                }

                //Console.WriteLine(temp3);

                if (temp1.Equals(temp2))
                {
                    string res = "";
                    for(int k = 0; k <= 2 * i + 1; k++)
                    {
                        res += str[k];
                    }
                    return res;
                }

                if (temp1.Equals(temp3))
                {
                    string res = "";
                    for (int k = 0; k <= 2 * i; k++)
                    {
                        res += str[k];
                    }
                    return res;
                }                
            }
           
            return "";
        }
        
    }
}
