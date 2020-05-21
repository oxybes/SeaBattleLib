using System.Collections.Generic;

namespace Models.Ships
{
    public class ShipThree : Ship
    {
        public ShipThree(List<Square> squares) : base(squares)
        {
            Length = 3;
        }

        public ShipThree()
        {
            Length = 3;
        }
    }
}
