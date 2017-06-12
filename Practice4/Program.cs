using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    class Program
    {
        static void FiveMultipliedXTimes(ref char[] arr, int X)
        {
            char[] buf = new char[arr.Length];
            char[] multiplier;
            for (int i = 0; i < X; i++)
            {
                buf = new char[arr.Length];
                for (int j = 0; j < arr.Length; j++)
                {
                    
                    multiplier = new char[j + 2];
                    
                    if (arr[j] == '0')
                    {
                        multiplier[j] = '0';
                        multiplier[j + 1] = '0';
                    }

                    if (arr[j] == '1')
                    {
                        multiplier[j] = '5';
                        multiplier[j + 1] = '0';
                    }

                    if (arr[j] == '2')
                    {
                        multiplier[j] = '0';
                        multiplier[j + 1] = '1';
                    }

                    if (arr[j] == '3')
                    {
                        multiplier[j] = '5';
                        multiplier[j + 1] = '1';
                    }

                    if (arr[j] == '4')
                    {
                        multiplier[j] = '0';
                        multiplier[j + 1] = '2';
                    }

                    if (arr[j] == '5')
                    {
                        multiplier[j] = '5';
                        multiplier[j + 1] = '2';
                    }

                    if (arr[j] == '6')
                    {
                        multiplier[j] = '0';
                        multiplier[j + 1] = '3';
                    }

                    if (arr[j] == '7')
                    {
                        multiplier[j] = '5';
                        multiplier[j + 1] = '3';
                    }

                    if (arr[j] == '8')
                    {
                        multiplier[j] = '0';
                        multiplier[j + 1] = '4';
                    }

                    if (arr[j] == '9')
                    {
                        multiplier[j] = '5';
                        multiplier[j + 1] = '4';
                    }
                    buf = Plus(buf, multiplier);
                }
                arr = buf;
            }
        }
        static char[] Plus(char[] a, char[] b)
        {
            char[] temp; //Приведение к одинаковому числу цифр
            if (a.Length > b.Length)
            {
                temp = new char[a.Length + 1];
                for (int i = 0; i < b.Length; i++)
                    temp[i] = b[i];
                b = a;
                a = temp; 
            }
            else
            {
                temp = new char[b.Length];
                for (int i = 0; i < a.Length; i++)
                    temp[i] = a[i];
                a = temp;
            }
            for (int i = 0; i < b.Length; i++)
                if (b[i] == 0)
                    b[i] = '0';

            for (int i = 0; i < a.Length; i++)
                if (a[i] == 0)
                    a[i] = '0';

            for (int i = 0; i < b.Length; i++)
            {
                int charCode = a[i] - '0' + b[i] - '0';
                if (charCode >= 10)
                {
                    a[i + 1] = char.ConvertFromUtf32(a[i + 1] + 1)[0];
                    charCode -= 10;
                }
                a[i] = char.ConvertFromUtf32(charCode + '0')[0];
            }

            return a;
        }
        static void Main(string[] args)
        {
            //Можно заметить, что цифры числа 2^(-n) совпадают с цифрами числа 5^(n)
            //Соответсвенно можно найти цифрый числа 5^200
            //Напишем длинную арифметику
            char[] Pow5in200 = new char[1000];
            Pow5in200[0] = '1';
            char[] a = { '5', '9', '9', '9' };//    9995
            char[] b = { '5', '1', '2' };     //   + 215
                                              // = 10210
            FiveMultipliedXTimes(ref Pow5in200, 4);
            Console.WriteLine(Pow5in200);
        }
    }
}
