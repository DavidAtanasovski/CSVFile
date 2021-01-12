using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCSFVFile();
            Console.WriteLine();

        }

        static void ReadCSFVFile()
        {
            var lines = File.ReadAllLines("Navigation.txt");

            var list = new List<Company>();

            foreach (var line in File.ReadLines("Navigation.txt").Skip(1))
            {
                var values = line.Split(';');
                var company = new Company() { ID = values[0], MenuName = values[1], ParentID = values[2], IsHidden = values[3], LinkURL = values[4] };
                list.Add(company);


            }

            list.OrderBy(x => x.MenuName)
                .Where(x => x.IsHidden != "True")
                .ToList().ForEach(
                x => Console.WriteLine($"{x.ID}\t {x.MenuName}\t {x.ParentID}\t{x.IsHidden}\t {x.LinkURL}"));


        }

        public class Company
        {
            public string ID { get; set; }
            public string MenuName { get; set; }
            public string ParentID { get; set; }
            public string IsHidden { get; set; }
            public string LinkURL { get; set; }
        }
    }
}
