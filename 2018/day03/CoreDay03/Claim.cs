namespace CoreDay03
{
    public class Claim
    {
        public readonly int Id, Left, Top, Width, Height;
        public Claim(int id, int left, int top, int width, int height)
        {
            Id = id; Left = left; Top = top; Width = width; Height = height;
        }

        public Claim() => Id =0;
    }
}