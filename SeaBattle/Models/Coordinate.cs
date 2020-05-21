namespace Models
{
    public struct Coordinate
    {

        public int X { get; set; }

        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Coordinate a, Coordinate b) => (a.X == b.X) && (a.Y == b.Y);

        public static bool operator !=(Coordinate a, Coordinate b) => !(a == b);

        public override string ToString() => (char)('A' + X) + (8 - Y).ToString();

        public bool Equals(Coordinate other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Coordinate && Equals((Coordinate)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

    }
}
