using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string consoleInputString = "";
            var random = new Random();

            while (true)
            {
                var randomVal = random.Next(2);
                switch (randomVal)
                {
                    case 0:
                        Thread.Sleep(1000);
                        Console.Write("나이를 입력하세요 : ");
                        consoleInputString = Console.ReadLine();
                        Console.WriteLine($"당신의 나이는 {consoleInputString}");
                        break;
                    case 1:
                        Thread.Sleep(2500);
                        Console.Write("이름을 입력하세요 : ");
                        consoleInputString = Console.ReadLine();
                        Console.WriteLine($"{consoleInputString}");
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
    }
}
