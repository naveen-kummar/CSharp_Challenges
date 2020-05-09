using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace all_problems.rverse_shuffle_merge
{
    class reverse_shuffle_merge
    {
        // Complete the reverseShuffleMerge function below.
        static string reverseShuffleMerge(string s)
        {

            //Find no repeat pos
            int position = 0;
            int correct_position = 0;
            string reverse_string = "";
            foreach (var c in s)
            {
                if ((reverse_string.Count(ch => ch == c)) <
                            (s.Count(ch => ch == c)) / 2)
                {
                    correct_position = position;
                    reverse_string += c;
                }
                else
                {
                    if (reverse_string[reverse_string.Count() - 1] > c)
                    {
                        if (((reverse_string.Count(ch => ch == c)) % 2) == 1)
                        {
                            reverse_string =
                            reverse_string.Remove(reverse_string.IndexOf(c), 1);

                            reverse_string += c;
                        }
                    }
                }
                ++position;
            }

            //reverse_string = reverse_string.Reverse();
            char[] charArray = reverse_string.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
            //return reverse_string;

        }

        static void Main1(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = reverseShuffleMerge(s);

            Console.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
