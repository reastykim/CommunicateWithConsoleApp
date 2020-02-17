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
                        Console.WriteLine("나이를 입력하세요 : ");
                        consoleInputString = Console.ReadLine();
                        Console.WriteLine($"당신의 나이는 {consoleInputString}");
                        break;
                    case 1:
                        Thread.Sleep(2500);
                        Console.WriteLine("이름을 입력하세요 : ");
                        consoleInputString = Console.ReadLine();
                        Console.WriteLine($"당신의 이름은 {consoleInputString}");
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
    }
}
