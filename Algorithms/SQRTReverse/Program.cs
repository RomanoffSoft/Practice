using System;
using System.Diagnostics;
//Посчитать квадратный корень у чисел, вводимых с кучей пробелов,
//в обратном порядке. 
namespace SQRTReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Надо разделить числа указанные с неопр. кол-вом пробелов
           // string Input = " 25   36   256   2343434";
            string Input = Console.ReadLine();
            string[] Nums = Input.Split(new char[0],StringSplitOptions.RemoveEmptyEntries);
            Stopwatch sw = new Stopwatch(); 
            sw.Start();
            for (int i=Nums.Length-1;i>=0;i--)
            {
               double root = DoQuadRoot(Double.Parse(Nums[i]),4);
               Console.WriteLine(root);
            }
            sw.Stop();
            Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
             for (int i=Nums.Length-1;i>=0;i--)
            {
               double root = DoQuadRootFaster(Double.Parse(Nums[i]),0.0001);
               Console.WriteLine(root);
            }
            sw.Stop();
            Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds);
        }


        private static double DoQuadRoot(double N, int Precision)
        {
           //take first assunption
           double[] Closures = new double[Precision];
           Closures[0]= N / 2;
           Precision--;
           for (int i=1;i<=Precision;i++)
           {
               double prevClosure = Closures[i-1];
               double actClosure = 0.5 * (prevClosure + N / prevClosure);
               Closures[i] = actClosure;
           }
           return Closures[Precision];
        }

        private static double DoQuadRootFaster (double N, double Precision)
        {
            double cls = 1;
             while(true)
            {         
            double rt = 0.5 * (cls + N / cls);          
            if (Math.Abs(rt - cls) < Precision) break;
            cls = rt;
            }
            return cls;
        }
    }
}
