//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rextester
{
    public class Program
    {
        public class Person
        {
            public Person(int birthYear, int endYear)
            {
                this.birthYear = birthYear;
                this.endYear = endYear;
            }
            
            public int birthYear;
            public int endYear;
        }
        
        public int getLiveliestYear (List<Person> persons)
        {
            if (persons.Count == 0)
            {
                return -1;
            }
            
            Dictionary<int, int> counter = new Dictionary<int, int>(persons.Count);
            int liveliestYear = persons[0].birthYear;
            
            foreach (Person person in persons)
            {
                int birthYear = person.birthYear;
                int endYear = person.endYear;
                
                for (int year = birthYear; year <= endYear; ++year)
                {
                    bool hasYear = counter.ContainsKey(year);
                    int count = hasYear ? counter[year] + 1 : 1;
                    
                    counter[year] = count;

                    int largestCount = counter[liveliestYear];

                    liveliestYear = count > largestCount ? year : liveliestYear;
                }
            }
            
            return liveliestYear;
        }
        
        public List<Person> generatePersons (int count, int startYear, int finishYear)
        {
            List<Person> persons = new List<Person>(count);
            Random rand = new Random();
            int birthOffset = finishYear - startYear;
            
            for (int i = 0; i < count; ++i)
            {
                int birthYear = startYear + rand.Next(birthOffset);
                int endOffset = finishYear - birthYear;
                int endYear = birthYear + rand.Next(endOffset);
                
                persons.Add(new Person(birthYear, endYear));
            } 
            
            return persons;
        }
        
        public void printTimeline (List<Person> persons, int startYear, int finishYear)
        {
            foreach (Person person in persons)
            {
                int birthYear = person.birthYear;
                int endYear = person.endYear;
                
                for (int year = startYear; year <= finishYear; ++year)
                {
                    if (year < birthYear)
                    {
                        Console.Write("         ");
                    }
                    else if (year >= birthYear && year < endYear)
                    {
                        Console.Write(year + " --> ");
                    }
                    else if (year == endYear)
                    {
                        Console.WriteLine(endYear);
                    }
                }
            }
        }
        
        public void test ()
        {
            List<Person> data = new[]
            {
                new Person(1990, 1991),
                new Person(1990, 1991),
                new Person(1990, 1991),
                new Person(1990, 1991)
            }.ToList();
            
            bool result = getLiveliestYear(data) == 1990;
            Console.WriteLine(result);
        }
        
        public static void Main(string[] args)
        {
            Program p = new Program();
            int population = 10;
            int startYear = 1990;
            int finishYear = 2000;
            List<Person> persons = p.generatePersons(population, startYear, finishYear);
            
            p.printTimeline(persons, startYear, finishYear);
            
            int liveliestYear = p.getLiveliestYear(persons);
            
            Console.WriteLine("Liveliest Year = " + liveliestYear);
        }
    }
}
