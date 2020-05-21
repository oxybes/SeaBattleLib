using System.Collections.Generic;

namespace Models.Ships
{
    public class ShipFour : Ship
    {
        public ShipFour(List<Square> squares) : base(squares)
        {
            Length = 4;
        }

        public ShipFour()
        {
            Length = 4;
        }
    }
}
