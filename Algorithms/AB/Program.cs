using System;

namespace AB
{
    class Program
    {
        static void Main(string[] args)
        {
             string[] entered = Console.ReadLine().Split(' ');
           Console.WriteLine(int.Parse(entered[0]) + int.Parse(entered[1]));
        }
    }
}
