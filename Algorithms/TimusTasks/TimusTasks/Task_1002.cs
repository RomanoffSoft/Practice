using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimusTasks
{
   public class Task_1002
    {
       public void Run()
       {
           string Input = Console.In.ReadToEnd();
           string[] input = Input.Split(new string[] { " ", "\t","\r\n" },
            StringSplitOptions.RemoveEmptyEntries);
           if (input[0] == "-1" || input.Length < 3 || string.IsNullOrEmpty(input[0])) return;
           Dictionary<int, string> Cipher = new Dictionary<int, string> { { 1, "ji" }, {2,"abc" },{ 3, "def"}
           ,{4,"gh"}, {5,"kl"},{6,"mn"},{7,"prs"},{8,"tuv"},{9,"wxy"},{0,"oqz"}};
           Dictionary<char, int> Char2Digit = new Dictionary<char, int> {
               {'j',1} , {'i',1} , {'a',2} , {'b',2} , {'c',2} , 
               {'d',3} , {'e',3} , {'f',3},
               {'g',4} , {'h',4} , {'k',5} , {'l',5},
               {'m',6} , {'n',6} , 
               {'p',7} , {'r',7} , {'s',7} ,
               {'t',8} , {'u',8} , {'v',8} ,
               {'w',9} , {'x',9} , {'y', 9} ,
               {'o',0} , {'q',0} , {'z',0}
           };
           int i=0;
           while (i<input.Length)
           {
               string number = input[i++];
               int count = int.Parse(input[i++]);
               string[] parts = new string[count];
               int j = 0;
               string word;
               List<string> matched = new List<string>();
               Dictionary<string, string> dict = new Dictionary<string, string>();
               for (; i < count; i++)
               {
                   word = input[i];
                   StringBuilder encoded = new StringBuilder();
                   foreach (char ch in word)
                   {
                       encoded.Append(Char2Digit[ch]);
                   }

                   if (number.Contains(encoded.ToString()))
                       dict.Add(encoded.ToString(), word);
               }
               var sortedDict = from entry in dict orderby entry.Key.Length ascending select entry;
               Dictionary<int, string> Indexes = new Dictionary<int, string>(); 
               foreach (KeyValuePair<string,string> num in sortedDict)
               {
                   int index = 0;
                   string temp = number;
                   while (index != -1)
                   {
                      index = temp.IndexOf(num.Key);
                      if (index != -1)
                      {
                          Indexes.Add(index, num.Key);
                          temp = temp.Remove(index, num.Key.Length - 1);
                      }
                   }
                    
               }
               

              /* foreach (char ciph in number.ToCharArray())
               {
                   if (!char.IsDigit(ciph)) break;
                   int k = (int)char.GetNumericValue(ciph);
                   string match = Cipher[k];
                   
               }
               */
           }


           foreach (string str in input)
           {
               Console.WriteLine(str);
           }
       }
    }
}
