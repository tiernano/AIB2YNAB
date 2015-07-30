using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIB2YNAB
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count() == 2)
            {
                Console.WriteLine("Expecting 2 Parameters: Input File and Output File");
            }
        }
    }
}
