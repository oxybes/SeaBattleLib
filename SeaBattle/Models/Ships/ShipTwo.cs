using System.Collections.Generic;

namespace Models.Ships
{
    public class ShipTwo : Ship
    {
        public ShipTwo(List<Square> squares) : base(squares)
        {
            Length = 2;
        }

        public ShipTwo()
        {
            Length = 2;
        }
    }
}
