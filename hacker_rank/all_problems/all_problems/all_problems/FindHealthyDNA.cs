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

            int min = Int32.MaxValue;
            int max = 0;

            for (int sItr = 0; sItr < s; sItr++)
            {
                string[] firstLastd = Console.ReadLine().Split(' ');

                int first = Convert.ToInt32(firstLastd[0]);

                int last = Convert.ToInt32(firstLastd[1]);

                string d = firstLastd[2];

                GetHealthValues(n, genes, health, first, last, d, ref min, ref max);
            }

            Console.WriteLine("{0} {1}", min, max);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void GetHealthValues(int n,
                                    string[] genes,
                                    int[] health,
                                    int first,
                                    int last,
                                    string d,
                                    ref int min,
                                    ref int max)
        {
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

            if (min > Cost)
            {
                min = Cost;
            }

            if (max < Cost)
            {
                max = Cost;
            }

            return;

        }

    }
}
