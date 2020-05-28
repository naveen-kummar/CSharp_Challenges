//https://www.hackerrank.com/challenges/determining-dna-health/problem

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Management.Instrumentation;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System;


namespace all_problems
{
    class FindHealthyDNA
    {

        static void ClassMain(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string[] genes = Console.ReadLine().Split(' ');

            int[] health = Array.ConvertAll(Console.ReadLine().Split(' '), healthTemp => Convert.ToInt32(healthTemp))
            ;
            int s = Convert.ToInt32(Console.ReadLine());


            int[] min_values = Enumerable.Repeat<int>(Int32.MaxValue, s).ToArray();

            int[] max_values = new int[s];
            Array.Clear(max_values, 0, max_values.Length);
            int sItr = 0;

            Parallel.For(sItr,
                         s,
                         (i, state) =>
                         {
                             string[] firstLastd = Console.ReadLine().Split(' ');

                             int first = Convert.ToInt32(firstLastd[0]);

                             int last = Convert.ToInt32(firstLastd[1]);

                             string d = firstLastd[2];

                             int Cost = 0;

                             for (int nLoop = first; nLoop <= last; nLoop++)
                             {

                                 int GeneCount = 0;
                                 int Length = d.Length;
                                 int CurrentIndex = d.IndexOf(genes[nLoop], 0, Length);

                                 while ((CurrentIndex != -1) && (CurrentIndex <= (Length)))
                                 {
                                     Cost += health[nLoop];
                                     CurrentIndex = d.IndexOf(genes[nLoop], CurrentIndex + 1, ((Length) - (CurrentIndex + 1)));
                                 }

                             }

                             if (min_values[i] > Cost)
                             {
                                 min_values[i] = Cost;
                             }

                             if (max_values[i] < Cost)
                             {
                                 max_values[i] = Cost;
                             }

                         });

            Array.Sort(min_values);
            Array.Sort(max_values);

            Console.WriteLine("{0} {1}", min_values[0], max_values[s - 1]);

        }
    }
}
