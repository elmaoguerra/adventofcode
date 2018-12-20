using System;
using System.Collections.Generic;
using System.IO;

namespace core_day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines  = File.ReadAllLines("../input.dat");
            var numbers = GetNumbers(lines);
            System.Console.WriteLine(Sum(numbers));


            System.Console.WriteLine(GetTwiceFrec(new List<int>(){1,-1}));
            System.Console.WriteLine(GetTwiceFrec(new List<int>(){3,3,4,-2,-4}));
            System.Console.WriteLine(GetTwiceFrec(new List<int>(){-6,3,8,5,-6}));
            System.Console.WriteLine(GetTwiceFrec(new List<int>(){7,7,-2,-7,-4}));
            
            System.Console.WriteLine(GetTwiceFrec(numbers));

        }

        static IEnumerable<int> GetNumbers(string[] lines)
        {
            foreach (var l in lines)
            {
                var number = Convert.ToInt32(l);
                yield return number;
            }
        }

        static int Sum(IEnumerable<int> numbers){
            var sum = 0;
            foreach (var n in numbers)
                sum+=n;

            return sum;
        }

        static int GetTwiceFrec(IEnumerable<int> numbers){
            var set = new HashSet<int>();
            foreach (var n in GetFrequencies(numbers))
            {
                if(set.Contains(n))
                    return n;
                else 
                    set.Add(n);
            }

            throw new Exception("Frecuency not found");
        }

        static IEnumerable<int> GetFrequencies(IEnumerable<int> numbers)
        {
            var start = 0;
            yield return start;
            while(true)
            {
                foreach (var n in numbers)
                {
                    start+=n;
                    yield return start;
                }
            }
        }
    }
}
