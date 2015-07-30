using CsvHelper;
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


                StringBuilder outputLines = new StringBuilder();

                outputLines.AppendLine("Date,Payee,Category,Memo,Outflow,Inflow");
                var csv = new CsvReader(File.OpenText(inputFile));
                while (csv.Read())
                {
                    string date = csv.GetField<string>(1);
                    string fixedDate = DateTime.ParseExact(date.Replace('\"', ' ').Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                    string desc = csv.GetField<string>(2);
                    string debit = csv.GetField<string>(3);
                    string credit = csv.GetField<string>(4);

                    debit = cleanNumber(debit);

                    credit = cleanNumber(credit);

                    outputLines.AppendLine(string.Format("{0},{1},,,{2},{3}", fixedDate, desc, debit, credit));
                }
               

                File.WriteAllText(outputFile, outputLines.ToString());
            }
        }

        private static string cleanNumber(string input)
        {
            string output = input;
            while(output.IndexOf(',') > -1)
            {
                output = output.Remove(output.IndexOf(','), 1);
            }
            return output;
        }
    }
}
