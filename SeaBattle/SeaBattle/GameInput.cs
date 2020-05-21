using Models;
using System;

namespace SeaBattle
{
    public static class GameInput
    {
        public static Move DoMove()
        {
            string result = "";
            do
            {
                Console.WriteLine("Enter the cell: ");
                result = Console.ReadLine();
                result = result.ToUpper();

                if (result.Length > 2 || result.Length == 0)
                    continue;

                try
                {
                    if (result[0] <= 'J' && result[0] >= 'A' && result[1] <= '9' && result[1] >= '0')
                        break;
                    else
                        Console.WriteLine("You entered something wrong, enter something wrong");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("You entered something wrong, enter something wrong");
                    continue;
                }

            }
            while (true);

            return new Move(new Coordinate(Convert.ToInt32(result[0] - 65), Convert.ToInt32(result[1]) - 48));
        }
    }
}
