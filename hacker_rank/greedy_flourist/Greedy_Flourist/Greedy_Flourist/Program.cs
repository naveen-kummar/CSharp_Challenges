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
using System.Runtime.InteropServices.WindowsRuntime;

public class Sort_Descending : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if(x > y)
        {
            return -1;
        }
        else if(x < y)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
class Solution
{

    // Complete the getMinimumCost function below.
    static int getMinimumCost(int k, int[] c)
    {

        int minimum_cost = 0;
        List<int> flower_cost = new List<int>(c);
        Sort_Descending _descending = new Sort_Descending();
        SortedDictionary<int, int> flower_cost_dict = new SortedDictionary<int, int>(flower_cost.ToDictionary(x=>x), _descending);


        int total_flowers = flower_cost_dict.Count();
        int friend_iter = 1;
        for (int flower = 0; flower < total_flowers;)
        {
            for (int friend = 0; (friend < k) && (flower < total_flowers); friend++)
            {
                minimum_cost += flower_cost_dict.ElementAt(flower).Key * friend_iter;
                ++flower;
            }

            ++friend_iter;
        }

        return minimum_cost;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}
