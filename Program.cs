using System;
namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool start = true;
            double x;
            while (start)
            {
                Console.WriteLine("1.Факториал" +
                    "\n2.Фибоначчи" +
                    "\n3.Решение функции" +
                    "\n4.Ряд Тейлора" +
                    "\n5.Выход");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Введите факториал какого числа нужно посчитать");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Факториал числа {0}, равен {1}", x, Factorial(x));
                        break;
                    case 2:
                        Console.WriteLine("Введите сколько чисел должно быть в ряде");
                        x = Convert.ToDouble(Console.ReadLine());
                        Fibonachi(x);
                        break;
                    case 3:
                        Console.WriteLine("Введите x для решения функции не меньше 1 иначе оно будет заменено на 1");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Решение функции при x = {0}: {1}\n", x, Function(x));
                        break;
                    case 4:
                        Console.WriteLine("Введите x для ряда тейлора");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите сколько чисел должны быть одинаковы в ряде Тейлора");
                        int num = Convert.ToInt32(Console.ReadLine());
                        Teylor(x, num);
                        break;
                    case 5:
                        start = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Teylor(double n, int t)
        {
            int i = 3;
            double[] tempX = new double[2];
            bool start = true;
            int minus = -1;
            tempX[0] = n;
            if (t < 1)
            {
                t = 1;
            }
            while (start)
            {
                //tempX[1] = 1;
                tempX[1] = tempX[0] + minus * (Math.Pow(n, i) / Factorial(i));
                minus *= -1;
                if ((int)(tempX[1] * Math.Pow(10, t - 1)) == (int)(tempX[0] * Math.Pow(10, t - 1)))
                {
                    start = false;
                    Console.WriteLine("\nЧисло перед искомым: {0}\nИскомое число: {1}\n", tempX[0], tempX[1]);
                }
                else
                {
                    Console.WriteLine("{0}", tempX[1]);
                    tempX[0] = tempX[1];
                    i += 2;
                }
            }
        }
        public static double Function(double n)
        {
            if (n < 1)
            {
                n = 1;
            }
            double A = 0;
            A = Math.Sin(5 / n) * Math.Cosh(Math.Sqrt(n - 1)) + Math.Pow(Math.E, 5 * n);
            return Math.Round(A, 4);
        }
        public static void Fibonachi(double n)
        {
            double zero = 0;
            double one = 1;
            double[] chisla = new double[Convert.ToInt32(n)];
            if (n > 1)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write(zero + "," + one);
                    zero = zero + one;
                    one = zero + one;
                    if (i < n / 2 - 1)
                    {
                        Console.Write(",");
                    }
                    else
                    {
                        Console.Write("...\n");
                    }
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
        public static ulong Factorial(double n)
        {
            ulong temp = 1;
            if (n > 0)
            {
                while (n > 0)
                {
                    temp = temp * (ulong)n--;
                }
                return temp;
            }
            else
            {
                return 0;
            }
        }
    }
}
