using System;
using TaxiLogic;

namespace TaxiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxiService taxi = new TaxiService();
            bool firstOrder = true;
            int usersNumber = 0;

            while (usersNumber == 0)
            {
                Console.Clear();
                usersNumber = Display.MenuSelection();
            }

            District selectedDistrict = Display.FirstOrderSelection(taxi.Drivers, taxi.Districts, usersNumber);
            int orderedDriversIndex = TaxiService.SelectFastestDriversIndex(taxi.Drivers, selectedDistrict);
            taxi.Drivers[orderedDriversIndex].CurrentDistric = selectedDistrict;
            taxi.Drivers[orderedDriversIndex].StatusAvaible = false;
            firstOrder = false;

            while (true)
            {
                selectedDistrict = Display.NextSelection(taxi.Drivers, taxi.Districts, selectedDistrict, orderedDriversIndex, firstOrder);
                orderedDriversIndex = TaxiService.SelectFastestDriversIndex(taxi.Drivers, selectedDistrict);
                taxi.Drivers[orderedDriversIndex].CurrentDistric = selectedDistrict;
                taxi.Drivers[orderedDriversIndex].StatusAvaible = false;
            }
        }
    }
}
