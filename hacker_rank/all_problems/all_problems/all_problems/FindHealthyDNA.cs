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

            uint[] health = Array.ConvertAll(Console.ReadLine().Split(' '), healthTemp => Convert.ToUInt32(healthTemp))
            ;
            int s = Convert.ToInt32(Console.ReadLine());

            int sItr = 0;
            List<uint> CostList = new List<uint>();

            Parallel.For(sItr,
                         s,
                         () => new List<uint>(),
                         (i, state, LocalCost) =>
                         {
                             string[] firstLastd = Console.ReadLine().Split(' ');

                             int first = Convert.ToInt32(firstLastd[0]);

                             int last = Convert.ToInt32(firstLastd[1]);

                             string d = firstLastd[2];

                             uint Cost = 0;

                             for (int nLoop = first; nLoop <= last; nLoop++)
                             {
                                 string sub_string = d;
                                 int Length = sub_string.Length;
                                 int CurrentIndex = sub_string.IndexOf(genes[nLoop], 0, Length);
                                 while ((CurrentIndex != -1) && (CurrentIndex <= (Length)))
                                 {
                                     Cost += health[nLoop];
                                     sub_string = sub_string.Substring(CurrentIndex + 1);
                                     Length = sub_string.Length;
                                     CurrentIndex = sub_string.IndexOf(genes[nLoop], 0, Length);
                                 }
                             }

                             LocalCost.Add(Cost);
                             return LocalCost;

                         },
            LocalCost =>
            {
                lock (CostList)
                {
                    CostList.AddRange(LocalCost);
                }
            });

            CostList.Sort();

            Console.WriteLine("{0} {1}", CostList[0], CostList[s - 1]);

        }


    }
}

