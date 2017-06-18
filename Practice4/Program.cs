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
            public char[] IntegralPart;
            public char[] FloatPart;
            
            public VeryLongDouble()
            {
                IntegralPart = new char[] { '0' };
                FloatPart = new char[] { '0' };
            }

            public VeryLongDouble(VeryLongDouble a)
            {
                IntegralPart = new char[a.IntegralPart.Length];
                FloatPart = new char[a.FloatPart.Length];

                for (int i = 0; i < a.IntegralPart.Length; i++)
                    IntegralPart[i] = a.IntegralPart[i];

                for (int i = 0; i < a.FloatPart.Length; i++)
                    FloatPart[i] = a.FloatPart[i];
            }


            public override string ToString()
            {
                string Info = "";

                for (int i = IntegralPart.Length - 1; i >= 0; i--)
                    Info += IntegralPart[i].ToString();
                Info += ",";
                for (int i = 0; i < FloatPart.Length; i++)
                    Info += FloatPart[i].ToString();
                return Info;
            }

            public void CutZeroes()
            {
                char[] temp;

                if (IntegralPart.Last() == '0' && IntegralPart.Length != 1)
                {
                    int i = IntegralPart.Length - 1;
                    while (IntegralPart[i] == '0')
                        i--;
                    temp = new char[i + 1];
                    for (int j = 0; j < temp.Length; j++)
                        temp[j] = IntegralPart[j];

                    IntegralPart = (char[])temp.Clone();
                }
                if (FloatPart.Last() == '0' && FloatPart.Length != 1)
                {
                    int i = FloatPart.Length - 1;
                    while (FloatPart[i] == '0')
                        i--;
                    temp = new char[i + 1];
                    for (int j = 0; j < temp.Length; j++)
                        temp[j] = FloatPart[j];


                    FloatPart = (char[])temp.Clone();
                }
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
                   // buf = Plus(buf, multiplier);
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

        static VeryLongDouble Plus (VeryLongDouble a, VeryLongDouble b)
        {
            a.CutZeroes();
            b.CutZeroes();
            VeryLongDouble buf, temp = new VeryLongDouble();
            temp.IntegralPart = PlusIntegralPart(a, b);
            temp.FloatPart = PlusFloatPart(a, b, out buf);
            temp.IntegralPart = PlusIntegralPart(temp, buf);
            temp.CutZeroes();
            return temp;
        }
        static char[] PlusIntegralPart(VeryLongDouble a, VeryLongDouble b)
        {
            
            ToSameLength(ref a.IntegralPart, ref b.IntegralPart);

            VeryLongDouble temp = new VeryLongDouble(a);

            for (int i = 0; i < b.IntegralPart.Length; i++)
            {
                int charCode = temp.IntegralPart[i] - '0' + b.IntegralPart[i] - '0';
                if (charCode >= 10)
                {
                    temp.IntegralPart[i + 1] = char.ConvertFromUtf32(temp.IntegralPart[i + 1] + 1)[0];
                    charCode -= 10;
                }
                temp.IntegralPart[i] = char.ConvertFromUtf32(charCode + '0')[0];
            }
            temp.CutZeroes();
            return temp.IntegralPart;
        }
        static char[] PlusFloatPart(VeryLongDouble a, VeryLongDouble b, out VeryLongDouble buf)
        {

            buf = new VeryLongDouble();
            ToSameLength(ref a.IntegralPart, ref b.IntegralPart);

            VeryLongDouble temp = new VeryLongDouble(a);


            for (int i = b.FloatPart.Length - 1; i >= 0; i--)
            {
                int charCode = temp.FloatPart[i] - '0' + b.FloatPart[i] - '0';
                if (charCode >= 10)
                {
                    if (i != 0)
                        temp.FloatPart[i - 1] = char.ConvertFromUtf32(a.FloatPart[i - 1] + 1)[0];
                    else
                        buf.IntegralPart = new char[] { '1' };
                    charCode -= 10;
                }
                temp.FloatPart[i] = char.ConvertFromUtf32(charCode + '0')[0];
            }
            
            return temp.FloatPart;
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



            //    9995
            //   + 215
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


            char[] Pow5in200 = new char[1];
            Pow5in200[0] = '1';
            VeryLongDouble a = new VeryLongDouble();
            a.IntegralPart = new char[] { '5', '9', '9', '9' };
            VeryLongDouble b = new VeryLongDouble();
            b.IntegralPart = new char[] { '5', '1', '2' };

            MultipliedByFiveXTimes(ref Pow5in200, 7);
            Console.WriteLine(Plus(a, b).ToString());

            a.FloatPart = new char[] { '9', '9' , '9' };
            b.FloatPart = new char[] { '0', '9' };
            a = Plus(a, b);
            a.CutZeroes();
            Console.WriteLine(a.ToString());
        }
    }
}
