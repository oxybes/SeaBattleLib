namespace Models
{
    public class Move
    {
        public Square Square => new Square(MoveCoord.X, MoveCoord.Y);
        public Coordinate MoveCoord { get; set; }

        public Move(Coordinate moveCoord)
        {
            MoveCoord = moveCoord;
        }

        public Move(int x, int y)
        {
            MoveCoord = new Coordinate(x, y);
        }
    }
}
