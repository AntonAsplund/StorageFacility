using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageFacility
{
    class PrintTexts
    {
        public void PrintMainMenu()
        {
            Console.WriteLine("Welcome to Storage Facility Manager");
            Console.WriteLine("1: Store a new box to facility");
            Console.WriteLine("2: Search for a box through ID number");
            Console.WriteLine("3: Remove a box from storage facility");
            Console.WriteLine("4: Move a stored box to a new location");
            Console.WriteLine("5. Show boxes in storage");
            Console.WriteLine("6. Quit the program\n");

            Console.Write("Please choose a menu option: ");

        }

        public void PrintCreateNewBoxInputCHoice()
        {
            Console.WriteLine("Which is the type of your box?");
            Console.WriteLine("");
            Console.WriteLine("1. Blob");
            Console.WriteLine("2. Cube");
            Console.WriteLine("3. Cuboid");
            Console.WriteLine("4. Sphere\n");

            Console.Write("Please choose a menu option: ");
        }

        public void PrintAddBoxToSpecifiedRackOrNotMenu()
        {
            Console.WriteLine("Do you want to add the box to a specified rack or first free?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No\n");

            Console.Write("Please choose a menu option: ");
        }

        public void PrintResultOfBoxAdditionToStorage(bool sucessfullAddition)
        {
            if (sucessfullAddition == true)
            {
                Console.WriteLine("The box has been sucessfully added");
            }
            else
            {
                Console.WriteLine("No box has NOT been added due to an unforseen event");
            }
        }

    }
}
