using System;
using System.Globalization;

namespace SQRTSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo nfi = NumberFormatInfo.InvariantInfo;
           string Input = Console.In.ReadToEnd();
           string[] Nums = Input.Split(new char[0],StringSplitOptions.RemoveEmptyEntries);
           for (int i=Nums.Length-1; i >= 0;i--)
           {
              Console.WriteLine(string.Format(nfi,"{0:F4}",Math.Sqrt(double.Parse(Nums[i]))));
           }
        }
    }
}
