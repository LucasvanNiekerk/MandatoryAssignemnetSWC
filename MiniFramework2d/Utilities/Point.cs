namespace MiniFramework2d.Utilities
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X{get; set; }
        public int Y{get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Point;

            if (item == null)
            {
                return false;
            }

            return X == item.X && Y == item.Y;
        }

        public override int GetHashCode()
        {
            return (X.GetHashCode() *3) + Y.GetHashCode();
        }
    }
}
