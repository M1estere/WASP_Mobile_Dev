using System;

namespace October29
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hi");
            
            // byte - 1 byte - 0 to 255
            // short - 2 bytes - 0 to 2^16-1
            // long, double - 8 bytes
            // int, float - 4 bytes
            
            // uint, ushort, ulong - > 0
            
            // decimal - 16 bytes - huge

            // int first = Convert.ToInt32(Console.ReadLine());
            // int second = int.Parse(Console.ReadLine());
            //
            // Console.WriteLine($"{first} + {second} = {first + second}");
            
            // int first = Convert.ToInt32(Console.ReadLine());
            // int second = int.Parse(Console.ReadLine());
            //
            // if (first > second) Console.WriteLine("First bigger");
            // else if (first < second) Console.WriteLine("Second bigger");
            // else Console.WriteLine("Same");
            //
            // Console.WriteLine((first > second) ? "First is bigger" : ((first == second) ? "Same" : "Second is bigger"));
            //
            // string message;
            // switch (first)
            // {
            //     case 1:
            //         message = "January";
            //         break;
            //     case 2:
            //         message = "February";
            //         break;
            //     case 3:
            //         message = "March";
            //         break;
            //     default:
            //         message = "Far";
            //         break;
            // }
            //
            // Console.WriteLine(message);

            // uint number = Convert.ToUInt32(Console.ReadLine());
            //
            // if ((number & 1) == 0) { Console.WriteLine("Mean"); }
            // else { Console.WriteLine("Not mean"); }
            //
            // int power = Convert.ToInt32(Console.ReadLine());
            //
            // // 1010 << 2 = 101000
            // // 1010 >> 1 = 101
            //
            // Console.WriteLine(number << power); // number * 2^power
            // Console.WriteLine(number >> power); // number / 2^power
        }
    }
}
