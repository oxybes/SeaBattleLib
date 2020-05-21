using System.Collections.Generic;

namespace Models.Ships
{
    public class ShipOne : Ship
    {
        public ShipOne(List<Square> squares) : base(squares)
        {
            Length = 1;
        }

        public ShipOne()
        {
            Length = 1;
        }

 
    }
}
