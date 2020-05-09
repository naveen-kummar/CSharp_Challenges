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

class Solution
{

    // Complete the getMinimumCost function below.
    static int getMinimumCost(int k, int[] c)
    {

        int minimum_cost = 0;
        List<int> flower_cost = new List<int>(c);


        flower_cost.ForEach(item => Console.Write(item + ","));

        return minimum_cost;
    }

    static void Main(string[] args)
    {
      //  TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string first_line = "5 3";
        string second_line = "1 3 5 7 9";

        string[] nk = first_line.Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(second_line.Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        Console.WriteLine(minimumCost);

        first_line =Console.ReadLine();

        // textWriter.WriteLine(minimumCost);

        //  textWriter.Flush();
        //  textWriter.Close();
    }
}
