using System;
using System.Collections.Generic;
using System.IO;

namespace CoreDay02
{
    class Program
    {
        static void Main(string[] args)
        {
            // var boxes = new List<BoxId>()
            // {
            //     new BoxId("abcdef"),
            //     new BoxId("bababc"),
            //     new BoxId("abbcde"),
            //     new BoxId("abcccd"),
            //     new BoxId("aabcdd"),
            //     new BoxId("abcdee"),
            //     new BoxId("ababab"),
            // };

            var boxes = new List<BoxId>();

            foreach (var line in File.ReadAllLines("../input.txt"))
                boxes.Add(new BoxId(line.Trim()));

            var two = 0;
            var three = 0;
            var simmilar = "";
            foreach (var box in boxes)
            {
                if (box.ValueCount.Contains(2))
                    two++;
                if (box.ValueCount.Contains(3))
                    three++;


                var closer = box.Simmilar(boxes);
                if (closer.Length > simmilar.Length)
                    simmilar = closer;
            }

            Console.WriteLine($"Simmilar = {simmilar}");
            Console.WriteLine($"Checksum = " + two * three);
        }
    }
}
