using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    class Program
    {

        class VeryLongDouble
        {
            public char[] IntegralPart { get; set; }
            public char[] FloatPart { get; set; }

            public override string ToString()
            {
                string Info = "";

                for (int i = IntegralPart.Length - 1; i >= 0; i--)
                    Info += IntegralPart[i].ToString();
                Info += ",";
                Info += FloatPart.ToString();
                return Info;
            }
        }

        static void MultipliedByFiveXTimes(ref char[] arr, int X)
        {

            char[] buf = new char[arr.Length];
            char[] multiplier;
            if (arr.Last() == '1')
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

        //Приведение к одинаковому числу цифр
        static void ToSameLength(ref char[] a, ref char[] b)
        {
            char[] temp; 
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
        }
        static char[] Plus(char[] a, char[] b)
        {
            ToSameLength(ref a, ref b);

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
            if (a.Last() == '0')
            {
                int i = a.Length - 1;
                while (a[i] == '0')
                    i--;
                temp = new char[i + 1];
                for (int j = 0; j < temp.Length; j++)
                    temp[j] = a[j]; 
            }

            return temp;
        }
        static char[] Minus(char[] a, char[] b)
        {
            return null;
        }

        static void DividedByTwoXTimes(ref char[] arr, int X)
        {

            char[] buf = new char[arr.Length];
            
            for (int i = 0; i < X; i++)
            {
                buf = new char[arr.Length];
                for (int j = 0; j < arr.Length; j++)
                {

                    
                }
                arr = buf;
            }
        }
        static void Main(string[] args)
        {
            //Можно заметить, что цифры числа 2^(-n) совпадают с цифрами числа 5^(n)
            //Соответсвенно можно найти цифрый числа 5^200
            //Напишем длинную арифметику
            char[] Pow5in200 = new char[1];
            Pow5in200[0] = '1';
            char[] a = { '5', '9', '9', '9' };//    9995
            char[] b = { '5', '1', '2' };     //   + 215
                                              // = 10210
                                              //Вариант 1
                                              //Вообще, можно посчитать число нулей, умножая полученное число на 2, 
                                              //пока не станет равным 1*10^T, где T = Длинна исходного числа + число нолей, которые стоят перед этим числом в записи дроби + 1(Сама еденица, которая не нужна в записи. Соответсвует d0*10^0, которое не нужно в записи)
                                              //
                                              //
                                              //Вариант 2
                                              //Написать деление на 2
                                              //
                                              //Вариант 3
                                              //Ноль прибавляется, если первая значащая цифра меньше делителя длины не более цифры
                                              //Т.е если в массиве число 0,0125, то при делении на 2 будет (1<2) 0,00625. 
                                              //Понятно, что если цифра больше равна 2, то в записи этого разряда после деления будет целочисленное деление этой цифры в виде числа на 2

            MultipliedByFiveXTimes(ref Pow5in200, 7);
            Console.WriteLine(Pow5in200);//

        
        }
    }
}
