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

            int[] CostData = new int[s];

            for (int sItr = 0; sItr < s; sItr++)
            {
                string[] firstLastd = Console.ReadLine().Split(' ');

                int first = Convert.ToInt32(firstLastd[0]);

                int last = Convert.ToInt32(firstLastd[1]);

                string d = firstLastd[2];

                CostData[sItr] = GetHealthValues(n, genes, health, first, last, d);
            }

            Array.Sort(CostData);

            Console.WriteLine("{0} {1}", CostData[0], CostData[s - 1]);

        }

        static int GetHealthValues(int n,
                                    string[] genes,
                                    int[] health,
                                    int first,
                                    int last,
                                    string d)
        {
            int Cost = 0;

            for (int nLoop = first; nLoop <= last; nLoop++)
            {
                /* Console.WriteLine("Count of {0} in {1} is {2}", 
                                     genes[nLoop], 
                                     d, 
                                     Regex.Matches(d, genes[nLoop]).Count);*/

                int GeneCount = 0;
                int Length = d.Length;
                int CurrentIndex = d.IndexOf(genes[nLoop], 0, Length);

                /* Console.WriteLine("Index of {0} in {1} is {2} and Max is {3}", 
                                     genes[nLoop], 
                                     d, 
                                     CurrentIndex,
                                     (Length));*/

                while ((CurrentIndex != -1) && (CurrentIndex <= (Length)))
                {
                    //Console.WriteLine("Adding cost as {0}", health[nLoop]); 
                    Cost += health[nLoop];
                    CurrentIndex = d.IndexOf(genes[nLoop], CurrentIndex + 1, ((Length) - (CurrentIndex + 1)));
                }

            }

            //Console.WriteLine("Returning Cost as {0}", Cost);
            return Cost;

        }

    }

}
