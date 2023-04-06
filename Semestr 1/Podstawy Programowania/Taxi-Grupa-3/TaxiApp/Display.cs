using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiLogic;

namespace TaxiApp
{
    public class Display
    {
        public static void MainMenu()
        {
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA WSZYSTKICH DZIELNIC I TAKSÓWEK");
            Console.WriteLine("2 => ZAMÓW TAKSÓWKĘ");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3: ");
        }

        public static void DistrictsList(List<District> districts, List<Driver> drivers)
        {
            Console.WriteLine("LISTA DZIELNIC");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("NUMER | NAZWA | ILOŚĆ TAKSÓWEK");
            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Id} | {district.Name} | {TaxiService.HowManyDriversInDistrict(drivers, district)}");
            }
        }

        public static void DriversTitle()
        {
            Console.WriteLine("LISTA TAKSÓWEK");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("SAMOCHÓD | STATUS | AKTUALNA LOKALIZACJA");
        }

        public static string DriverInfo(Driver driver)
        {
            
            string driverStatus;
            if (driver.StatusAvaible)
                driverStatus = "wolny";
            else
                driverStatus = "zajęty";
            string driverInfo = driver.Car + " | " + driverStatus + " | " + driver.CurrentDistric.Name;

            return driverInfo;
        }

        public static int MenuSelection()
        {
            MainMenu();
            string usersSelection = Console.ReadLine();
            bool isSelecionVaiid = usersSelection == "1" || usersSelection == "2" || usersSelection == "3";
            if (isSelecionVaiid)
            {
                if (usersSelection == "3")
                    Environment.Exit(0);
                return int.Parse(usersSelection);
            }
            else
                return 0;
        }

        public static int DistricrSelection()
        {
            Console.WriteLine("PROSZĘ PODAĆ NUMER DZIELNICY DO KTÓREJ CHCESZ WEZWAĆ TAKSÓWKĘ: ");
            string usersSelection = Console.ReadLine();
            bool isSelecionVaiid = usersSelection == "1" || usersSelection == "2" || usersSelection == "3" || usersSelection == "4" || usersSelection == "5";
            if(isSelecionVaiid)
                return int.Parse(usersSelection);
            else
                return 0;
        }

        public static void OrderedDriversInfo(Driver driver, District district)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"ZLECENIE REALIZUJE: {driver.Car}");
            Console.WriteLine($"CZAS DOJAZDU: {driver.TimeToOrderedDistrict} min.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static District FirstOrderSelection(List<Driver> drivers, List<District> districts, int usersNumber)
        {
            bool isUsersNumberValid = false;

            if (usersNumber == 1)
            {
                Console.Clear();
                DistrictsList(districts, drivers);
                DriversTitle();
                foreach (var driver in drivers)
                {
                    Console.WriteLine(DriverInfo(driver));
                }
                usersNumber = MenuSelection();

                isUsersNumberValid = usersNumber == 2;
                while (!isUsersNumberValid)
                {
                    Console.Clear();
                    DistrictsList(districts, drivers);
                    DriversTitle();
                    foreach (var driver in drivers)
                        Console.WriteLine(DriverInfo(driver));
                    usersNumber = MenuSelection();
                    isUsersNumberValid = usersNumber == 2;
                }
            }

            if (usersNumber == 2)
            {
                Console.Clear();
                usersNumber = DistricrSelection();
                isUsersNumberValid = usersNumber == 1 || usersNumber == 2 || usersNumber == 3 || usersNumber == 4 || usersNumber == 5;
                while (!isUsersNumberValid)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NIEPRAWIDŁOWY NUMER DZIELNICY");
                    Console.ForegroundColor = ConsoleColor.White;
                    usersNumber = DistricrSelection();
                    isUsersNumberValid = usersNumber == 1 || usersNumber == 2 || usersNumber == 3 || usersNumber == 4 || usersNumber == 5;
                }
            }

            return districts[usersNumber - 1];
        }


        public static District NextSelection(List<Driver> drivers, List<District> districts, District selectedDistrict, int orderedDriversIndex, bool firstOrder)
        {
            {
                Console.Clear();
                OrderedDriversInfo(drivers[orderedDriversIndex], selectedDistrict);
                DistrictsList(districts, drivers);
                DriversTitle();
                foreach (var driver in drivers)
                {
                    if (!firstOrder)
                        Console.WriteLine($"{DriverInfo(driver)} | ({driver.TimeToOrderedDistrict} min.)");
                    else
                        Console.WriteLine(DriverInfo(driver));
                }
                int usersNumber = DistricrSelection();
                bool isUsersNumberValid = usersNumber == 1 || usersNumber == 2 || usersNumber == 3 || usersNumber == 4 || usersNumber == 5;
                while (!isUsersNumberValid)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NIEPRAWIDŁOWY NUMER DZIELNICY");
                    Console.ForegroundColor = ConsoleColor.White;
                    usersNumber = Display.DistricrSelection();
                    isUsersNumberValid = usersNumber == 1 || usersNumber == 2 || usersNumber == 3 || usersNumber == 4 || usersNumber == 5;
                }

                return districts[usersNumber - 1];
            }
        }



    }
}
