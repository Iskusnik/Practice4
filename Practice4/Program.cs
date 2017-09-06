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

            public VeryLongDouble(int nInt, int nFloat)
            {
                IntegralPart = new char[nInt + 1];
                FloatPart = new char[nFloat + 1];

                for (int i = 0; i < nInt + 1; i++)
                    IntegralPart[i] = '0';
                for (int i = 0; i < nFloat + 1; i++)
                    FloatPart[i] = '0';

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
                    while (i != 0 && IntegralPart[i] == '0')
                        i--;
                    temp = new char[i + 1];
                    for (int j = 0; j < temp.Length; j++)
                        temp[j] = IntegralPart[j];

                    IntegralPart = (char[])temp.Clone();
                }
                if (FloatPart.Last() == '0' && FloatPart.Length != 1)
                {
                    int i = FloatPart.Length - 1;
                    while (i != 0 && FloatPart[i] == '0')
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
        
        static void DividedByTwoXTimes(ref VeryLongDouble a, int X)
        {

            VeryLongDouble buf = new VeryLongDouble();

            for (int i = 0; i < X; i++)
            {
                buf = new VeryLongDouble(a.IntegralPart.Length, a.FloatPart.Length);

                #region IntegralPartDivision
                for (int j = a.IntegralPart.Length - 1; j >= 0; j--)
                {
                    if (a.IntegralPart[j] == '0')
                        continue;

                    if (a.IntegralPart[j] == '1')
                    {
                        if (j != 0)
                            buf.IntegralPart[j - 1] = '5';
                        else
                            buf.FloatPart[0] = '5';
                    }

                    if (a.IntegralPart[j] == '2')
                        buf.IntegralPart[j] += char.ConvertFromUtf32(1)[0];

                    if (a.IntegralPart[j] == '3')
                    {
                        buf.IntegralPart[j] += char.ConvertFromUtf32(1)[0];
                        if (j != 0)
                            buf.IntegralPart[j - 1] = '5';
                        else
                            buf.FloatPart[0] = '5';
                    }

                    if (a.IntegralPart[j] == '4')
                        buf.IntegralPart[j] += char.ConvertFromUtf32(2)[0]; ;


                    if (a.IntegralPart[j] == '5')
                    {
                        buf.IntegralPart[j] += char.ConvertFromUtf32(2)[0];
                        if (j != 0)
                            buf.IntegralPart[j - 1] = '5';
                        else
                            buf.FloatPart[0] = '5';
                    }

                    if (a.IntegralPart[j] == '6')
                        buf.IntegralPart[j] += char.ConvertFromUtf32(3)[0];

                    if (a.IntegralPart[j] == '7')
                    {
                        buf.IntegralPart[j] += char.ConvertFromUtf32(3)[0];
                        if (j != 0)
                            buf.IntegralPart[j - 1] = '5';
                        else
                            buf.FloatPart[0] = '5';
                    }

                    if (a.IntegralPart[j] == '8')
                        buf.IntegralPart[j] += char.ConvertFromUtf32(4)[0];

                    if (a.IntegralPart[j] == '9')
                    {
                        buf.IntegralPart[j] += char.ConvertFromUtf32(4)[0];
                        if (j != 0)
                            buf.IntegralPart[j - 1] = '5';
                        else
                            buf.FloatPart[0] = '5';
                    }
                }
                #endregion
                #region FloatPartDivision
                for (int j = 0; j < a.FloatPart.Length; j++)
                {
                    if (a.FloatPart[j] == '0')
                        continue;

                    if (a.FloatPart[j] == '1')
                        buf.FloatPart[j + 1] = '5';
                   

                    if (a.FloatPart[j] == '2')
                        buf.FloatPart[j] += char.ConvertFromUtf32(1)[0];

                    if (a.FloatPart[j] == '3')
                    {
                        buf.FloatPart[j] += char.ConvertFromUtf32(1)[0];
                        buf.FloatPart[j + 1] = '5';
                    }

                    if (a.FloatPart[j] == '4')
                        buf.FloatPart[j] += char.ConvertFromUtf32(2)[0]; ;


                    if (a.FloatPart[j] == '5')
                    {
                        buf.FloatPart[j] += char.ConvertFromUtf32(2)[0];
                        buf.FloatPart[j + 1] = '5';
                    }
                    

                    if (a.FloatPart[j] == '6')
                        buf.FloatPart[j] += char.ConvertFromUtf32(3)[0];

                    if (a.FloatPart[j] == '7')
                    {
                        buf.FloatPart[j] += char.ConvertFromUtf32(3)[0];
                        buf.FloatPart[j + 1] = '5';
                    }

                    if (a.FloatPart[j] == '8')
                        buf.FloatPart[j] += char.ConvertFromUtf32(4)[0];

                    if (a.FloatPart[j] == '9')
                    {
                        buf.FloatPart[j] += char.ConvertFromUtf32(4)[0];
                        buf.FloatPart[j + 1] = '5';
                    }
                }
                #endregion
                a = buf;
                a.CutZeroes();
            }

            a.CutZeroes();
        }
        static void Main(string[] args)
        {   
            VeryLongDouble a = new VeryLongDouble();
            a.FloatPart = new char[] { '0' };
            a.IntegralPart = new char[] { '1' };
            DividedByTwoXTimes(ref a, 200);
            Console.WriteLine(a);
        }
    }
}
