using System;
using System.Collections.Generic;
using System.IO;

namespace CoreDay03
{
    class Program
    {
        static void Main(string[] args)
        {
            // var claims = new List<Claim>(){
            //     new Claim(1, 1, 3, 4, 4),
            //     new Claim(2, 3, 1, 4, 4),
            //     new Claim(3, 5, 5, 2, 2),
            // };


            var claims = new List<Claim>();
            var lines = File.ReadAllLines("../input.txt");
            foreach (var line in lines)
            {
                var claimData = line.Replace("#", "").Replace(" @", "").Replace(":", "").Split(new char[]{' ', ',', 'x'});
                var id = Convert.ToInt32(claimData[0]);
                var left = Convert.ToInt32(claimData[1]);
                var top = Convert.ToInt32(claimData[2]);
                var width = Convert.ToInt32(claimData[3]);
                var height = Convert.ToInt32(claimData[4]);

                claims.Add(new Claim(id, left, top, width, height));
            }

            var fabric = new Fabric(claims);


            Console.WriteLine($"Fabric size = ({fabric.Height} x {fabric.Width})");

            Console.WriteLine($"X = {fabric.XPositions.Count}");
            Console.WriteLine($"Clean Claims");
            foreach (var item in fabric.CleanClaims)
                System.Console.WriteLine(item.Id);
        }
    }
}
