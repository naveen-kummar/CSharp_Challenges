using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime[] bankHols1 =
{
                new DateTime(2021, 1, 1),
                new DateTime(2021, 4, 2),
                new DateTime(2021, 4, 5),
                new DateTime(2021, 5, 3),
                new DateTime(2021, 5, 31),
                new DateTime(2021, 8, 30),
                new DateTime(2021, 12, 27),
                new DateTime(2021, 12, 28),
            };

            DateTime[] bankHols2 =
{
                new DateTime(2021, 1, 1),
                new DateTime(2021, 4, 2),
                new DateTime(2021, 4, 5),
                new DateTime(2021, 5, 3),
                new DateTime(2021, 5, 31),
                new DateTime(2021, 8, 30),
                new DateTime(2021, 12, 27),
                new DateTime(2021, 12, 28),
            };

            Console.WriteLine($"equal values? {bankHols1.SequenceEqual(bankHols2)}");

            string input = Console.ReadLine();

        }
    }
}
