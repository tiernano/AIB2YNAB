using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIB2YNAB
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count() != 2)
            {
                Console.WriteLine("Expecting 2 Parameters: Input File and Output File");
                return;
            }
            else
            {
                string inputFile = args[0];
                string outputFile = args[1];
                if (!File.Exists(inputFile))
                {
                    Console.WriteLine("Inputfile should exist...");
                    return;
                }
                if (File.Exists(outputFile))
                {
                    Console.WriteLine("WARN: Output exists. Will be overwritten");
                    File.Delete(outputFile);
                }
                string[] lines = File.ReadAllLines(inputFile);
                StringBuilder outputLines = new StringBuilder();

                outputLines.AppendLine("Date,Payee,Category,Memo,Outflow,Inflow");

                foreach(string line in lines.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    string[] parts = line.Split(',');
                    string date = parts[1];
                    string fixedDate = DateTime.ParseExact(date.Replace('\"',' ').Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                    string desc = parts[2];
                    string debit = parts[3];
                    string credit = parts[4];
                    outputLines.AppendLine(string.Format("{0},{1},,,{2},{3}", fixedDate, desc, debit, credit));
                }

                File.WriteAllText(outputFile, outputLines.ToString());
            }
        }
    }
}
