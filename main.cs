//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rextester
{
    public class Program
    {
        public int getMostCommonYear (List<DateTime> dates)
        {
            if (dates.Count == 0)
            {
                return -1;
            }
            
            Dictionary<int, int> counter = new Dictionary<int, int>(dates.Count);
            int year = dates[0].Year;
            
            foreach (DateTime date in dates)
            {
                bool hasYear = counter.ContainsKey(date.Year);
                int count = hasYear ? counter[date.Year] + 1 : 1;
                
                counter[date.Year] = count;
                
                int largestCount = counter[year];
                
                year = count > largestCount ? date.Year : year;
            }
            
            return year;
        }
        
        public List<DateTime> generateDates (int count, DateTime startDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>(count);
            Random rand = new Random();
            int deltaDays = (endDate - startDate).Days;
            
            for (int i = 0; i < count; ++i)
            {
                int days = rand.Next(deltaDays);
                dates.Add(startDate.AddDays(days));
            }
            
            return dates;
        }
        
        public void printDates (List<DateTime> dates)
        {
            foreach (DateTime date in dates)
            {
                Console.WriteLine(date);
            }
        }
        
        public void test ()
        {
            List<DateTime> data1 = new[]
            {
                new DateTime(1990, 1, 1),
                new DateTime(1990, 1, 1),
                new DateTime(1991, 1, 1),
                new DateTime(1991, 1, 1),
                new DateTime(1991, 1, 1)
            }.ToList();
            
            bool test1 = getMostCommonYear(data1) == 1991;
            Console.WriteLine(test1);
            
            List<DateTime> data2 = new[]
            {
                new DateTime(1990, 1, 1),
                new DateTime(1990, 1, 1),
                new DateTime(1990, 1, 1),
                new DateTime(1991, 1, 1),
                new DateTime(1991, 1, 1)
            }.ToList();
            
            bool test2 = getMostCommonYear(data2) == 1990;
            Console.WriteLine(test2);
            
            List<DateTime> data3 = new[]
            {
                new DateTime(1990, 1, 1),
                new DateTime(1990, 1, 1),
                new DateTime(1991, 1, 1),
                new DateTime(1991, 1, 1),
                new DateTime(1992, 1, 1),
                new DateTime(1992, 1, 1)
            }.ToList();
            
            bool test3 = getMostCommonYear(data3) == 1990;
            Console.WriteLine(test3);
        }
        
        public static void Main(string[] args)
        {
            Program p = new Program();
            
            DateTime startDate = new DateTime(1990, 1, 1);
            DateTime endDate = new DateTime(2000, 1, 1).AddDays(-1);
            List<DateTime> dates = p.generateDates(10, startDate, endDate);
            
            p.printDates(dates);
            
            int year = p.getMostCommonYear(dates);
            
            Console.WriteLine(year);
        }
    }
}
