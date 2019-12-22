using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;

namespace StorageFacility
{
    /// <summary>
    /// Holding the methods used when calling for a piece of text to be printed. 
    /// All text used by the program with the exception of a few isolated lines in front-end lies here.
    /// </summary>
    class PrintTexts
    {
        /// <summary>
        /// Prints the main menu of the program
        /// </summary>
        public void PrintMainMenu()
        {
            Console.WriteLine("Welcome to Storage Facility Manager");
            Console.WriteLine("1: Store a new box to facility");
            Console.WriteLine("2: Search for a box through ID number");
            Console.WriteLine("3: Remove a box from storage facility");
            Console.WriteLine("4: Move a stored box to a new location");
            Console.WriteLine("5. Show boxes in storage");
            Console.WriteLine("6. Save the information to a database");
            Console.WriteLine("7. Quit the program\n");

            Console.WriteLine("8. Add X number of test cases to the menu\n"); //This is only here for the test phase. To be deleted before final release to customer
            
            Console.Write("Please choose a menu option: ");

        }
        /// <summary>
        /// Prints the menu that holds information about which boxes the user can create in this program. 
        /// </summary>
        public void PrintCreateNewBoxInputCHoice()
        {
            Console.WriteLine("Of what type is the box?");
            Console.WriteLine("");
            Console.WriteLine("1. Blob");
            Console.WriteLine("2. Cube");
            Console.WriteLine("3. Cuboid");
            Console.WriteLine("4. Sphere\n");

            Console.Write("Please choose a menu option: ");
        }
        /// <summary>
        /// Prints the menu choice if the user want to add to first free box or not.
        /// </summary>
        public void PrintAddBoxToSpecifiedRackOrNotMenu()
        {
            Console.WriteLine("Do you want to add the box to the first free or a specified rack?");
            Console.WriteLine("1. First free");
            Console.WriteLine("2. Specified rack\n");

            Console.Write("Please choose a menu option: ");
        }
        /// <summary>
        /// Prints the result of the operation to add box to storage. Parameters going in is interpreted by method and correct result is printed.
        /// The ID is automatically generated and thus it is here the user gets knowledge of which ID their box has.
        /// </summary>
        /// <param name="sucessfullAddition">A bool value indicating if a sucessfull addition has happened</param>
        /// <param name="rackPosition">Position of the rack that the box has been added to</param>
        /// <param name="boxId">ID of the box that has been added. </param>
        public void PrintResultOfBoxAdditionToStorage(bool sucessfullAddition, int[] rackPosition, int boxId)
        {
            if (sucessfullAddition == true)
            {
                Console.WriteLine("The box {0} has been sucessfully added to Level: {1} Rack:{2}", boxId, rackPosition[0] + 1, rackPosition[1]);
            }
            else
            {
                Console.WriteLine("The box has NOT been added due to it being too big, too heavy or not enough room in storage facility.");
            }

        }
        /// <summary>
        /// Prints text handling for adding box so specified level.
        /// </summary>
        public void PrintAddBoxToSpecifiedLevel()
        {
            Console.Clear();
            Console.WriteLine("On what level is the rack?");
            Console.Write("Level : ");
        }
        /// <summary>
        /// Prints text handling for adding box to specified rack.
        /// </summary>
        public void PrintAddBoxToSpecifiedRack()
        {
            Console.WriteLine("\nWhat number does the rack have?");
            Console.Write("Rack: ");
        }
        /// <summary>
        /// Prints text handling for when user inputs ID of box to find.
        /// </summary>
        public void PrintSearchForBoxById()
        {
            Console.WriteLine("What is the ID of the box you want to find?");
            Console.Write("Enter ID number: ");
        }
        /// <summary>
        /// Prints the result if no box is found with the provided ID number. Givs user the entered ID number for user troubleshooting
        /// </summary>
        /// <param name="searchThisId"></param>
        public void PrintNoBoxIsFound(int searchThisId)
        {
            Console.Clear();
            Console.WriteLine("No box has been found in the system.\n");
            Console.WriteLine("Have you entered correct id number?");
            Console.WriteLine("Written ID number: {0}", searchThisId);
        }
        /// <summary>
        /// Prints the presentation of where the box if located. [0] = level, [1] = rack number, [2] = rack slot.
        /// </summary>
        /// <param name="positionOfBox">int array holding information about the box position.</param>
        public void PrintPositionOfBox(int[] positionOfBox)
        {
            Console.WriteLine("The position of the box is:");
            Console.WriteLine("Level: {0}", positionOfBox[0] + 1);
            Console.WriteLine("Rack: {0}", positionOfBox[1]);
            Console.WriteLine("Rack slot: {0}", positionOfBox[2]);
        }
        /// <summary>
        /// Prints the texthandling of user ID number input.
        /// </summary>
        public void PrintWhichIdToRemove()
        {
            Console.WriteLine("What is the ID number of the box you want to remove?");
            Console.Write("Enter number: ");
        }
        /// <summary>
        /// Prints the text presentation of when a box is removed. Gives user the provied ID number for a last failsafe mecanism, ensuring a faulty removal is discoverd.
        /// </summary>
        /// <param name="searchAndRemoveThisId">ID number of the box that has been recently removed</param>
        public void PrintSucessfullRemovalOfBox(int searchAndRemoveThisId)
        {
            Console.WriteLine("The package with ID number {0} has been sucessfully removed.", searchAndRemoveThisId);
        }
        /// <summary>
        /// Prints the text handling of user input whena specific ID box is to be moved
        /// </summary>
        internal void PrintSearchForBoxByIdAndMove()
        {
            Console.WriteLine("What is the ID of the box you want to move?");
            Console.Write("Enter ID number: ");
        }
        /// <summary>
        /// Prints text handling when user inputs which level to move a box to.
        /// </summary>
        internal void PrintWhichLevelToMoveTo()
        {
            Console.WriteLine("To which level do you want to move the box to?");
            Console.Write("Enter level: ");
        }
        /// <summary>
        /// Prints the text presentation of when a box has not been moved due to unforseen events.
        /// </summary>
        internal void PrintNoBoxHasBeenMoved()
        {
            Console.WriteLine("The box has not been moved to its new location.");
            Console.WriteLine("Due to invalid box ID or the new location has not enough room.");
        }
        /// <summary>
        /// Prints text handling for when a box has been moved to a specified place. Gives the user the level and rack number. A failsafe mechanism so no box is added to wring rack. 
        /// </summary>
        /// <param name="idOfBoxAndNewPosition">A int array holding information, [0] = ID number, [1] = level, [2] = rack</param>
        internal void PrintBoxHasBeenMoved(int[] idOfBoxAndNewPosition) 
        {
            Console.WriteLine("The box with ID number {0} has been moved.", idOfBoxAndNewPosition[0]);
            Console.WriteLine("New position: level {0} rack {1}", idOfBoxAndNewPosition[1] + 1, idOfBoxAndNewPosition[2]);
        }
        /// <summary>
        /// Prints the menu for when user wants to present the contents of the storage.
        /// </summary>
        internal void PrintMenuChoicePrintVisualization()
        {
            Console.WriteLine("In which way do you want to see the storage?");
            Console.WriteLine("1. A basic list 5 racks at a time.");
            Console.WriteLine("2. A detailed list 1 rack at a time");
            Console.WriteLine("3. A specific storage rack.");
            Console.WriteLine("4. A list of all racks and number of boxes in them");
        }
        /// <summary>
        /// Prints text handlng for when user wants to look at contens of specific rack.
        /// </summary>
        internal void PrintLevelChoiceVisualizationSpecificLevel()
        {
            Console.Clear();
            Console.WriteLine("On what level is the rack?");
            Console.Write("Level : ");
        }
        /// <summary>
        /// Prints text handling for when user wants to look at contents of specific rack.
        /// </summary>
        internal void PrintLevelChoiceVisualizationSpecificRack()
        {
            Console.WriteLine("\nWhat number does the rack have?");
            Console.Write("Rack: ");
        }
        /// <summary>
        /// Prints every rack with basic information about the contents
        /// </summary>
        /// <param name="storageFacility">a reference to the WareHouse object that holds the information about the storage facility</param>
        public void PrintAllRacksBasicList(WareHouse storageFacility)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 101; j++)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Level: {0} Rack: {1}", i + 1, j);
                    Console.WriteLine("--------------------");
                    foreach (I3DObject boxes in storageFacility[i, j])
                    {
                        Console.WriteLine("Id: " + boxes.Id.ToString() + "\nDescription " + boxes.Description + "\n---");
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

        public void PrintSaveMainMenuOptionChoice()
        {
            Console.WriteLine("The program has been saved.");
        }
        /// <summary>
        /// Prints the text and handling for when the users exits the program.
        /// </summary>
        public void PrintExitProgramMessage()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using StorageShelfManager©");
            Console.Write("Press any key to shut down program...");
            Console.ReadKey();
        }

        

    }
}
