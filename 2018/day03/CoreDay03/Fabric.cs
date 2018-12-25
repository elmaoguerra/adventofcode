using System.Collections.Generic;

namespace CoreDay03
{
    public class Fabric
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Claim[,] Claims { get; set; }
        public HashSet<string> XPositions { get; private set; }
        public HashSet<Claim> CleanClaims { get; private set; }

        public Fabric(IEnumerable<Claim> claims)
        {
            XPositions = new HashSet<string>();
            CleanClaims = new HashSet<Claim>(claims);

            SetSize(claims);
            FillClaims(claims);
        }

        private void SetSize(IEnumerable<Claim> claims)
        {
            int dy = 0, dx = 0;
            foreach (var claim in claims)
            {
                var x = claim.Left + claim.Width;
                var y = claim.Top + claim.Height;

                if (x > dx) dx = x;
                if (y > dy) dy = y;
            }

            Height = dy; Width = dx;

            Claims = new Claim[Height, Width];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    Claims[i,j] = new Claim();
        }

        private void FillClaims(IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                var dx = claim.Left;
                var dy = claim.Top;
                for (int i = 0; i < claim.Height; i++)
                {
                    var row = dy + i;
                    for (int j = 0; j < claim.Width; j++)
                    {
                        var col = dx + j;
                        var current = Claims[row, col];
                        if (current.Id != 0)
                        {
                            XPositions.Add($"{row},{col}");
                            CleanClaims.Remove(current);
                            CleanClaims.Remove(claim);
                        }
                        Claims[row, col] = claim;
                    }
                }
            }
        }
    }
}