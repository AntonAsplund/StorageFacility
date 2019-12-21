using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

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
            Console.WriteLine("Do you want to add the box to first free or a specified rack?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No\n");

            Console.Write("Please choose a menu option: ");
        }

        public void PrintResultOfBoxAdditionToStorage(bool sucessfullAddition, int[] rackPosition, int boxId)
        {
            if (sucessfullAddition == true)
            {
                Console.WriteLine("The box {0} has been sucessfully added to Level: {1} Rack:{2}", boxId, rackPosition[0] + 1, rackPosition[1]);
            }
            else
            {
                Console.WriteLine("No box has NOT been added due to an unforseen event");
            }

        }

        public void PrintAddBoxToSpecifiedLevel()
        {
            Console.Clear();
            Console.WriteLine("On what level is the rack?");
            Console.Write("Level : ");
        }
        public void PrintAddBoxToSpecifiedRack()
        {
            Console.WriteLine("\nWhat number does the rack have?");
            Console.Write("Rack: ");
        }

        public void PrintSearchForBoxById()
        {
            Console.WriteLine("What is the id of the box you want to find?");
            Console.Write("Enter ID number: ");
        }
        public void PrintNoBoxIsFound(int searchThisId)
        {
            Console.Clear();
            Console.WriteLine("No box has been found in the system.");
            Console.WriteLine("Have you entered correct id number?");
            Console.WriteLine(" Written ID number: {0}", searchThisId);
        }

        public void PrintPositionOfBox(int[] positionOfBox)
        {
            Console.WriteLine("The position of the box is:");
            Console.WriteLine("Level: {0}", positionOfBox[0] + 1);
            Console.WriteLine("Rack: {0}", positionOfBox[1]);
            Console.WriteLine("Rack slot: {0}", positionOfBox[2]);
        }

        public void PrintWhichIdToRemove()
        {
            Console.WriteLine("What is the I number of the box you want to remove?");
            Console.Write("Enter number: ");
        }

        public void PrintSucessfullRemovalOfBox(int searchAndRemoveThisId)
        {
            Console.WriteLine("The package with ID number {0} has been sucessfully removed.", searchAndRemoveThisId);
        }

        internal void PrintSearchForBoxByIdAndMove()
        {
            Console.WriteLine("What is the id of the box you want to move?");
            Console.Write("Enter ID number: ");
        }

        internal void PrintWhichLevelToMoveTo()
        {
            Console.WriteLine("To which level do you want to move the box to?");
            Console.Write("Enter level: ");
        }

        internal void PrintNoBoxHasBeenMoved()
        {
            Console.WriteLine("The box has not been moved to its new location.");
            Console.WriteLine("Due to invalid box ID or the new location has not enough room.");
        }

        internal void PrintBoxHasBeenMoved(int[] searchThisId)
        {
            Console.WriteLine("The box with ID number {0} has been moved.", searchThisId[0]);
            Console.WriteLine("New position: level {0} rack {1}", searchThisId[1] + 1, searchThisId[2]);
        }

        internal void PrintMenuChoicePrintVisualization()
        {
            Console.WriteLine("In which way do you want to see the storage?");
            Console.WriteLine("1. A basic list 5 racks at a time.");
            Console.WriteLine("2. A detailed list 1 rack at a time");
            Console.WriteLine("3. A specific storage rack.");
            Console.WriteLine("4. A list of all racks and number of boxes in them");
        }

        internal void PrintLevelChoiceVisualizationSpecificLevel()
        {
            Console.Clear();
            Console.WriteLine("On what level is the rack?");
            Console.Write("Level : ");
        }

        internal void PrintLevelChoiceVisualizationSpecificRack()
        {
            Console.WriteLine("\nWhat number does the rack have?");
            Console.Write("Rack: ");
        }

        public void PrintAllRacksBasicList(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    Console.WriteLine("Level: {0} Rack: {1}", i + 1, j);
                    foreach (I3DObject boxes in storageFacility[i, j])
                    {
                        Console.WriteLine("Id: " + boxes.Id.ToString() + "Description" + boxes.Description + "\n---");
                    }
                    if (j % 5 == 0)
                    {
                        Console.WriteLine("Press any key to continue to the next 5 racks");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
        /// <summary>
        /// Prints a list of all racks in detail. All relevant information. Prints one rack at a time
        /// </summary>
        /// <param name="storageFacility">Takes the WareHouse obejct which holds the information about to be printed</param>
        public void PrintContentsInDetailedListOneByOne(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    bool gotContent = false;
                    Console.WriteLine("Level: {0} Rack: {1}", i + 1, j);
                    foreach (I3DObject boxes in storageFacility[i, j])
                    {
                        Console.WriteLine(boxes.ToString());
                        Console.WriteLine("---");
                        gotContent = true;
                    }
                    if (gotContent == false)
                    {
                        Console.WriteLine("This rack contains no boxes.");
                    }
                    Console.WriteLine("Press any key to continue to the next rack");
                    Console.ReadKey();
                    Console.Clear();

                }
            }

        }
        /// <summary>
        /// Prints a simple list detailing the level and rack number as well as the number of boxes in each rack.
        /// </summary>
        /// <param name="storageFacility">Takes the WareHouse obejct which holds the information about to be printed</param>
        public void PrintSimpleListNumberOfBoxes(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    int numberOfBoxesInRack = 0;
                    foreach (I3DObject boxes in storageFacility[i, j])
                    {
                        numberOfBoxesInRack++;
                    }
                    Console.WriteLine("Level: {0} Rack: {1} - {2} number of boxes", i + 1, j, numberOfBoxesInRack);
                    if (j % 25 == 0)
                    {
                        Console.WriteLine("Press any key to continue to the next 25 racks.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        public void PrintExitProgramMessage()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using StorageShelfManager©");
            Console.Write("Press any key to shut down program...");
            Console.ReadKey();
        }

        

    }
}
